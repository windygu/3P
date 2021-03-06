﻿#region header
// ========================================================================
// Copyright (c) 2016 - Julien Caillon (julien.caillon@gmail.com)
// This file (SetCompilationPath.cs) is part of 3P.
// 
// 3P is a free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// 3P is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with 3P. If not, see <http://www.gnu.org/licenses/>.
// ========================================================================
#endregion
using System;
using System.IO;
using YamuiFramework.Controls;
using _3PA.Data;
using _3PA.Images;
using _3PA.Lib;
using _3PA.MainFeatures.Pro;

namespace _3PA.MainFeatures.Appli.Pages.Set {
    internal partial class SetDeploymentRules : YamuiPage {

        #region fields

        #endregion

        #region constructor

        public SetDeploymentRules() {
            InitializeComponent();

            // tooltips
            bt_import.BackGrndImage = ImageResources.Import;
            toolTip.SetToolTip(bt_import, "Click this button to <b>import</b> the last changes made to the file");

            bt_modify.BackGrndImage = ImageResources.Rules;
            toolTip.SetToolTip(bt_modify, "Click to modify the deployment rules through Notepad++");

            bt_import.ButtonPressed += (sender, args) => {
                Deployer.Import();
                UpdateList();
            };
            bt_modify.ButtonPressed += (sender, args) => Deployer.EditRules();

            linkurl.Text = @"<img src='Help'><a href='" + Config.UrlHelpDeployRules + @"'>Learn more about this feature?</a>";

            Deployer.OnDeployConfigurationUpdate += UpdateList;

            // dynamically reorder the controls for a correct tab order on notepad++
            SetTabOrder.RemoveAndAddForTabOrder(scrollPanel);
        }

        #endregion

        #region On show

        public override void OnShow() {
            UpdateList();
        }

        #endregion

        #region private methods

        private void UpdateList() {
            // build the html
            html_list.Text = Deployer.BuildHtmlTableForRules(Deployer.GetFullDeployRulesList);

            scrollPanel.ContentPanel.Height = html_list.Location.Y + html_list.Height;
            scrollPanel.OnResizedContentPanel();
        }

        #endregion

    }
}
