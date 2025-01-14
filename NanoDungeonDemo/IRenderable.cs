using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal interface IRenderable
    {
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public ColoredChar[,] Build(); //přepisuje strukturu do ColoredChar[,]
    }
}