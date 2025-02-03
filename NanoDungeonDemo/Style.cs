using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal class Style
    {
        public string ID {  get; set; }
        public IProperty[] Properties { get; set; }

        public static IProperty[] JoinStyles(List<Style> styles)
        {
            var joinedStyles = (IProperty[])Defaults.Clone();
            foreach (var style in styles)
            {
                foreach (var property in style.Properties)
                {
                    int index = Array.FindIndex(joinedStyles, p => p.GetType() == property.GetType());
                    if (index >= 0)
                    {
                        joinedStyles[index] = property;
                    }
                }
            }
            return joinedStyles;
        }
        readonly static IProperty[] Defaults =
        [
            new StyleProperties.Color(),
            new StyleProperties.Margin(),
            new StyleProperties.Padding(),
            new StyleProperties.Gap(),
        ];

        public Style(string iD, IProperty[] properties)
        {
            ID = iD;
            Properties = properties;
        }
    }
}
