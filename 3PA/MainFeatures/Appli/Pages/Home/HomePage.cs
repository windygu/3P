﻿#region header
// ========================================================================
// Copyright (c) 2015 - Julien Caillon (julien.caillon@gmail.com)
// This file (PageAbout.cs) is part of 3P.
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
using YamuiFramework.Controls;
using YamuiFramework.HtmlRenderer.Core.Core.Entities;
using _3PA.Html;
using _3PA.Lib;

namespace _3PA.MainFeatures.Appli.Pages.Home {
    public partial class HomePage : YamuiPage {

        #region fields

        #endregion

        #region constructor
        public HomePage() {
            InitializeComponent();

            html.Text = HtmlResources.home.Replace("%version%", AssemblyInfo.Version).Replace("%disclaimer%", AssemblyInfo.IsPreRelease ? HtmlResources.disclaimer : "");

            html.LinkClicked += HtmlOnLinkClicked;
        }

        private void HtmlOnLinkClicked(object sender, HtmlLinkClickedEventArgs htmlLinkClickedEventArgs) {
            if (htmlLinkClickedEventArgs.Link.Equals("update")) {
                if (!Utils.IsSpamming("updates", 1000)) {
                    UserCommunication.Notify("Now checking for updates, you will be notified when it's done", MessageImg.MsgInfo, "Update", "Update check", 5);
                    UpdateHandler.GetLatestReleaseInfo(true);
                }
                htmlLinkClickedEventArgs.Handled = true;
            }
        }

        #endregion

    }
}