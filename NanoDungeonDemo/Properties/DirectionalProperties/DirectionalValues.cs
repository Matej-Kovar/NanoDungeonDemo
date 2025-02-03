using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Properties.DirectionalProperties
{
    internal struct DirectionalValues<T>
    {
        public DirectionalValues(T left, T right, T top, T bottom)
        {
            Left = left;
            Right = right;
            Top = top;
            Bottom = bottom;
        }
        public DirectionalValues(T horizontal, T vertical)
        {
            Left = horizontal;
            Right = horizontal;
            Top = vertical;
            Bottom = vertical;
        }
        public DirectionalValues(T value)
        {
            Left = value;
            Right = value;
            Top = value;
            Bottom = value;
        }

        public T Left { get; set; }
        public T Right { get; set; }
        public T Top { get; set; }
        public T Bottom { get; set; }
    }
}
