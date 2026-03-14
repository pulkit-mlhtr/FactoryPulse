using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPulse.Domain.Utils
{
    public static class StringHelper
    {
        public static string Concat(string separator, params string[] args)
        {
            return string.Join(separator,args);
        }
    }
}
