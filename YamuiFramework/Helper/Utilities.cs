﻿#region header
// ========================================================================
// Copyright (c) 2016 - Julien Caillon (julien.caillon@gmail.com)
// This file (Utilities.cs) is part of YamuiFramework.
// 
// YamuiFramework is a free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// YamuiFramework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with YamuiFramework. If not, see <http://www.gnu.org/licenses/>.
// ========================================================================
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YamuiFramework.Helper {

    /// <summary>
    /// This class provides various utilies to use in YamuiFramework and outside
    /// </summary>
    public static class Utilities {

        #region Validation and data type conversions

        public static readonly Dictionary<Type, char[]> KeyPressValidChars = new Dictionary<Type, char[]> {
            {typeof (byte), GetCultureChars(true, false, true)},
            {typeof (sbyte), GetCultureChars(true, true, true)},
            {typeof (short), GetCultureChars(true, true, true)},
            {typeof (ushort), GetCultureChars(true, false, true)},
            {typeof (int), GetCultureChars(true, true, true)},
            {typeof (uint), GetCultureChars(true, false, true)},
            {typeof (long), GetCultureChars(true, true, true)},
            {typeof (ulong), GetCultureChars(true, false, true)},
            {typeof (double), GetCultureChars(true, true, true, true, true, true)},
            {typeof (float), GetCultureChars(true, true, true, true, true, true)},
            {typeof (decimal), GetCultureChars(true, true, true, true, true)},
            {typeof (TimeSpan), GetCultureChars(true, true, false, new[] {'-'})},
            {typeof (Guid), GetCultureChars(true, false, false, "-{}()".ToCharArray())}
        };

        public static char[] GetCultureChars(bool digits, bool neg, bool pos, bool dec = false, bool grp = false, bool e = false) {
            var c = CultureInfo.CurrentCulture.NumberFormat;
            var l = new List<string>();
            if (digits) l.AddRange(c.NativeDigits);
            if (neg) l.Add(c.NegativeSign);
            if (pos) l.Add(c.PositiveSign);
            if (dec) l.Add(c.NumberDecimalSeparator);
            if (grp) l.Add(c.NumberGroupSeparator);
            if (e) l.Add("Ee");
            var sb = new StringBuilder();
            foreach (var s in l)
                sb.Append(s);
            char[] ca = sb.ToString().ToCharArray();
            Array.Sort(ca);
            return ca;
        }

        public static char[] GetCultureChars(bool timeChars, bool timeSep, bool dateSep, char[] other) {
            var c = CultureInfo.CurrentCulture;
            var l = new List<string>();
            if (timeChars) l.AddRange(c.NumberFormat.NativeDigits);
            if (timeSep) {
                l.Add(c.DateTimeFormat.TimeSeparator);
                l.Add(c.NumberFormat.NumberDecimalSeparator);
            }
            if (dateSep) l.Add(c.DateTimeFormat.DateSeparator);
            if (other != null && other.Length > 0) l.Add(new string(other));
            var sb = new StringBuilder();
            foreach (var s in l)
                sb.Append(s);
            char[] ca = sb.ToString().ToCharArray();
            Array.Sort(ca);
            return ca;
        }

        public static readonly Dictionary<Type, Predicate<string>> Validations = new Dictionary<Type, Predicate<string>> {
            {
                typeof (byte), s => {
                    byte n;
                    return byte.TryParse(s, out n);
                }
            }, {
                typeof (sbyte), s => {
                    sbyte n;
                    return sbyte.TryParse(s, out n);
                }
            }, {
                typeof (short), s => {
                    short n;
                    return short.TryParse(s, out n);
                }
            }, {
                typeof (ushort), s => {
                    ushort n;
                    return ushort.TryParse(s, out n);
                }
            }, {
                typeof (int), s => {
                    int n;
                    return int.TryParse(s, out n);
                }
            }, {
                typeof (uint), s => {
                    uint n;
                    return uint.TryParse(s, out n);
                }
            }, {
                typeof (long), s => {
                    long n;
                    return long.TryParse(s, out n);
                }
            }, {
                typeof (ulong), s => {
                    ulong n;
                    return ulong.TryParse(s, out n);
                }
            }, {
                typeof (char), s => {
                    char n;
                    return char.TryParse(s, out n);
                }
            }, {
                typeof (double), s => {
                    double n;
                    return double.TryParse(s, out n);
                }
            }, {
                typeof (float), s => {
                    float n;
                    return float.TryParse(s, out n);
                }
            }, {
                typeof (decimal), s => {
                    decimal n;
                    return decimal.TryParse(s, out n);
                }
            }, {
                typeof (DateTime), s => {
                    DateTime n;
                    return DateTime.TryParse(s, out n);
                }
            }, {
                typeof (TimeSpan), s => {
                    TimeSpan n;
                    return TimeSpan.TryParse(s, out n);
                }
            }, {
                typeof (Guid), s => {
                    try {
                        Guid n = new Guid(s);
                        return true;
                    } catch {
                        return false;
                    }
                }
            }
        };

        public static bool IsSupportedType(Type type) {
            if (typeof (IConvertible).IsAssignableFrom(type))
                return true;
            var cvtr = TypeDescriptor.GetConverter(type);
            if (cvtr.CanConvertFrom(typeof (string)) && cvtr.CanConvertTo(typeof (string)))
                return true;
            return false;
        }

        public static bool IsSimpleType(this Type type) {
            return type.IsPrimitive || type.IsEnum || Array.Exists(SimpleTypes, t => t == type) || Convert.GetTypeCode(type) != TypeCode.Object ||
                   (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]));
        }

        public static readonly Type[] SimpleTypes = {
            typeof (Enum), typeof (Decimal), typeof (DateTime),
            typeof (DateTimeOffset), typeof (String), typeof (TimeSpan), typeof (Guid)
        };

        public static bool IsInvalidKey(char keyChar, Type itemType) {
            if (char.IsControl(keyChar))
                return false;
            char[] chars;
            KeyPressValidChars.TryGetValue(itemType, out chars);
            if (chars != null) {
                int si = Array.BinarySearch(chars, keyChar);
                if (si < 0)
                    return true;
            }
            return false;
        }

        #endregion

        #region Conversion

        /// <summary>
        /// Converts a string to an object of the given type
        /// </summary>
        public static object ConvertFromStr(this string value, Type destType) {
            try {
                if (destType == typeof (string))
                    return value;
                return TypeDescriptor.GetConverter(destType).ConvertFromInvariantString(value);
            } catch (Exception) {
                return destType.IsValueType ? Activator.CreateInstance(destType) : null;
            }
        }

        /// <summary>
        /// Converts an object to a string
        /// </summary>
        public static string ConvertToStr(this object value) {
            if (value == null)
                return string.Empty;
            return TypeDescriptor.GetConverter(value).ConvertToInvariantString(value);
        }

        #endregion

        #region GetRoundedRect

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
        public static GraphicsPath GetRoundedRect(float x, float y, float width, float height, float diameter) {
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
        public static GraphicsPath GetRoundedRect(RectangleF rect, float diameter) {
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

        #region Colors extensions

        /// <summary>
        /// Replace all the occurences of @alias thx to the aliasDictionnary
        /// </summary>
        /// <param name="value"></param>
        /// <param name="aliasDictionnary"></param>
        /// <returns></returns>
        public static string ReplaceAliases(this string value, Dictionary<string, string> aliasDictionnary) {
            while (true) {
                if (value.Contains("@")) {
                    // try to replace a variable name by it's html color value
                    var regex = new Regex(@"@([a-zA-Z]*)", RegexOptions.IgnoreCase);
                    value = regex.Replace(value, match => {
                        if (aliasDictionnary.ContainsKey(match.Groups[1].Value))
                            return aliasDictionnary[match.Groups[1].Value];
                        throw new Exception("Couldn't find the color " + match.Groups[1].Value + "!");
                    });
                    continue;
                }
                return value;
            }
        }

        /// <summary>
        /// Allows to have the syntax : 
        /// lighten(#000000, 35%)
        /// darken(#FFFFFF, 35%)
        /// </summary>
        /// <param name="htmlColor"></param>
        /// <returns></returns>
        public static string ApplyColorFunctions(this string htmlColor) {
            if (htmlColor.Contains("(")) {
                var functionName = htmlColor.Substring(0, htmlColor.IndexOf("(", StringComparison.CurrentCultureIgnoreCase));
                var splitValues = htmlColor.GetBetweenMostNested("(", ")").Split(',');
                float ratio;
                if (!float.TryParse(splitValues[1].Trim().Replace("%", ""), out ratio))
                    ratio = 0;

                // Apply the color function to the base color (in case this is another function embedded in this one)
                var baseColor = splitValues[0].Trim().ApplyColorFunctions();

                if (functionName.StartsWith("dark"))
                    return baseColor.ModifyColorLuminosity(-1 * ratio / 100);
                if (functionName.StartsWith("light"))
                    return baseColor.ModifyColorLuminosity(ratio / 100);

                return baseColor;
            }
            return htmlColor;
        }

        /// <summary>
        /// Lighten or darken a color, ratio + to lighten, - to darken
        /// </summary>
        public static string ModifyColorLuminosity(this string htmlColor, float ratio) {
            var color = ColorTranslator.FromHtml(htmlColor);
            return ColorTranslator.ToHtml(ratio > 0 ? ControlPaint.Light(color, ratio) : ControlPaint.Dark(color, ratio));
            /*
            var isBlack = color.R == 0 && color.G == 0 && color.B == 0;
            var red = (int)Math.Min(Math.Max(0, color.R + ((isBlack ? 255 : color.R) * ratio)), 255);
            var green = (int)Math.Min(Math.Max(0, color.G + ((isBlack ? 255 : color.G) * ratio)), 255);
            var blue = (int)Math.Min(Math.Max(0, color.B + ((isBlack ? 255 : color.B) * ratio)), 255);
            return ColorTranslator.ToHtml(Color.FromArgb(red, green, blue));
             */
        }

        /// <summary>
        /// Get string value between [first] a and [last] b (not included)
        /// </summary>
        public static string GetBetweenMostNested(this string value, string a, string b, StringComparison comparer = StringComparison.CurrentCultureIgnoreCase) {
            int posA = value.LastIndexOf(a, comparer);
            int posB = value.IndexOf(b, comparer);
            return posB == -1 ? value.Substring(posA + 1) : value.Substring(posA + 1, posB - posA - 1);
        }

        #endregion

        #region image manipulation

        /// <summary>
        /// Returns the image in grey scale...
        /// </summary>
        public static Image MakeGreyscale3(Image original) {

            //create a blank bitmap the same size as original
            var newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            var g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            var colorMatrix = new ColorMatrix(
                new[] {
                    new[] {.3f, .3f, .3f, 0, 0},
                    new[] {.59f, .59f, .59f, 0, 0},
                    new[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            //create some image attributes
            var attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        #endregion

        #region Read a configuration file line by line

        /// <summary>
        /// Reads all the line of either the filePath (if the file exists) or from byte array dataResources,
        /// Apply the action toApplyOnEachLine to each line
        /// Uses encoding as the Encoding to read the file or convert the byte array to a string
        /// Uses the char # as a comment in the file
        /// </summary>
        public static bool ForEachLine(string filePath, byte[] dataResources, Action<string> toApplyOnEachLine, Encoding encoding, Action<Exception> onException) {
            bool wentOk = true;
            try {
                SubForEachLine(filePath, dataResources, toApplyOnEachLine, encoding);
            } catch (Exception e) {
                wentOk = false;
                onException(e);

                // read default file, if it fails then we can't do much but to throw an exception anyway...
                if (dataResources != null)
                    SubForEachLine(null, dataResources, toApplyOnEachLine, encoding);
            }
            return wentOk;
        }

        public static void SubForEachLine(string filePath, byte[] dataResources, Action<string> toApplyOnEachLine, Encoding encoding) {
            string line;
            // to apply on each line
            Action<TextReader> action = reader => {
                while ((line = reader.ReadLine()) != null) {
                    if (line.Length > 0 && line[0] != '#')
                        toApplyOnEachLine(line);
                }
            };
            // either read from the file or from the byte array
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath)) {
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    using (var reader = new StreamReader(fileStream, encoding)) {
                        action(reader);
                    }
                }
            } else {
                using (StringReader reader = new StringReader(encoding.GetString(dataResources))) {
                    action(reader);
                }
            }
        }

        #endregion

        #region control

        /// <summary>
        /// List all the controls children of "control" of type "type"
        /// this is recursive, so it find them all
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAll(Control control, Type type) {
            try {
                var controls = control.Controls.Cast<Control>();
                var enumerable = controls as IList<Control> ?? controls.ToList();
                return enumerable.SelectMany(ctrl => GetAll(ctrl, type)).Concat(enumerable).Where(c => c.GetType() == type);
            } catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// Get the first control of the type type it can find
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Control GetFirst(Control control, Type type) {
            try {
                return control.Controls.Cast<object>().Where(control1 => control1.GetType() == type).Cast<Control>().FirstOrDefault();
            } catch (Exception) {
                return null;
            }
        }

        #endregion


    }
}
