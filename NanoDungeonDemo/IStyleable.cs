using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal interface IStyleable
    {
        public List<string> Styles { get; set; }
        public List<IProperty> ApplicableProperties { get; set; }
    }
}
