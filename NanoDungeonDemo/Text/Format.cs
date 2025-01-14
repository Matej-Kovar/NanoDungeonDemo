using Microsoft.Diagnostics.Runtime.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Text
{
    internal static class Format
    {
        public static string[] Wrap(string text, int width)
        {
            var result = new List<string>();
            var words = text.Split(' ');

            foreach (var word in words)
            {
                if (word.Length > width)
                {
                    for (int i = 0; i < word.Length; i += width)
                    {
                        result.Add(word.Substring(i, Math.Min(width, word.Length - i)));
                    }
                }
                else if (result.Count > 0 && result[result.Count - 1].Length + word.Length + 1 <= width)
                {
                    result[result.Count - 1] += $" {word}";
                }
                else
                {
                    if (result.Count > 0)
                    {
                        result[result.Count - 1] += new string(' ', width - result[result.Count - 1].Length);
                    }
                    result.Add(word);
                }
            }
            result[result.Count - 1] += new string(' ', width - result[result.Count - 1].Length);
            return result.ToArray();
        }

        public static string[] joinColumn(string[][] paragraphs, int gap)
        {
            List<string> result = new List<string>();
            foreach (string[] paragraph in paragraphs)
            {
                foreach (string line in paragraph)
                {
                    result.Add(line);
                }
                for (int i = 0; i < gap; i++)
                {
                    result.Add("");
                }

            }
            result.RemoveAt(result.Count - 1);
            return result.ToArray();
        }
    }
}
