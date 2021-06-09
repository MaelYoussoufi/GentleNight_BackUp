using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public static class CollectionHelper
    {
        private static Random rnd = new Random();

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || !list.Any();
        }

        public static bool IsNotNullNorEmpty<T>(this IEnumerable<T> list)
        {
            return !IsNullOrEmpty(list);
        }

        public static Dictionary<Y, List<T>> GroupByAsDictionary<T, Y>(this IEnumerable<T> list, Func<T, Y> keyFunc)
        {
            return list.GroupBy(keyFunc).ToDictionary(g => g.Key, g => g.ToList());
        }

        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> list)
        {
            return list?.GroupByAsDictionary(s => s)?.Where(kvp => kvp.Value.Count > 1)
                ?.Select(kvp => kvp.Key);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
