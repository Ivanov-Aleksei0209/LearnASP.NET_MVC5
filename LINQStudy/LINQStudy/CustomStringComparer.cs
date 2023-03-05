using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQStudy
{
    internal class CustomStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xLength = x?.Length ?? 0; // если х = null, то длина 0
            int yLength = y?.Length ?? 0;
            return xLength - yLength;
        }
    }
}
