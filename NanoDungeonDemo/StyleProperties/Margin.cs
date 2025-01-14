using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.StyleProperties
{
    internal class Margin : SideValues, IStyleProperty
    {
        public Margin(int left = 1, int right = 1, int top = 1, int bottom = 1) : base(left, right, top, bottom)
        {
        }
    }
}
