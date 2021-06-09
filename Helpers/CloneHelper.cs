using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public static class CloneHelper
    {
        public static T GetCopy<T>(this T item) where T : class, ICloneable
        {
            return item.Clone() as T;
        }

        public static IEnumerable<T> Clone<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        public static IEnumerable<T> GetCopy<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Clone();
        }
    }
}
