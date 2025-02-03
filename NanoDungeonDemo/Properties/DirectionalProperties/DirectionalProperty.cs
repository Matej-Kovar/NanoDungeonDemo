using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace frontend.Properties.DirectionalProperties
{
    abstract class DirectionalProperty<T> : IProperty<DirectionalValues<T>>
    {
        public DirectionalValues<T> Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DirectionalValues<T> ParseProperty(string stringInput)
        {
            string[] stringValues = stringInput.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            List<T> values = new List<T>();
            foreach (string stringValue in stringValues)
            {
                values.Add(ParseValue(stringValue));
            }
            switch (values.Count)
            {
                case 1:
                    return new DirectionalValues<T>(values[0]);
                case 2:
                    return new DirectionalValues<T>(values[0], values[1]);
                case 4:
                    return new DirectionalValues<T>(values[0], values[1], values[2], values[3]);
                default:
                    throw new FormatException($"Format {stringInput} is not valid for {this.GetType().Name}");
            }
        }

        public abstract T ParseValue(string stringInput);
    }
}
