using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal struct ColoredChar
    {
        public ColoredChar(char @char = ' ', ConsoleColor textColor = ConsoleColor.Gray, ConsoleColor backGroundColor = ConsoleColor.Black)
        {
            Char = @char;
            TextColor = textColor;
            BackgroundColor = backGroundColor;
        }

        public char Char { get; set; } = ' ';
        public ConsoleColor TextColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

        public static bool operator ==(ColoredChar a, ColoredChar b)
        {
            return a.Char == b.Char && a.TextColor == b.TextColor && a.BackgroundColor == b.BackgroundColor;
        }

        public static bool operator !=(ColoredChar a, ColoredChar b)
        {
            return a.Char != b.Char || a.TextColor != b.TextColor || a.BackgroundColor != b.BackgroundColor;
        }
    }
}
