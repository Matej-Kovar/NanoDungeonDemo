using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal class Container : IRenderable
    {
        public Container(IRenderable[] content)
        {
            Content = content;
            MaxWidth = Console.WindowWidth;
            MaxHeight = Console.WindowHeight;
        }

        public IRenderable[] Content { get; set; }
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public ColoredChar[,] Build()
        {
            List<ColoredChar[,]> content = new List<ColoredChar[,]>();
            foreach (var item in Content)
            {
                item.MaxWidth = MaxWidth / Content.Length;
                content.Add(item.Build());
            }
            int Height = Math.Max(content.Max(item => item.GetLength(0)), MaxHeight);
            int Width = Math.Max(content.Sum(item => item.GetLength(1)), MaxWidth);
            ColoredChar[,] result =  new ColoredChar[Height, Width];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                ColoredChar[,] currentChild = new ColoredChar[0,0];
                int offset = 0;
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if(j >= currentChild.GetLength(1) + offset)
                    {
                        for (int k = 0; k < content.Count; k++)
                        {
                            if (content[k].GetLength(1) + offset > j)
                            {
                                currentChild = content[k];
                                break;
                            }
                            else
                            {
                                offset += content[k].GetLength(1);
                            }
                        }
                    }
                    if(i < currentChild.GetLength(0))
                    {
                        result[i, j] = currentChild[i, j - offset];
                    }
                }
            }
            return result;
        }
    }
}
