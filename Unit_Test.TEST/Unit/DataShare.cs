using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Test.TEST.Unit
{
    public static class DataShare
    {
        public static IEnumerable<object[]> IsEvenData
        {
            get
            {
                yield return new object[] { 4, true };
                yield return new object[] { 5, false };
                yield return new object[] { 6, true };
                yield return new object[] { 7, false };
            }
        }
    }
}
