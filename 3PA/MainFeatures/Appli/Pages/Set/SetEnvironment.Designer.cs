﻿using System.ComponentModel;
using YamuiFramework.Controls;
using YamuiFramework.HtmlRenderer.WinForms;

namespace _3PA.MainFeatures.Appli.Pages.Set {
    partial class SetEnvironment {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.mainPanel = new YamuiFramework.Controls.YamuiPanel();
            this.btDeleteDownload = new YamuiFramework.Controls.YamuiImageButton();
            this.btDbDelete = new YamuiFramework.Controls.YamuiImageButton();
            this.btDbAdd = new YamuiFramework.Controls.YamuiImageButton();
            this.btDbEdit = new YamuiFramework.Controls.YamuiImageButton();
            this.htmlLabel7 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabel6 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabel5 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabel4 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabel3 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabel2 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.htmlLabel1 = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.lblLocally = new YamuiFramework.Controls.YamuiLabel();
            this.tgCompilLocl = new YamuiFramework.Controls.YamuiToggle();
            this.btDownload = new YamuiFramework.Controls.YamuiImageButton();
            this.btright6 = new YamuiFramework.Controls.YamuiImageButton();
            this.btleft6 = new YamuiFramework.Controls.YamuiImageButton();
            this.btright1 = new YamuiFramework.Controls.YamuiImageButton();
            this.btleft1 = new YamuiFramework.Controls.YamuiImageButton();
            this.btright5 = new YamuiFramework.Controls.YamuiImageButton();
            this.btleft5 = new YamuiFramework.Controls.YamuiImageButton();
            this.btright4 = new YamuiFramework.Controls.YamuiImageButton();
            this.btleft4 = new YamuiFramework.Controls.YamuiImageButton();
            this.btright3 = new YamuiFramework.Controls.YamuiImageButton();
            this.btleft3 = new YamuiFramework.Controls.YamuiImageButton();
            this.btright2 = new YamuiFramework.Controls.YamuiImageButton();
            this.btleft2 = new YamuiFramework.Controls.YamuiImageButton();
            this.yamuiLabel4 = new YamuiFramework.Controls.YamuiLabel();
            this.yamuiLabel1 = new YamuiFramework.Controls.YamuiLabel();
            this.txLabel = new YamuiFramework.HtmlRenderer.WinForms.HtmlLabel();
            this.toolTip = new YamuiFramework.HtmlRenderer.WinForms.HtmlToolTip();
            this.btDelete = new YamuiFramework.Controls.YamuiButton();
            this.btcontrol1 = new YamuiFramework.Controls.YamuiButton();
            this.btcontrol2 = new YamuiFramework.Controls.YamuiButton();
            this.textbox6 = new YamuiFramework.Controls.YamuiTextBox();
            this.flCmdLine = new YamuiFramework.Controls.YamuiTextBox();
            this.textbox5 = new YamuiFramework.Controls.YamuiTextBox();
            this.textbox4 = new YamuiFramework.Controls.YamuiTextBox();
            this.textbox3 = new YamuiFramework.Controls.YamuiTextBox();
            this.flExtraProPath = new YamuiFramework.Controls.YamuiTextBox();
            this.textbox2 = new YamuiFramework.Controls.YamuiTextBox();
            this.flExtraPf = new YamuiFramework.Controls.YamuiTextBox();
            this.textbox1 = new YamuiFramework.Controls.YamuiTextBox();
            this.cbDatabase = new YamuiFramework.Controls.YamuiComboBox();
            this.flDatabase = new YamuiFramework.Controls.YamuiTextBox();
            this.flLabel = new YamuiFramework.Controls.YamuiTextBox();
            this.cbSuffix = new YamuiFramework.Controls.YamuiComboBox();
            this.flSuffix = new YamuiFramework.Controls.YamuiTextBox();
            this.cbName = new YamuiFramework.Controls.YamuiComboBox();
            this.flName = new YamuiFramework.Controls.YamuiTextBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.flLabel);
            this.mainPanel.Controls.Add(this.textbox1);
            this.mainPanel.Controls.Add(this.flExtraPf);
            this.mainPanel.Controls.Add(this.textbox2);
            this.mainPanel.Controls.Add(this.flExtraProPath);
            this.mainPanel.Controls.Add(this.textbox3);
            this.mainPanel.Controls.Add(this.textbox4);
            this.mainPanel.Controls.Add(this.textbox5);
            this.mainPanel.Controls.Add(this.flCmdLine);
            this.mainPanel.Controls.Add(this.textbox6);
            this.mainPanel.Controls.Add(this.btcontrol2);
            this.mainPanel.Controls.Add(this.btcontrol1);
            this.mainPanel.Controls.Add(this.btDelete);
            this.mainPanel.Controls.Add(this.btDeleteDownload);
            this.mainPanel.Controls.Add(this.btDbDelete);
            this.mainPanel.Controls.Add(this.btDbAdd);
            this.mainPanel.Controls.Add(this.btDbEdit);
            this.mainPanel.Controls.Add(this.htmlLabel7);
            this.mainPanel.Controls.Add(this.htmlLabel6);
            this.mainPanel.Controls.Add(this.htmlLabel5);
            this.mainPanel.Controls.Add(this.htmlLabel4);
            this.mainPanel.Controls.Add(this.htmlLabel3);
            this.mainPanel.Controls.Add(this.htmlLabel2);
            this.mainPanel.Controls.Add(this.htmlLabel1);
            this.mainPanel.Controls.Add(this.lblLocally);
            this.mainPanel.Controls.Add(this.tgCompilLocl);
            this.mainPanel.Controls.Add(this.btDownload);
            this.mainPanel.Controls.Add(this.btright6);
            this.mainPanel.Controls.Add(this.btleft6);
            this.mainPanel.Controls.Add(this.btright1);
            this.mainPanel.Controls.Add(this.btleft1);
            this.mainPanel.Controls.Add(this.btright5);
            this.mainPanel.Controls.Add(this.btleft5);
            this.mainPanel.Controls.Add(this.btright4);
            this.mainPanel.Controls.Add(this.btleft4);
            this.mainPanel.Controls.Add(this.btright3);
            this.mainPanel.Controls.Add(this.btleft3);
            this.mainPanel.Controls.Add(this.btright2);
            this.mainPanel.Controls.Add(this.btleft2);
            this.mainPanel.Controls.Add(this.yamuiLabel4);
            this.mainPanel.Controls.Add(this.yamuiLabel1);
            this.mainPanel.Controls.Add(this.cbDatabase);
            this.mainPanel.Controls.Add(this.flDatabase);
            this.mainPanel.Controls.Add(this.txLabel);
            this.mainPanel.Controls.Add(this.cbSuffix);
            this.mainPanel.Controls.Add(this.flSuffix);
            this.mainPanel.Controls.Add(this.cbName);
            this.mainPanel.Controls.Add(this.flName);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.mainPanel.HorizontalScrollbarSize = 10;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(720, 550);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.VerticalScrollbarHighlightOnWheel = false;
            this.mainPanel.VerticalScrollbarSize = 10;
            // 
            // btDeleteDownload
            // 
            this.btDeleteDownload.BackColor = System.Drawing.Color.Transparent;
            this.btDeleteDownload.BackGrndImage = null;
            this.btDeleteDownload.Location = new System.Drawing.Point(588, 93);
            this.btDeleteDownload.Margin = new System.Windows.Forms.Padding(0);
            this.btDeleteDownload.Name = "btDeleteDownload";
            this.btDeleteDownload.Size = new System.Drawing.Size(20, 20);
            this.btDeleteDownload.TabIndex = 68;
            this.btDeleteDownload.TabStop = false;
            this.btDeleteDownload.Text = "yamuiImageButtonDB";
            // 
            // btDbDelete
            // 
            this.btDbDelete.BackGrndImage = null;
            this.btDbDelete.Location = new System.Drawing.Point(508, 93);
            this.btDbDelete.Name = "btDbDelete";
            this.btDbDelete.Size = new System.Drawing.Size(20, 20);
            this.btDbDelete.TabIndex = 67;
            this.btDbDelete.TabStop = false;
            this.btDbDelete.Text = "yamuiImageButton2";
            // 
            // btDbAdd
            // 
            this.btDbAdd.BackGrndImage = null;
            this.btDbAdd.Location = new System.Drawing.Point(489, 93);
            this.btDbAdd.Name = "btDbAdd";
            this.btDbAdd.Size = new System.Drawing.Size(20, 20);
            this.btDbAdd.TabIndex = 66;
            this.btDbAdd.TabStop = false;
            this.btDbAdd.Text = "yamuiImageButton2";
            // 
            // btDbEdit
            // 
            this.btDbEdit.BackGrndImage = null;
            this.btDbEdit.Location = new System.Drawing.Point(469, 93);
            this.btDbEdit.Name = "btDbEdit";
            this.btDbEdit.Size = new System.Drawing.Size(20, 20);
            this.btDbEdit.TabIndex = 65;
            this.btDbEdit.TabStop = false;
            this.btDbEdit.Text = "yamuiImageButton1";
            // 
            // htmlLabel7
            // 
            this.htmlLabel7.AutoSize = false;
            this.htmlLabel7.AutoSizeHeightOnly = true;
            this.htmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel7.BaseStylesheet = null;
            this.htmlLabel7.IsSelectionEnabled = false;
            this.htmlLabel7.Location = new System.Drawing.Point(30, 457);
            this.htmlLabel7.Name = "htmlLabel7";
            this.htmlLabel7.Size = new System.Drawing.Size(122, 15);
            this.htmlLabel7.TabIndex = 59;
            this.htmlLabel7.Text = "<b>Path to server.log file</b>";
            // 
            // htmlLabel6
            // 
            this.htmlLabel6.AutoSize = false;
            this.htmlLabel6.AutoSizeHeightOnly = true;
            this.htmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel6.BaseStylesheet = null;
            this.htmlLabel6.IsSelectionEnabled = false;
            this.htmlLabel6.Location = new System.Drawing.Point(30, 401);
            this.htmlLabel6.Name = "htmlLabel6";
            this.htmlLabel6.Size = new System.Drawing.Size(122, 30);
            this.htmlLabel6.TabIndex = 58;
            this.htmlLabel6.Text = "<b>Command line extra parameters</b>";
            // 
            // htmlLabel5
            // 
            this.htmlLabel5.AutoSize = false;
            this.htmlLabel5.AutoSizeHeightOnly = true;
            this.htmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel5.BaseStylesheet = null;
            this.htmlLabel5.IsSelectionEnabled = false;
            this.htmlLabel5.Location = new System.Drawing.Point(30, 370);
            this.htmlLabel5.Name = "htmlLabel5";
            this.htmlLabel5.Size = new System.Drawing.Size(122, 15);
            this.htmlLabel5.TabIndex = 57;
            this.htmlLabel5.Text = "<b>Prowin32.exe path</b>";
            // 
            // htmlLabel4
            // 
            this.htmlLabel4.AutoSize = false;
            this.htmlLabel4.AutoSizeHeightOnly = true;
            this.htmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel4.BaseStylesheet = null;
            this.htmlLabel4.IsSelectionEnabled = false;
            this.htmlLabel4.Location = new System.Drawing.Point(30, 316);
            this.htmlLabel4.Name = "htmlLabel4";
            this.htmlLabel4.Size = new System.Drawing.Size(122, 30);
            this.htmlLabel4.TabIndex = 56;
            this.htmlLabel4.Text = "<b>Compilation base directory</b>";
            // 
            // htmlLabel3
            // 
            this.htmlLabel3.AutoSize = false;
            this.htmlLabel3.AutoSizeHeightOnly = true;
            this.htmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel3.BaseStylesheet = null;
            this.htmlLabel3.IsSelectionEnabled = false;
            this.htmlLabel3.Location = new System.Drawing.Point(30, 284);
            this.htmlLabel3.Name = "htmlLabel3";
            this.htmlLabel3.Size = new System.Drawing.Size(122, 15);
            this.htmlLabel3.TabIndex = 55;
            this.htmlLabel3.Text = "<b>Project local directory</b>";
            // 
            // htmlLabel2
            // 
            this.htmlLabel2.AutoSize = false;
            this.htmlLabel2.AutoSizeHeightOnly = true;
            this.htmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel2.BaseStylesheet = null;
            this.htmlLabel2.IsSelectionEnabled = false;
            this.htmlLabel2.Location = new System.Drawing.Point(30, 203);
            this.htmlLabel2.Name = "htmlLabel2";
            this.htmlLabel2.Size = new System.Drawing.Size(122, 60);
            this.htmlLabel2.TabIndex = 54;
            this.htmlLabel2.Text = "<b>ProPath</b><br>Reads the value from the .ini file and adds the directories lis" +
    "ted";
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.AutoSizeHeightOnly = true;
            this.htmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel1.BaseStylesheet = null;
            this.htmlLabel1.IsSelectionEnabled = false;
            this.htmlLabel1.Location = new System.Drawing.Point(30, 102);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(122, 30);
            this.htmlLabel1.TabIndex = 53;
            this.htmlLabel1.Text = "<b>Database connection</b> informations";
            // 
            // lblLocally
            // 
            this.lblLocally.AutoSize = true;
            this.lblLocally.Function = YamuiFramework.Fonts.LabelFunction.Small;
            this.lblLocally.Location = new System.Drawing.Point(223, 339);
            this.lblLocally.Margin = new System.Windows.Forms.Padding(3);
            this.lblLocally.Name = "lblLocally";
            this.lblLocally.Size = new System.Drawing.Size(90, 12);
            this.lblLocally.TabIndex = 52;
            this.lblLocally.Text = "Compile files locally";
            this.lblLocally.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tgCompilLocl
            // 
            this.tgCompilLocl.AutoSize = true;
            this.tgCompilLocl.Location = new System.Drawing.Point(190, 338);
            this.tgCompilLocl.Name = "tgCompilLocl";
            this.tgCompilLocl.Size = new System.Drawing.Size(52, 15);
            this.tgCompilLocl.TabIndex = 49;
            this.tgCompilLocl.Text = " ";
            // 
            // btDownload
            // 
            this.btDownload.BackColor = System.Drawing.Color.Transparent;
            this.btDownload.BackGrndImage = null;
            this.btDownload.Location = new System.Drawing.Point(608, 93);
            this.btDownload.Margin = new System.Windows.Forms.Padding(0);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(20, 20);
            this.btDownload.TabIndex = 48;
            this.btDownload.TabStop = false;
            this.btDownload.Text = "yamuiImageButtonDB";
            this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
            // 
            // btright6
            // 
            this.btright6.BackColor = System.Drawing.Color.Transparent;
            this.btright6.BackGrndImage = null;
            this.btright6.Location = new System.Drawing.Point(631, 457);
            this.btright6.Margin = new System.Windows.Forms.Padding(0);
            this.btright6.Name = "btright6";
            this.btright6.Size = new System.Drawing.Size(20, 20);
            this.btright6.TabIndex = 45;
            this.btright6.TabStop = false;
            this.btright6.Text = "yamuiImageButton11";
            // 
            // btleft6
            // 
            this.btleft6.BackColor = System.Drawing.Color.Transparent;
            this.btleft6.BackGrndImage = null;
            this.btleft6.Location = new System.Drawing.Point(167, 457);
            this.btleft6.Margin = new System.Windows.Forms.Padding(0);
            this.btleft6.Name = "btleft6";
            this.btleft6.Size = new System.Drawing.Size(20, 20);
            this.btleft6.TabIndex = 44;
            this.btleft6.TabStop = false;
            this.btleft6.Text = "yamuiImageButton12";
            // 
            // btright1
            // 
            this.btright1.BackColor = System.Drawing.Color.Transparent;
            this.btright1.BackGrndImage = null;
            this.btright1.Location = new System.Drawing.Point(631, 120);
            this.btright1.Margin = new System.Windows.Forms.Padding(0);
            this.btright1.Name = "btright1";
            this.btright1.Size = new System.Drawing.Size(20, 20);
            this.btright1.TabIndex = 39;
            this.btright1.TabStop = false;
            this.btright1.Text = "yamuiImageButton9";
            // 
            // btleft1
            // 
            this.btleft1.BackColor = System.Drawing.Color.Transparent;
            this.btleft1.BackGrndImage = null;
            this.btleft1.Location = new System.Drawing.Point(167, 120);
            this.btleft1.Margin = new System.Windows.Forms.Padding(0);
            this.btleft1.Name = "btleft1";
            this.btleft1.Size = new System.Drawing.Size(20, 20);
            this.btleft1.TabIndex = 38;
            this.btleft1.TabStop = false;
            this.btleft1.Text = "yamuiImageButton10";
            // 
            // btright5
            // 
            this.btright5.BackColor = System.Drawing.Color.Transparent;
            this.btright5.BackGrndImage = null;
            this.btright5.Location = new System.Drawing.Point(631, 370);
            this.btright5.Margin = new System.Windows.Forms.Padding(0);
            this.btright5.Name = "btright5";
            this.btright5.Size = new System.Drawing.Size(20, 20);
            this.btright5.TabIndex = 36;
            this.btright5.TabStop = false;
            this.btright5.Text = "yamuiImageButton7";
            // 
            // btleft5
            // 
            this.btleft5.BackColor = System.Drawing.Color.Transparent;
            this.btleft5.BackGrndImage = null;
            this.btleft5.Location = new System.Drawing.Point(167, 370);
            this.btleft5.Margin = new System.Windows.Forms.Padding(0);
            this.btleft5.Name = "btleft5";
            this.btleft5.Size = new System.Drawing.Size(20, 20);
            this.btleft5.TabIndex = 35;
            this.btleft5.TabStop = false;
            this.btleft5.Text = "yamuiImageButton8";
            // 
            // btright4
            // 
            this.btright4.BackColor = System.Drawing.Color.Transparent;
            this.btright4.BackGrndImage = null;
            this.btright4.Location = new System.Drawing.Point(631, 315);
            this.btright4.Margin = new System.Windows.Forms.Padding(0);
            this.btright4.Name = "btright4";
            this.btright4.Size = new System.Drawing.Size(20, 20);
            this.btright4.TabIndex = 33;
            this.btright4.TabStop = false;
            this.btright4.Text = "yamuiImageButton5";
            // 
            // btleft4
            // 
            this.btleft4.BackColor = System.Drawing.Color.Transparent;
            this.btleft4.BackGrndImage = null;
            this.btleft4.Location = new System.Drawing.Point(167, 315);
            this.btleft4.Margin = new System.Windows.Forms.Padding(0);
            this.btleft4.Name = "btleft4";
            this.btleft4.Size = new System.Drawing.Size(20, 20);
            this.btleft4.TabIndex = 32;
            this.btleft4.TabStop = false;
            this.btleft4.Text = "yamuiImageButton6";
            // 
            // btright3
            // 
            this.btright3.BackColor = System.Drawing.Color.Transparent;
            this.btright3.BackGrndImage = null;
            this.btright3.Location = new System.Drawing.Point(631, 284);
            this.btright3.Margin = new System.Windows.Forms.Padding(0);
            this.btright3.Name = "btright3";
            this.btright3.Size = new System.Drawing.Size(20, 20);
            this.btright3.TabIndex = 30;
            this.btright3.TabStop = false;
            this.btright3.Text = "yamuiImageButton3";
            // 
            // btleft3
            // 
            this.btleft3.BackColor = System.Drawing.Color.Transparent;
            this.btleft3.BackGrndImage = null;
            this.btleft3.Location = new System.Drawing.Point(167, 284);
            this.btleft3.Margin = new System.Windows.Forms.Padding(0);
            this.btleft3.Name = "btleft3";
            this.btleft3.Size = new System.Drawing.Size(20, 20);
            this.btleft3.TabIndex = 29;
            this.btleft3.TabStop = false;
            this.btleft3.Text = "yamuiImageButton4";
            // 
            // btright2
            // 
            this.btright2.BackColor = System.Drawing.Color.Transparent;
            this.btright2.BackGrndImage = null;
            this.btright2.Location = new System.Drawing.Point(631, 202);
            this.btright2.Margin = new System.Windows.Forms.Padding(0);
            this.btright2.Name = "btright2";
            this.btright2.Size = new System.Drawing.Size(20, 20);
            this.btright2.TabIndex = 27;
            this.btright2.TabStop = false;
            this.btright2.Text = "yamuiImageButton2";
            // 
            // btleft2
            // 
            this.btleft2.BackColor = System.Drawing.Color.Transparent;
            this.btleft2.BackGrndImage = null;
            this.btleft2.Location = new System.Drawing.Point(167, 202);
            this.btleft2.Margin = new System.Windows.Forms.Padding(0);
            this.btleft2.Name = "btleft2";
            this.btleft2.Size = new System.Drawing.Size(20, 20);
            this.btleft2.TabIndex = 26;
            this.btleft2.TabStop = false;
            this.btleft2.Text = "yamuiImageButton1";
            // 
            // yamuiLabel4
            // 
            this.yamuiLabel4.AutoSize = true;
            this.yamuiLabel4.Function = YamuiFramework.Fonts.LabelFunction.Heading;
            this.yamuiLabel4.Location = new System.Drawing.Point(0, 67);
            this.yamuiLabel4.Margin = new System.Windows.Forms.Padding(5, 18, 5, 7);
            this.yamuiLabel4.Name = "yamuiLabel4";
            this.yamuiLabel4.Size = new System.Drawing.Size(63, 19);
            this.yamuiLabel4.TabIndex = 7;
            this.yamuiLabel4.Text = "DETAILS";
            // 
            // yamuiLabel1
            // 
            this.yamuiLabel1.AutoSize = true;
            this.yamuiLabel1.Function = YamuiFramework.Fonts.LabelFunction.Heading;
            this.yamuiLabel1.Location = new System.Drawing.Point(0, 0);
            this.yamuiLabel1.Margin = new System.Windows.Forms.Padding(5, 18, 5, 7);
            this.yamuiLabel1.Name = "yamuiLabel1";
            this.yamuiLabel1.Size = new System.Drawing.Size(81, 19);
            this.yamuiLabel1.TabIndex = 2;
            this.yamuiLabel1.Text = "SELECTION";
            // 
            // txLabel
            // 
            this.txLabel.AutoSize = false;
            this.txLabel.AutoSizeHeightOnly = true;
            this.txLabel.BackColor = System.Drawing.Color.Transparent;
            this.txLabel.BaseStylesheet = null;
            this.txLabel.Location = new System.Drawing.Point(269, 28);
            this.txLabel.Name = "txLabel";
            this.txLabel.Size = new System.Drawing.Size(446, 15);
            this.txLabel.TabIndex = 41;
            this.txLabel.TabStop = false;
            this.txLabel.Text = "?";
            // 
            // toolTip
            // 
            this.toolTip.AllowLinksHandling = true;
            this.toolTip.AutomaticDelay = 100;
            this.toolTip.AutoPopDelay = 90000;
            this.toolTip.BaseStylesheet = null;
            this.toolTip.InitialDelay = 100;
            this.toolTip.MaximumSize = new System.Drawing.Size(0, 0);
            this.toolTip.OwnerDraw = true;
            this.toolTip.ReshowDelay = 20;
            this.toolTip.TooltipCssClass = "htmltooltip";
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Location = new System.Drawing.Point(621, 524);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(94, 23);
            this.btDelete.TabIndex = 69;
            this.btDelete.Text = "Delete";
            // 
            // btcontrol1
            // 
            this.btcontrol1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btcontrol1.Location = new System.Drawing.Point(521, 524);
            this.btcontrol1.Name = "btcontrol1";
            this.btcontrol1.Size = new System.Drawing.Size(94, 23);
            this.btcontrol1.TabIndex = 70;
            this.btcontrol1.Text = "Add new";
            // 
            // btcontrol2
            // 
            this.btcontrol2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btcontrol2.Location = new System.Drawing.Point(421, 524);
            this.btcontrol2.Name = "btcontrol2";
            this.btcontrol2.Size = new System.Drawing.Size(94, 23);
            this.btcontrol2.TabIndex = 71;
            this.btcontrol2.Text = "Modify";
            // 
            // textbox6
            // 
            this.textbox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textbox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox6.CustomBackColor = System.Drawing.Color.Empty;
            this.textbox6.CustomForeColor = System.Drawing.Color.Empty;
            this.textbox6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textbox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textbox6.Location = new System.Drawing.Point(190, 457);
            this.textbox6.Name = "textbox6";
            this.textbox6.Size = new System.Drawing.Size(438, 20);
            this.textbox6.TabIndex = 72;
            this.textbox6.Tag = "log file (*.log)|*.log";
            this.textbox6.WaterMark = null;
            // 
            // flCmdLine
            // 
            this.flCmdLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flCmdLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flCmdLine.CustomBackColor = System.Drawing.Color.Empty;
            this.flCmdLine.CustomForeColor = System.Drawing.Color.Empty;
            this.flCmdLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flCmdLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flCmdLine.Location = new System.Drawing.Point(190, 401);
            this.flCmdLine.MultiLines = true;
            this.flCmdLine.Name = "flCmdLine";
            this.flCmdLine.Size = new System.Drawing.Size(438, 45);
            this.flCmdLine.TabIndex = 73;
            this.flCmdLine.WaterMark = "Appended to the prowin command line when running or compiling";
            // 
            // textbox5
            // 
            this.textbox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textbox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox5.CustomBackColor = System.Drawing.Color.Empty;
            this.textbox5.CustomForeColor = System.Drawing.Color.Empty;
            this.textbox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textbox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textbox5.Location = new System.Drawing.Point(190, 370);
            this.textbox5.Name = "textbox5";
            this.textbox5.Size = new System.Drawing.Size(438, 20);
            this.textbox5.TabIndex = 74;
            this.textbox5.Tag = "prowin32 (*.exe)|*.exe";
            this.textbox5.WaterMark = null;
            // 
            // textbox4
            // 
            this.textbox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textbox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox4.CustomBackColor = System.Drawing.Color.Empty;
            this.textbox4.CustomForeColor = System.Drawing.Color.Empty;
            this.textbox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textbox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textbox4.Location = new System.Drawing.Point(190, 315);
            this.textbox4.Name = "textbox4";
            this.textbox4.Size = new System.Drawing.Size(438, 20);
            this.textbox4.TabIndex = 75;
            this.textbox4.Tag = "true";
            this.textbox4.WaterMark = null;
            // 
            // textbox3
            // 
            this.textbox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textbox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox3.CustomBackColor = System.Drawing.Color.Empty;
            this.textbox3.CustomForeColor = System.Drawing.Color.Empty;
            this.textbox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textbox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textbox3.Location = new System.Drawing.Point(190, 284);
            this.textbox3.Name = "textbox3";
            this.textbox3.Size = new System.Drawing.Size(438, 20);
            this.textbox3.TabIndex = 76;
            this.textbox3.Tag = "true";
            this.textbox3.WaterMark = null;
            // 
            // flExtraProPath
            // 
            this.flExtraProPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flExtraProPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flExtraProPath.CustomBackColor = System.Drawing.Color.Empty;
            this.flExtraProPath.CustomForeColor = System.Drawing.Color.Empty;
            this.flExtraProPath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flExtraProPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flExtraProPath.Location = new System.Drawing.Point(190, 228);
            this.flExtraProPath.MultiLines = true;
            this.flExtraProPath.Name = "flExtraProPath";
            this.flExtraProPath.Size = new System.Drawing.Size(438, 45);
            this.flExtraProPath.TabIndex = 77;
            this.flExtraProPath.WaterMark = "Appended to the .ini PROPATH (comma separated list)";
            // 
            // textbox2
            // 
            this.textbox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox2.CustomBackColor = System.Drawing.Color.Empty;
            this.textbox2.CustomForeColor = System.Drawing.Color.Empty;
            this.textbox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textbox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textbox2.Location = new System.Drawing.Point(190, 203);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(438, 20);
            this.textbox2.TabIndex = 78;
            this.textbox2.Tag = "ini file (*.ini)|*.ini";
            this.textbox2.WaterMark = null;
            // 
            // flExtraPf
            // 
            this.flExtraPf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flExtraPf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flExtraPf.CustomBackColor = System.Drawing.Color.Empty;
            this.flExtraPf.CustomForeColor = System.Drawing.Color.Empty;
            this.flExtraPf.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flExtraPf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flExtraPf.Location = new System.Drawing.Point(190, 146);
            this.flExtraPf.MultiLines = true;
            this.flExtraPf.Name = "flExtraPf";
            this.flExtraPf.Size = new System.Drawing.Size(438, 45);
            this.flExtraPf.TabIndex = 79;
            this.flExtraPf.WaterMark = "Extra connection info";
            // 
            // textbox1
            // 
            this.textbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox1.CustomBackColor = System.Drawing.Color.Empty;
            this.textbox1.CustomForeColor = System.Drawing.Color.Empty;
            this.textbox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textbox1.Location = new System.Drawing.Point(190, 120);
            this.textbox1.Name = "textbox1";
            this.textbox1.Size = new System.Drawing.Size(438, 20);
            this.textbox1.TabIndex = 80;
            this.textbox1.Tag = "pf file (*.pf)|*.pf";
            this.textbox1.WaterMark = "Path to your .pf file (containing database connection info)";
            // 
            // cbDatabase
            // 
            this.cbDatabase.ItemHeight = 15;
            this.cbDatabase.Location = new System.Drawing.Point(190, 93);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(273, 21);
            this.cbDatabase.TabIndex = 81;
            // 
            // flDatabase
            // 
            this.flDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flDatabase.CustomBackColor = System.Drawing.Color.Empty;
            this.flDatabase.CustomForeColor = System.Drawing.Color.Empty;
            this.flDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flDatabase.Location = new System.Drawing.Point(190, 93);
            this.flDatabase.Name = "flDatabase";
            this.flDatabase.Size = new System.Drawing.Size(273, 21);
            this.flDatabase.TabIndex = 82;
            this.flDatabase.WaterMark = "Set a name for this database connection";
            // 
            // flLabel
            // 
            this.flLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flLabel.CustomBackColor = System.Drawing.Color.Empty;
            this.flLabel.CustomForeColor = System.Drawing.Color.Empty;
            this.flLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flLabel.Location = new System.Drawing.Point(262, 25);
            this.flLabel.Name = "flLabel";
            this.flLabel.Size = new System.Drawing.Size(453, 21);
            this.flLabel.TabIndex = 83;
            this.flLabel.WaterMark = "Label for this environment";
            // 
            // cbSuffix
            // 
            this.cbSuffix.ItemHeight = 15;
            this.cbSuffix.Location = new System.Drawing.Point(205, 25);
            this.cbSuffix.Name = "cbSuffix";
            this.cbSuffix.Size = new System.Drawing.Size(51, 21);
            this.cbSuffix.TabIndex = 84;
            // 
            // flSuffix
            // 
            this.flSuffix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flSuffix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flSuffix.CustomBackColor = System.Drawing.Color.Empty;
            this.flSuffix.CustomForeColor = System.Drawing.Color.Empty;
            this.flSuffix.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flSuffix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flSuffix.Location = new System.Drawing.Point(205, 25);
            this.flSuffix.Name = "flSuffix";
            this.flSuffix.Size = new System.Drawing.Size(51, 21);
            this.flSuffix.TabIndex = 85;
            this.flSuffix.WaterMark = "Suffix";
            // 
            // cbName
            // 
            this.cbName.ItemHeight = 15;
            this.cbName.Location = new System.Drawing.Point(30, 25);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(169, 21);
            this.cbName.TabIndex = 86;
            // 
            // flName
            // 
            this.flName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.flName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flName.CustomBackColor = System.Drawing.Color.Empty;
            this.flName.CustomForeColor = System.Drawing.Color.Empty;
            this.flName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.flName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.flName.Location = new System.Drawing.Point(30, 25);
            this.flName.Name = "flName";
            this.flName.Size = new System.Drawing.Size(169, 21);
            this.flName.TabIndex = 87;
            this.flName.WaterMark = "Application name";
            // 
            // SetEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "SetEnvironment";
            this.Size = new System.Drawing.Size(720, 550);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private YamuiPanel mainPanel;
        private YamuiLabel yamuiLabel1;
        private YamuiLabel yamuiLabel4;
        private YamuiImageButton btright2;
        private YamuiImageButton btleft2;
        private YamuiImageButton btright1;
        private YamuiImageButton btleft1;
        private YamuiImageButton btright5;
        private YamuiImageButton btleft5;
        private YamuiImageButton btright4;
        private YamuiImageButton btleft4;
        private YamuiImageButton btright3;
        private YamuiImageButton btleft3;
        private HtmlLabel txLabel;
        private YamuiImageButton btright6;
        private YamuiImageButton btleft6;
        private HtmlToolTip toolTip;
        private YamuiImageButton btDownload;
        private YamuiToggle tgCompilLocl;
        private YamuiLabel lblLocally;
        private HtmlLabel htmlLabel1;
        private HtmlLabel htmlLabel2;
        private HtmlLabel htmlLabel3;
        private HtmlLabel htmlLabel4;
        private HtmlLabel htmlLabel5;
        private HtmlLabel htmlLabel6;
        private HtmlLabel htmlLabel7;
        private YamuiImageButton btDbAdd;
        private YamuiImageButton btDbEdit;
        private YamuiImageButton btDbDelete;
        private YamuiImageButton btDeleteDownload;
        private YamuiTextBox textbox1;
        private YamuiTextBox flExtraPf;
        private YamuiTextBox textbox2;
        private YamuiTextBox flExtraProPath;
        private YamuiTextBox textbox3;
        private YamuiTextBox textbox4;
        private YamuiTextBox textbox5;
        private YamuiTextBox flCmdLine;
        private YamuiTextBox textbox6;
        private YamuiButton btcontrol2;
        private YamuiButton btcontrol1;
        private YamuiButton btDelete;
        private YamuiComboBox cbDatabase;
        private YamuiTextBox flDatabase;
        private YamuiTextBox flLabel;
        private YamuiComboBox cbSuffix;
        private YamuiTextBox flSuffix;
        private YamuiComboBox cbName;
        private YamuiTextBox flName;
    }
}