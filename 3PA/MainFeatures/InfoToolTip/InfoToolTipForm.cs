﻿#region header
// ========================================================================
// Copyright (c) 2016 - Julien Caillon (julien.caillon@gmail.com)
// This file (InfoToolTipForm.cs) is part of 3P.
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
using System.Drawing;
using System.Windows.Forms;
using YamuiFramework.Controls;
using YamuiFramework.HtmlRenderer.Core.Core.Entities;
using YamuiFramework.HtmlRenderer.WinForms;

namespace _3PA.MainFeatures.InfoToolTip {

    internal sealed class InfoToolTipForm : NppInterfaceForm.NppInterfaceForm {

        #region fields
        // prevents the form from stealing the focus
        //protected override bool ShowWithoutActivation {
        //    get { return true; }
        //}

        private static int _positionMode;
        private static Point _position;
        private static int _lineHeight;
        private static Rectangle _rect;
        private static bool _reversed;

        private YamuiScrollPanel _panel;
        private HtmlLabel _labelContent;

        #endregion

        #region constructor
        public InfoToolTipForm() {

            Padding = new Padding(5);

            // add scroll page
            _panel = new YamuiScrollPanel {
                Dock = DockStyle.Fill,
                NoBackgroundImage = true
            };
            Controls.Add(_panel);

            // add label
            _labelContent = new HtmlLabel {
                AutoSizeHeightOnly = true,
                Location = new Point(0, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            _panel.ContentPanel.Location = new Point(0, 0);
            _panel.ContentPanel.Controls.Add(_labelContent);

            Size = new Size(50, 50);
        }
        #endregion

        #region public

        /// <summary>
        /// set the html of the label, resize the tooltip
        /// </summary>
        /// <param name="content"></param>
        /// <param name="minimumWidth"></param>
        public void SetText(string content, int minimumWidth = 200) {

            if (Visible)
                Cloack();

            var screen = Npp.NppScreen;

            _labelContent.SetNeededSize(content, minimumWidth, screen.WorkingArea.Width / 2 - 20);

            _panel.ContentPanel.Size = _labelContent.Size;
            Size = new Size(_panel.ContentPanel.Width + 10, Math.Min(_labelContent.Height, screen.WorkingArea.Height / 2 - 10) + 10);

            // Too tall?
            if (_labelContent.Height > (screen.WorkingArea.Height / 2 - 10)) {
                Width = Width + 10; // add scrollbar width
            }
        }

        /// <summary>
        /// Position the tooltip relatively to a point
        /// </summary>
        /// <param name="position"></param>
        /// <param name="lineHeight"></param>
        public void SetPosition(Point position, int lineHeight) {
            _positionMode = 0;
            _position = position;
            _lineHeight = lineHeight;

            var screen = Screen.FromPoint(position);

            // position the window smartly
            if (position.X > screen.WorkingArea.X + screen.WorkingArea.Width / 2)
                position.X = position.X - Width;
            if (position.Y > screen.WorkingArea.Y + screen.WorkingArea.Height / 2)
                position.Y = position.Y - Height - lineHeight;
            Location = position;
        }

        /// <summary>
        /// Position the tooltip relatively to the autocompletion form (represented by a rectangle)
        /// reversed = true if the autocompletion is ABOVE the text it completes
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="reversed"></param>
        public void SetPosition(Rectangle rect, bool reversed) {
            _positionMode = 1;
            _rect = rect;
            _reversed = reversed;

            var screen = Screen.FromPoint(rect.Location);

            var position = new Point(0, 0);
            // position the window smartly
            if (reversed)
                position.Y = (rect.Y + rect.Height) - Height;
            else
                position.Y = rect.Y;

            if (rect.X > (screen.WorkingArea.Width - (rect.X + rect.Width)))
                position.X = rect.X - Width;
            else
                position.X = rect.X + rect.Width;
            Location = position;
        }

        /// <summary>
        /// Reposition the tooltip with the last SetPosition method called
        /// </summary>
        public void SetPosition() {
            if (_positionMode == 1)
                SetPosition(_rect, _reversed);
            else
                SetPosition(_position, _lineHeight);
        }

        /// <summary>
        /// Sets the link clicked event for the label
        /// </summary>
        /// <param name="clickHandler"></param>
        public void SetLinkClickedEvent(Action<HtmlLinkClickedEventArgs> clickHandler) {
            _labelContent.LinkClicked += (sender, args) => clickHandler(args);
        }
        #endregion

    }
}
