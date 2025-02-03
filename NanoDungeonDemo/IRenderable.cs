using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal interface IRenderable
    {
        public bool Modified { get; set; }
        public string ID { get; set; }
        public ConsolePixel[,] RenderElement();
        public ConsolePixel[,] InitializeElement();
        public ConsolePixel[,] UpdateElement();
    }
}