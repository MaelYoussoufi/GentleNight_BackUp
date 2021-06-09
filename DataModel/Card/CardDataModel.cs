using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Assets.Scripts.DataModel.CardModel;
using Assets.Scripts.DataModel.CardModel.EffectModel;
using Assets.Scripts.DataModel.Enum;
using Assets.Scripts.Helpers;

namespace Assets.Scripts.DataModel.Card
{
    [Serializable]
    public class CardDataModel : ICloneable
    {
        // Fluff data
        [OptionalField]
        public string Name;
        [OptionalField]
        public string Id;
        [OptionalField]
        public string Text;

        // Deck data
        [OptionalField]
        public CardType Type;
        [OptionalField]
        public CardOrigin Origin;


        // Card effect data

        public CardCostModel Cost;
        public StandardEffectModel BasicEffect;
        [XmlArray("Effects")]
        [XmlArrayItem("Effects")]
        public List<EffectModelBase> Effects;

        public CardDataModel()
        {
            Effects = new List<EffectModelBase>();
        }

        public object Clone()
        {
            return new CardDataModel()
            {
                Name = Name,
                Text = Text,
                Type = Type,
                Origin = Origin,
                Cost = Cost.GetCopy(),
                BasicEffect = BasicEffect.GetCopy(),
                Effects = Effects.GetCopy() as List<EffectModelBase>
            };
        }

    }

    [Serializable]
    public class CardDataModelRestricted
    {
        // Fluff data
        [OptionalField]
        public string Name;
        [OptionalField]
        public string Id;
        [OptionalField]
        public string Text;

        
    }
}
