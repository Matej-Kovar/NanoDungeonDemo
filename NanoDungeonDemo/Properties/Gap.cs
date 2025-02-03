using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.StyleProperties
{
    internal class Gap : IProperty
    {
        public Gap(int gap = 1)
        {
            this.gap = gap;
        }

        public int gap {  get; set; }

    }
}
