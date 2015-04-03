using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExportHelper
{
    public static class EnumerableHelper
    {
        private static readonly Random Rnd = new Random();

        public static IEnumerable<T> Permute<T>(this IEnumerable<T> source, int topCount)
        {
            var list = new List<T>(source);
            var seq = Enumerable.Repeat(0, 50).Select(i => Rnd.Next(0, list.Count));
            foreach (var i in seq)
            {
                var temp = list[0];
                list[0] = list[i];
                list[i] = temp;
            }
            return list.Take(topCount).ToArray();
        }
    }
}
