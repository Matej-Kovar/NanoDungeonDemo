using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Properties
{
    interface IProperty<T>
    {
        public T Value { get; set; }

        public abstract T ParseProperty(string input);

        public bool TryParseProperty(string input, out T value)
        {
            try
            {
                value = ParseProperty(input);
                return true;
            }
            catch
            {
                value = default!;
                return false;
            }
        }
    }

}
