﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.StyleProperties
{
    internal class SideValues
    {
        public SideValues(int left, int right, int top, int bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }

        public int Left { get; set; }
        public int Right {  get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
    }
}
