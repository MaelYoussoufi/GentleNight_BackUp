using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Assets.Scripts.DataModel.Card.Effect;
using Assets.Scripts.DataModel.DeckM;

namespace Assets.Scripts.DataModel.CardModel.EffectModel
{
    [Serializable]
    [XmlInclude(typeof(RandomizedStandardEffectModel))]
    public abstract class EffectModelBase : ICloneable
    {
        public abstract object Clone();
        public abstract void Apply(PlayerStatusModel player);
    }
}
