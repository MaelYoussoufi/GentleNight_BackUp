using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Helpers
{
    public static class CoroutineHelper
    {
        public static IEnumerator ChainCoroutines(params IEnumerator[] routines)
        {
            foreach (var routine in routines)
            {
                yield return routine;
            }
        }
    }
}
