﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3PA.Data;
using _3PA.Lib;
using _3PA.MainFeatures.Appli.Pages.Actions;

namespace _3PA.MainFeatures.Pro {

    public static class Deployer {

        #region public static event

        /// <summary>
        /// Called when the list of DeployTransfers is updated
        /// </summary>
        public static event Action OnDeployConfigurationUpdate;

        #endregion

        #region public static fields

        /// <summary>
        /// Get the compilation path list
        /// </summary>
        public static List<DeployRule> GetDeployRulesList {
            get {
                if (_deployRulesList == null)
                    Import();
                return _deployRulesList;
            }
        }

        #endregion

        #region private static fields

        private static List<DeployRule> _deployRulesList;

        #endregion

        #region public static methods

        public static void Export() {
            if (!File.Exists(Config.FileDeployment))
                Utils.FileWriteAllBytes(Config.FileDeployment, DataResources.DeploymentRules);
        }

        /// <summary>
        /// Read the list of compilation Path Items,
        /// if the file is present in the Config dir, use it
        /// </summary>
        public static void Import() {
            var i = 0;
            _deployRulesList = new List<DeployRule>();
            Utils.ForEachLine(Config.FileDeployment, new byte[0], s => {
                var items = s.Split('\t');

                int step = 0;
                if (items.Length > 1 && !int.TryParse(items[0], out step))
                    step = 0;

                // new transfer rule
                if (items.Length == 7) {

                    DeployType type;
                    if (!Enum.TryParse(items[3], true, out type))
                        type = DeployType.Copy;

                    var obj = new DeployTransferRule {
                        Step = step,
                        NameFilter = items[1].Trim(),
                        SuffixFilter = items[2].Trim(),
                        Type = type,
                        ContinueAfterThisRule = items[4].Trim().EqualsCi("yes"),
                        SourcePattern = items[5].Trim().Replace('/', '\\'),
                        DeployTarget = items[6].Trim().Replace('/', '\\'),
                        Line = i++
                    };

                    if (!string.IsNullOrEmpty(obj.SourcePattern) && !string.IsNullOrEmpty(obj.DeployTarget))
                        _deployRulesList.Add(obj);

                    // new filter rule
                } else if (items.Length == 5) {

                    var obj = new DeployFilterRule {
                        Step = step,
                        NameFilter = items[1].Trim(),
                        SuffixFilter = items[2].Trim(),
                        Include = items[3].Trim().EqualsCi("+"),
                        SourcePattern = items[4].Trim().Replace('/', '\\'),
                    };

                    if (!string.IsNullOrEmpty(obj.SourcePattern))
                        _deployRulesList.Add(obj);
                }
            },
            Encoding.Default);

            if (OnDeployConfigurationUpdate != null)
                OnDeployConfigurationUpdate();
        }

        /// <summary>
        /// List of the files in the given directories that 
        /// </summary>
        public static HashSet<string> GetDeployFilesList(List<string> listOfFolderPath, SearchOption searchOptions, List<DeployRule> rules, int step) {

            // constructs the list of all the files (unique) accross the different folders
            var filesToCompile = new HashSet<string>(StringComparer.CurrentCultureIgnoreCase);

            // case of step 0 (compilation) we list only compilable files
            var fileExtensionFilter = step == 0 ? Config.Instance.CompileKnownExtension : "";

            // construct the filters list
            var filtersList = rules.Where(rule => rule.Step == step && rule is DeployFilterRule).Select(rule => (DeployFilterRule)rule).ToList();
            var includeFiltersList = filtersList.Where(rule => rule.Include).ToList();
            var excludeFiltersList = filtersList.Where(rule => !rule.Include).ToList();

            foreach (var folderPath in listOfFolderPath.Where(Directory.Exists)) {
                foreach (var filePath in fileExtensionFilter.Split(',').SelectMany(s => Directory.EnumerateFiles(folderPath, "*" + s, searchOptions)).ToList()) {
                    if (!filesToCompile.Contains(filePath)) {

                        bool toAdd = true;

                        // test include filters
                        if (includeFiltersList.Count > 0) {
                            var hasMatch = false;
                            foreach (var rule in includeFiltersList) {
                                if (filePath.RegexMatch(rule.SourcePattern.WildCardToRegex())) {
                                    hasMatch = true;
                                    break;
                                }
                            }
                            toAdd = hasMatch;
                        }

                        // test exclude filters
                        if (excludeFiltersList.Count > 0) {
                            var hasNoMatch = true;
                            foreach (var rule in excludeFiltersList) {
                                if (filePath.RegexMatch(rule.SourcePattern.WildCardToRegex())) {
                                    hasNoMatch = false;
                                    break;
                                }
                            }
                            toAdd = toAdd && hasNoMatch;
                        }

                        if (toAdd)
                            filesToCompile.Add(filePath);
                    }
                }

            }

            return filesToCompile;
        }

        /// <summary>
        /// returns a string containing an html representation of the compilation path table
        /// </summary>
        public static string BuildHtmlTable(List<DeployRule> rules) {
            var strBuilder = new StringBuilder();

            if (rules.Any()) {

                if (rules.Exists(rule => rule is DeployFilterRule)) {

                    strBuilder.Append("<h2 style='padding-top: 0px; margin-top: 0px;'>Filter rules</h2>");
                    strBuilder.Append("<table width='100%;'>");
                    strBuilder.Append("<tr class='CompPathHead'><td align='center' width='5%'>Step</td><td align='center' width='9%'>Application<br>Name</td><td align='center' width='9%'>Application<br>Suffix</td><td align='center' width='8%'>Rule<br>Type</td><td width='69%' align='right'>Source path pattern</td></tr>");

                    var alt = false;
                    foreach (var rule in rules.OfType<DeployFilterRule>()) {
                        strBuilder.Append("<tr><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            rule.Step + "</td" + (alt ? " class='AlternatBackColor'" : "") + "><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            (string.IsNullOrEmpty(rule.NameFilter) ? "*" : rule.NameFilter) + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            (string.IsNullOrEmpty(rule.SuffixFilter) ? "*" : rule.SuffixFilter) + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            (rule.Include ? "Include" : "Exclude") + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='right'>" +
                            (rule.SourcePattern.Length > 45 ? "..." + rule.SourcePattern.Substring(rule.SourcePattern.Length - 45) : rule.SourcePattern) + "</td></tr>");
                        alt = !alt;
                    }

                    strBuilder.Append("</table>");
                }

                if (rules.Exists(rule => rule is DeployTransferRule)) {

                    strBuilder.Append("<h2>Transfer rules</h2>");
                    strBuilder.Append("<table width='100%;'>");
                    strBuilder.Append("<tr class='CompPathHead'><td align='center' width='5%'>Step</td><td align='center' width='9%'>Application<br>Name</td><td align='center' width='9%'>Application<br>Suffix</td><td align='center' width='6%'>Rule<br>Type</td><td align='center' width='5%'>Next?</td><td width='33%'>Source path pattern</td><td width='33%' align='right'>Deployment target</td></tr>");

                    var alt = false;
                    foreach (var rule in rules.OfType<DeployTransferRule>()) {
                        strBuilder.Append("<tr><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            rule.Step + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            (string.IsNullOrEmpty(rule.NameFilter) ? "*" : rule.NameFilter) + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            (string.IsNullOrEmpty(rule.SuffixFilter) ? "*" : rule.SuffixFilter) + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            rule.Type + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='center'>" +
                            (rule.ContinueAfterThisRule ? "Yes" : "No") + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + ">" +
                            (rule.SourcePattern.Length > 45 ? "..." + rule.SourcePattern.Substring(rule.SourcePattern.Length - 45) : rule.SourcePattern) + "</td><td" + (alt ? " class='AlternatBackColor'" : "") + " align='right'>" +
                            (rule.DeployTarget.Length > 45 ? "..." + rule.SourcePattern.Substring(rule.DeployTarget.Length - 45) : rule.DeployTarget) + "</td></tr>");
                        alt = !alt;
                    }

                    strBuilder.Append("</table>");
                }

            } else {
                strBuilder.Append("<b>Start by clicking the <i>modify</i> button</b><br>When you are done modying the file, save it and click the <i>read changes</i> button to import it into 3P");
            }

            return strBuilder.ToString();
        }


        #endregion

        #region Deploy

        /// <summary>
        /// Deploy a given list of files (can reduce the list if there are duplicated items so it returns it)
        /// </summary>
        public static List<FileToDeploy> DeployFiles(List<FileToDeploy> deployToDo, string prolibPath, Action<int> onOneFileDone = null) {

            int[] nbFilesDone = { 0 };

            // make sure to transfer a given file only once at the same place (happens with .cls file since a source
            // can have several .r files generated if it is used in another classes)
            deployToDo = deployToDo
                .GroupBy(deploy => deploy.To)
                .Select(group => group.FirstOrDefault(move => Path.GetFileNameWithoutExtension(move.From ?? "").Equals(Path.GetFileNameWithoutExtension(move.Origin))) ?? group.First())
                .ToList();

            // check that every target dir exist (for copy/move deployments)
            deployToDo
                .Where(deploy => deploy.DeployType == DeployType.Copy)
                .GroupBy(deploy => Path.GetDirectoryName(deploy.To))
                .Select(group => group.First())
                .ToNonNullList()
                .ForEach(deploy => Utils.CreateDirectory(Path.GetDirectoryName(deploy.To)));


            #region for .pl deployments, we treat them before anything else

            // for PL, we need to MOVE each file into a temporary folder with the internal structure of the .pl file,
            // then move it back where it was for further deploys...

            var plDeployments = deployToDo
                .Where(deploy => deploy.DeployType == DeployType.Prolib)
                .ToNonNullList();

            // first, determine the .pl path for each deployment
            plDeployments
                .ForEach(deploy => {
                    var pos = deploy.To.LastIndexOf(".pl", StringComparison.CurrentCultureIgnoreCase);
                    if (pos >= 0)
                        deploy.PlPath = deploy.To.Substring(0, pos + 3);
                });

            // then we create a unique temporary folder for each .pl
            var dicPlToTempFolder = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            foreach (var fileToDeploy in plDeployments
                .GroupBy(deploy => deploy.PlPath)
                .Select(deploys => deploys.First())
                .Where(deploy => !string.IsNullOrEmpty(deploy.PlPath))
                .ToNonNullList()) {

                // ensure that the folder to the .pl file exists
                Utils.CreateDirectory(Path.GetDirectoryName(fileToDeploy.PlPath));

                // create a unique temp folder for this .pl
                if (!dicPlToTempFolder.ContainsKey(fileToDeploy.PlPath)) {
                    var uniqueTempFolder = Path.Combine(Path.GetDirectoryName(fileToDeploy.PlPath), Path.GetFileName(fileToDeploy.PlPath) + "~" + Path.GetRandomFileName());
                    dicPlToTempFolder.Add(fileToDeploy.PlPath, uniqueTempFolder);
                    Utils.CreateDirectory(uniqueTempFolder, FileAttributes.Hidden);
                }
            }

            var prolibMessage = new StringBuilder();

            // for each .pl that needs to be created...
            foreach (var pl in dicPlToTempFolder) {

                var onePlDeployments = plDeployments
                    .Where(deploy => !string.IsNullOrEmpty(deploy.PlPath) && deploy.PlPath.Equals(pl.Key))
                    .ToNonNullList();
                if (onePlDeployments.Count == 0)
                    continue;

                //  we set the temporary folder on which each file will be copied..
                // Tuple : <(base) temp directory, relative path in pl, path to .pl>
                var dicTempFolderToPl = new Dictionary<string, Tuple<string, string, string>>(StringComparer.CurrentCultureIgnoreCase);
                foreach (var fileToDeploy in onePlDeployments) {
                    if (string.IsNullOrEmpty(fileToDeploy.PlPath))
                        continue;

                    if (dicPlToTempFolder.ContainsKey(fileToDeploy.PlPath)) {
                        fileToDeploy.ToTemp = Path.Combine(
                            dicPlToTempFolder[fileToDeploy.PlPath],
                            fileToDeploy.To.Replace(fileToDeploy.PlPath, "").TrimStart('\\')
                            );

                        // If not already done, remember that the *.r code in this temp folder must be integrated to this .pl file
                        var tempSubFolder = Path.GetDirectoryName(fileToDeploy.ToTemp);
                        if (!string.IsNullOrEmpty(tempSubFolder) && !dicTempFolderToPl.ContainsKey(tempSubFolder)) {
                            dicTempFolderToPl.Add(
                                tempSubFolder,
                                new Tuple<string, string, string>(
                                    dicPlToTempFolder[fileToDeploy.PlPath], // path of the temp dir
                                    Path.GetDirectoryName(fileToDeploy.To.Replace(fileToDeploy.PlPath, "").TrimStart('\\')), // relative path in .pl
                                    fileToDeploy.PlPath) // path to the .pl file
                                );

                            // also, create the folder
                            Utils.CreateDirectory(tempSubFolder);
                        }
                    }
                }

                var prolibExe = new ProcessIo(prolibPath);

                // for each subfolder in the .pl
                foreach (var plSubFolder in dicTempFolderToPl) {

                    var onePlSubFolderDeployments = onePlDeployments
                        .Where(deploy => plSubFolder.Key.Equals(Path.GetDirectoryName(deploy.ToTemp)))
                        .ToNonNullList();
                    if (onePlSubFolderDeployments.Count == 0)
                        continue;

                    Parallel.ForEach(onePlSubFolderDeployments, deploy => {
                        if (File.Exists(deploy.From))
                            deploy.IsOk = !string.IsNullOrEmpty(deploy.ToTemp) && Utils.MoveFile(deploy.From, deploy.ToTemp);
                        if (deploy.IsOk)
                            nbFilesDone[0]++;
                        if (onOneFileDone != null)
                            onOneFileDone(nbFilesDone[0]);
                    });

                    // now we just need to add the content of temp folders into the .pl
                    prolibExe.StartInfo.WorkingDirectory = plSubFolder.Value.Item1; // base temp dir
                    prolibExe.Arguments = plSubFolder.Value.Item3.ProQuoter() + " -create -nowarn -add " + Path.Combine(plSubFolder.Value.Item2, "*.r").ProQuoter();
                    if (!prolibExe.TryDoWait(true))
                        prolibMessage.Append(prolibExe.ErrorOutput);

                    Parallel.ForEach(onePlSubFolderDeployments, deploy => {
                        deploy.IsOk = deploy.IsOk && Utils.MoveFile(deploy.ToTemp, deploy.From);
                    });

                }

                // compress .pl
                prolibExe.StartInfo.WorkingDirectory = Path.GetDirectoryName(pl.Key);
                prolibExe.Arguments = pl.Key.ProQuoter() + " -compress -nowarn";
                if (!prolibExe.TryDoWait(true))
                    prolibMessage.Append(prolibExe.ErrorOutput);

                // delete temp folders
                Utils.DeleteDirectory(pl.Value, true);
            }

            if (prolibMessage.Length > 0)
                UserCommunication.Notify("Errors occured when trying to create/add files to the .pl file :<br>" + prolibMessage, MessageImg.MsgError, "Prolib output", "Errors");

            #endregion


            // do a deployment action for each file
            Parallel.ForEach(deployToDo, file => {
                if (DeploySingleFile(file))
                    nbFilesDone[0]++;
                if (onOneFileDone != null)
                    onOneFileDone(nbFilesDone[0]);
            });

            return deployToDo;
        }

        /// <summary>
        /// Transfer a single file
        /// </summary>
        private static bool DeploySingleFile(FileToDeploy file) {
            if (!file.IsOk) {
                if (File.Exists(file.From)) {
                    switch (file.DeployType) {

                        case DeployType.Copy:
                            file.IsOk = file.FinalDeploy ? Utils.MoveFile(file.From, file.To, true) : Utils.CopyFile(file.From, file.To);
                            break;

                        case DeployType.Ftp:
                            break;

                    }
                }
                return true;
            }
            return false;
        }

        #endregion

    }

    #region DeployRule

    public abstract class DeployRule {

        /// <summary>
        /// Step to which the rule applies : 0 = compilation, 1 = deployment of all files, 2+ = extra
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// This compilation path applies to a given application (can be empty)
        /// </summary>
        public string NameFilter { get; set; }

        /// <summary>
        /// This compilation path applies to a given Env letter (can be empty)
        /// </summary>
        public string SuffixFilter { get; set; }

    }

    public class DeployTransferRule : DeployRule {

        /// <summary>
        /// The type of transfer that should occur for this compilation path
        /// </summary>
        public DeployType Type { get; set; }

        /// <summary>
        /// if true, this should be the last rule applied to this file
        /// </summary>
        public bool ContinueAfterThisRule { get; set; }

        /// <summary>
        /// Pattern to match in the source path
        /// </summary>
        public string SourcePattern { get; set; }

        /// <summary>
        /// deploy target depending on the deploytype of this rule
        /// </summary>
        public string DeployTarget { get; set; }

        /// <summary>
        /// The line from which we read this info, allows to sort by line
        /// </summary>
        public int Line { get; set; }

    }

    public class DeployFilterRule : DeployRule {

        /// <summary>
        /// true if the rule is about including a file (+) false if about excluding (-)
        /// </summary>
        public bool Include { get; set; }

        /// <summary>
        /// Pattern to match in the source path
        /// </summary>
        public string SourcePattern { get; set; }
    }

    #endregion

    #region DeployType

    public enum DeployType {
        Prolib,
        Ftp,
        // Copy should always be last
        Copy,
    }

    #endregion

    #region DeployNeeded

    public class DeployNeeded {

        /// <summary>
        /// target directory for the deployment
        /// </summary>
        public string TargetDir { get; set; }

        /// <summary>
        /// Type de transfer
        /// </summary>
        public DeployType DeployType { get; set; }

        /// <summary>
        /// true if this is the last deploy action for the file
        /// </summary>
        public bool FinalDeploy { get; set; }

        public DeployNeeded(string targetDir, DeployType deployType, bool finalDeploy) {
            TargetDir = targetDir;
            DeployType = deployType;
            FinalDeploy = finalDeploy;
        }
    }

    #endregion

    #region FileToDeploy

    public class FileToDeploy {

        /// <summary>
        /// The path of input file that was originally compiled to trigger this move
        /// </summary>
        public string Origin { get; set; }

        public string From { get; set; }
        public string To { get; set; }

        /// <summary>
        /// true if the transfer went fine
        /// </summary>
        public bool IsOk { get; set; }

        /// <summary>
        /// Type de transfer
        /// </summary>
        public DeployType DeployType { get; set; }

        /// <summary>
        /// true if this is the last deploy action for the file
        /// </summary>
        public bool FinalDeploy { get; set; }

        #region for .pl deploy type

        /// <summary>
        /// Temporary folder in which to copy the file before including it into a .pl
        /// </summary>
        public string ToTemp { get; set; }

        /// <summary>
        /// Path to the .pl file in which we need to include this file
        /// </summary>
        public string PlPath { get; set; }

        #endregion

        public FileToDeploy(string origin, string @from, string to, DeployNeeded deployNeeded) {
            Origin = origin;
            From = @from;
            To = to;
            DeployType = deployNeeded.DeployType;
            FinalDeploy = deployNeeded.FinalDeploy;
        }
    }

    #endregion

}
