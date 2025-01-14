using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend.StyleProperties;

namespace frontend
{
    internal class Textbox: IRenderable
    {
        public Textbox(string[] content, List<Style> styles)
        {
            Content = content;
            Styles = styles;
        }

        public string[] Content { get; set; } //ukládá strukturu
        public List<Style> Styles { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public ColoredChar[,] Build()
        {
            int Width = MaxWidth;
            int Height = MaxHeight;

            List<string[]> temp = new List<string[]>();

            var joinedStyle = Style.JoinStyles(Styles);
            var color = joinedStyle.OfType<Color>().First();
            var padding = joinedStyle.OfType<Padding>().First();
            var margin = joinedStyle.OfType<Margin>().First();
            var gap = joinedStyle.OfType<Gap>().First();

            Width -= margin.Left + margin.Right + padding.Left + padding.Right;

            foreach (string s in Content)
            {
                temp.Add(Text.Format.Wrap(s, Width));
            }
            string[] wrappedContent = Text.Format.joinColumn(temp.ToArray(), gap.gap);
            Height = wrappedContent.Length;

            Height += margin.Top + margin.Bottom + padding.Top + padding.Bottom;

            var result = new ColoredChar[Height, MaxWidth];

            for (int i = 0; i < Height; i++)
            {
                bool isWithinContentRow = i >= margin.Top + padding.Top && i < Height - margin.Bottom - padding.Bottom;
                bool isWithinPaddingRow = i >= margin.Top && i < Height - margin.Bottom;

                char[] rowContent = isWithinContentRow
                    ? wrappedContent[i - margin.Top - padding.Top].PadRight(MaxWidth - margin.Left - margin.Right).ToCharArray()
                    : new string(' ', MaxWidth - margin.Left - margin.Right).ToCharArray();

                for (int j = 0; j < MaxWidth; j++)
                {
                    bool isWithinPaddingColumn = j >= margin.Left && j < MaxWidth - margin.Right;
                    bool isWithinContentColumn = j >= margin.Left + padding.Left && j < MaxWidth - margin.Right - padding.Right;

                    if (!isWithinPaddingRow || !isWithinPaddingColumn)
                    {
                        result[i, j] = new ColoredChar(' ', ConsoleColor.Gray, ConsoleColor.Black);
                    }
                    else if (!isWithinContentColumn)
                    {
                        result[i, j] = new ColoredChar(' ', color.Text, color.Background);
                    }
                    else
                    {
                        result[i, j] = new ColoredChar(rowContent[j - margin.Left - padding.Left], color.Text, color.Background);
                    }
                }
            }

            return result;
        }
    }
}
