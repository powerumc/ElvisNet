using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvisNet
{
    public struct Nil
    {
        public Nil(object @value)
        {

        }

        private static object Value = new object();

        public override bool Equals(object obj)
        {
            if (obj == null) return true;
            if (obj is Nil) return true;

            return base.Equals(obj);
        }

        public static explicit operator Nil(string @value)
        {
            return new Nil(@value);
        }
    }
}
