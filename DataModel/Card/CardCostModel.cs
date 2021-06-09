using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataModel.CardModel
{
    public class CardCostModel : ICloneable
    {
        public short KindlingCost;

        public object Clone()
        {
            return new CardCostModel()
            {
                KindlingCost = KindlingCost
            };
        }
    }
}
