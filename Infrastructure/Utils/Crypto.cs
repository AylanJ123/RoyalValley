using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public class Crypto
    {
        public static bool CompareBytes(byte[] a, byte[] b)
        {
            bool f = a.Length == b.Length;
            for (int i = 0; i < a.Length && i < b.Length; ++i) f &= a[i] == b[i];
            return f;
        }
    }
}
