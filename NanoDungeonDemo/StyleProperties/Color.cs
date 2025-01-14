﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using frontend;

namespace frontend.StyleProperties
{
    internal class Color : IStyleProperty
    {
        public static int Order = 1;
        public ConsoleColor Background;
        public ConsoleColor Text;
        public ColoredChar[,] Apply(ColoredChar[,] subframe)
        {
            for (int i = 0; i < subframe.GetLength(0); i++)
            {
                for (int j = 0; j < subframe.GetLength(1); j++)
                {
                    subframe[i, j].TextColor = Text;
                    subframe[i, j].BackgroundColor = Background;
                }
            }
            return subframe;
        } 
        public Color(ConsoleColor text = ConsoleColor.Gray, ConsoleColor background = ConsoleColor.Black)
        {
            Background = background;
            Text = text;
        }
    }
}

