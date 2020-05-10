using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw9
{
    public static class ExtensionMethods
    {
        public static bool IsPjatkIndex(this string str)
        {
            return str[0] == 's' && str.Length == 5;
        }

        public static bool IsPjatkIndex(this string str, int l)
        {
            return str[0] == 's' && str.Length == 5;
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> nums, Func<T, bool> where)
        {
            var res = new List<T>();
            foreach (var i in nums)
            {
                if (where(i)) res.Add(i);
            }

            return res;
        }
    }
}
