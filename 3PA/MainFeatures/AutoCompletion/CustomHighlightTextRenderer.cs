﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BrightIdeasSoftware;
using YamuiFramework.Themes;

namespace _3PA.MainFeatures.AutoCompletion {

    /// <summary>
    /// This renderer highlights substrings that match a given text filter. 
    /// </summary>
    public class CustomHighlightTextRenderer : BaseRenderer {
        #region Life and death

        /// <summary>
        /// Create a HighlightTextRenderer
        /// </summary>
        public CustomHighlightTextRenderer() {
            FillBrush = new SolidBrush(ThemeManager.Current.AutoCompletionHighlightBack);
            FramePen = new Pen(ThemeManager.Current.AutoCompletionHighlightBorder);
        }

        /// <summary>
        /// Create a HighlightTextRenderer
        /// </summary>
        public CustomHighlightTextRenderer(ObjectListView fastOvl, string filterStr)
            : this() {
            Filter = new TextMatchFilter(fastOvl, filterStr, StringComparison.OrdinalIgnoreCase);
        }
        #endregion

        #region Configuration properties

        /// <summary>
        /// Gets or set how rounded will be the corners of the text match frame
        /// </summary>
        [Category("Appearance"),
         DefaultValue(3.0f),
         Description("How rounded will be the corners of the text match frame?")]
        public float CornerRoundness {
            get { return _cornerRoundness; }
            set { _cornerRoundness = value; }
        }

        private float _cornerRoundness = 4.0f;

        /// <summary>
        /// Gets or set the brush will be used to paint behind the matched substrings.
        /// Set this to null to not fill the frame.
        /// </summary>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Brush FillBrush {
            get { return _fillBrush; }
            set { _fillBrush = value; }
        }

        private Brush _fillBrush;

        /// <summary>
        /// Gets or sets the filter that is filtering the ObjectListView and for
        /// which this renderer should highlight text
        /// </summary>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TextMatchFilter Filter {
            get { return _filter; }
            set { _filter = value; }
        }

        private TextMatchFilter _filter;

        /// <summary>
        /// Gets or set the pen will be used to frame the matched substrings.
        /// Set this to null to not draw a frame.
        /// </summary>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Pen FramePen {
            get { return _framePen; }
            set { _framePen = value; }
        }

        private Pen _framePen;

        /// <summary>
        /// Gets or sets whether the frame around a text match will have rounded corners
        /// </summary>
        [Category("Appearance"),
         DefaultValue(true),
         Description("Will the frame around a text match will have rounded corners?")]
        public bool UseRoundedRectangle {
            get { return _useRoundedRectangle; }
            set { _useRoundedRectangle = value; }
        }

        private bool _useRoundedRectangle = true;

        #endregion

        #region IRenderer interface overrides

        /// <summary>
        /// Handle a HitTest request after all state information has been initialized
        /// </summary>
        /// <param name="g"></param>
        /// <param name="cellBounds"></param>
        /// <param name="item"></param>
        /// <param name="subItemIndex"></param>
        /// <param name="preferredSize"> </param>
        /// <returns></returns>
        protected override Rectangle HandleGetEditRectangle(Graphics g, Rectangle cellBounds, OLVListItem item, int subItemIndex, Size preferredSize) {
            return StandardGetEditRectangle(g, cellBounds, preferredSize);
        }

        #endregion

        #region Rendering

        // This class has two implement two highlighting schemes: one for GDI, another for GDI+.
        // Naturally, GDI+ makes the task easier, but we have to provide something for GDI
        // since that it is what is normally used.

        /// <summary>
        /// Draw text using GDI
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        /// <param name="txt"></param>
        protected override void DrawTextGdi(Graphics g, Rectangle r, string txt) {
            if (ShouldDrawHighlighting)
                DrawGdiTextHighlighting(g, r, txt);

            base.DrawTextGdi(g, r, txt);
        }

        /// <summary>
        /// Draw the highlighted text using GDI
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        /// <param name="txt"></param>
        protected virtual void DrawGdiTextHighlighting(Graphics g, Rectangle r, string txt) {
            TextFormatFlags flags = TextFormatFlags.NoPrefix |
                                    TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsTranslateTransform;

            // TextRenderer puts horizontal padding around the strings, so we need to take
            // that into account when measuring strings
            int paddingAdjustment = 6;

            // Cache the font
            Font f = Font;

            foreach (CharacterRange range in Filter.FindAllMatchedRanges(txt)) {
                // Measure the text that comes before our substring
                Size precedingTextSize = Size.Empty;
                if (range.First > 0) {
                    string precedingText = txt.Substring(0, range.First);
                    precedingTextSize = TextRenderer.MeasureText(g, precedingText, f, r.Size, flags);
                    precedingTextSize.Width -= paddingAdjustment;
                }

                // Measure the length of our substring (may be different each time due to case differences)
                string highlightText = txt.Substring(range.First, range.Length);
                Size textToHighlightSize = TextRenderer.MeasureText(g, highlightText, f, r.Size, flags);
                textToHighlightSize.Width -= paddingAdjustment;

                float textToHighlightLeft = r.X + precedingTextSize.Width + 1;
                float textToHighlightTop = AlignVertically(r, textToHighlightSize.Height);

                // Draw a filled frame around our substring
                DrawSubstringFrame(g, textToHighlightLeft, textToHighlightTop, textToHighlightSize.Width, textToHighlightSize.Height);
            }
        }

        /// <summary>
        /// Draw an indication around the given frame that shows a text match
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        protected virtual void DrawSubstringFrame(Graphics g, float x, float y, float width, float height) {
            if (UseRoundedRectangle) {
                using (GraphicsPath path = GetRoundedRect(x, y, width, height, 3.0f)) {
                    if (FillBrush != null)
                        g.FillPath(FillBrush, path);
                    if (FramePen != null)
                        g.DrawPath(FramePen, path);
                }
            } else {
                if (FillBrush != null)
                    g.FillRectangle(FillBrush, x, y, width, height);
                if (FramePen != null)
                    g.DrawRectangle(FramePen, x, y, width, height);
            }
        }

        /// <summary>
        /// Draw the text using GDI+
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        /// <param name="txt"></param>
        protected override void DrawTextGdiPlus(Graphics g, Rectangle r, string txt) {
            if (ShouldDrawHighlighting)
                DrawGdiPlusTextHighlighting(g, r, txt);

            base.DrawTextGdiPlus(g, r, txt);
        }

        /// <summary>
        /// Draw the highlighted text using GDI+
        /// </summary>
        /// <param name="g"></param>
        /// <param name="r"></param>
        /// <param name="txt"></param>
        protected virtual void DrawGdiPlusTextHighlighting(Graphics g, Rectangle r, string txt) {
            // Find the substrings we want to highlight
            List<CharacterRange> ranges = new List<CharacterRange>(Filter.FindAllMatchedRanges(txt));

            if (ranges.Count == 0)
                return;

            using (StringFormat fmt = StringFormatForGdiPlus) {
                RectangleF rf = r;
                fmt.SetMeasurableCharacterRanges(ranges.ToArray());
                Region[] stringRegions = g.MeasureCharacterRanges(txt, Font, rf, fmt);

                foreach (Region region in stringRegions) {
                    RectangleF bounds = region.GetBounds(g);
                    DrawSubstringFrame(g, bounds.X - 1, bounds.Y - 1, bounds.Width + 2, bounds.Height);
                }
            }
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Gets whether the renderer should actually draw highlighting
        /// </summary>
        protected bool ShouldDrawHighlighting {
            get { return Column == null || (Column.Searchable); }
        }

        /// <summary>
        /// Return a GraphicPath that is a round cornered rectangle
        /// </summary>
        /// <returns>A round cornered rectagle path</returns>
        /// <remarks>If I could rely on people using C# 3.0+, this should be
        /// an extension method of GraphicsPath.</remarks>        
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="diameter"></param>
        protected GraphicsPath GetRoundedRect(float x, float y, float width, float height, float diameter) {
            return GetRoundedRect(new RectangleF(x, y, width, height), diameter);
        }

        /// <summary>
        /// Return a GraphicPath that is a round cornered rectangle
        /// </summary>
        /// <param name="rect">The rectangle</param>
        /// <param name="diameter">The diameter of the corners</param>
        /// <returns>A round cornered rectagle path</returns>
        /// <remarks>If I could rely on people using C# 3.0+, this should be
        /// an extension method of GraphicsPath.</remarks>
        protected GraphicsPath GetRoundedRect(RectangleF rect, float diameter) {
            GraphicsPath path = new GraphicsPath();

            if (diameter > 0) {
                RectangleF arc = new RectangleF(rect.X, rect.Y, diameter, diameter);
                path.AddArc(arc, 180, 90);
                arc.X = rect.Right - diameter;
                path.AddArc(arc, 270, 90);
                arc.Y = rect.Bottom - diameter;
                path.AddArc(arc, 0, 90);
                arc.X = rect.Left;
                path.AddArc(arc, 90, 90);
                path.CloseFigure();
            } else {
                path.AddRectangle(rect);
            }

            return path;
        }

        #endregion
    }
}