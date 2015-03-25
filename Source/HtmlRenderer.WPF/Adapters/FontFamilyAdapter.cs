// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they begin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

using System.Globalization;
using System.Windows.Markup;
using System.Windows.Media;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace TheArtOfDev.HtmlRenderer.WPF.Adapters
{
    /// <summary>
    /// Adapter for WPF Font family object for core.
    /// </summary>
    internal sealed class FontFamilyAdapter : RFontFamily
    {
        /// <summary>
        /// Default language to get font family name by
        /// </summary>
        private static readonly XmlLanguage _xmlLanguage = XmlLanguage.GetLanguage(CultureInfo.CurrentUICulture.Name);

        /// <summary>
        /// the underline win-forms font.
        /// </summary>
        private readonly FontFamily _fontFamily;

        /// <summary>
        /// Init.
        /// </summary>
        public FontFamilyAdapter(FontFamily fontFamily)
        {
            _fontFamily = fontFamily;
        }

        /// <summary>
        /// the underline WPF font family.
        /// </summary>
        public FontFamily FontFamily
        {
            get { return _fontFamily; }
        }

        public override string Name
        {
            get
            {
                // get the possibly localized font family name
                string name = _fontFamily.FamilyNames.ContainsKey(_xmlLanguage) 
                    ? _fontFamily.FamilyNames[_xmlLanguage] 
                    : _fontFamily.ToString();

                // TODO: Is this necessary?
                if (string.IsNullOrEmpty(name))
                {
                    foreach (var familyName in _fontFamily.FamilyNames)
                    {
                        name = familyName.Value;
                        break;
                    }
                }

                return name;
            }
        }
    }
}