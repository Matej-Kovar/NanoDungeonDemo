using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal class ConsolePixel : IEquatable<ConsolePixel>
    {
        public ConsolePixel(char @char = ' ', ConsoleColor textColor = ConsoleColor.Gray, ConsoleColor backGroundColor = ConsoleColor.Black)
        {
            Char = @char;
            TextColor = textColor;
            BackgroundColor = backGroundColor;
        }

        public char Char { get; set; } = ' ';
        public ConsoleColor TextColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

        public override bool Equals(object? obj)
        {
            if (obj is ConsolePixel other)
            {
                return Equals(other);
            }
            return false;
        }

        public bool Equals(ConsolePixel? other)
        {
            if (other is null) return false;
            return Char == other.Char && TextColor == other.TextColor && BackgroundColor == other.BackgroundColor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Char, TextColor, BackgroundColor);
        }

        public static bool operator ==(ConsolePixel? a, ConsolePixel? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }

        public static bool operator !=(ConsolePixel? a, ConsolePixel? b)
        {
            return !(a == b);
        }
    }
}
