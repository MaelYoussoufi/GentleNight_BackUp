using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.CardModel;
using Assets.Scripts.DataModel.CardModel.EffectModel;
using Assets.Scripts.DataModel.DeckM;
using Assets.Scripts.Helpers;

namespace Assets.Scripts.DataModel.Card.Effect
{
    [Serializable]
    public class RandomizedStandardEffectModel : EffectModelBase
    {
        public StandardEffectModel Value;
        public float ValueChance;

        protected Random rand = new Random();

        public override object Clone()
        {
            return new RandomizedStandardEffectModel()
            {
                Value = this.Value.GetCopy(),
                ValueChance = this.ValueChance,
            };
        }

        public override void Apply(PlayerStatusModel player)
        {
            var modifiedEffectModel = new StandardEffectModel()
            {
                Might =(short) (Value.Might * (rand.Next(100) * ValueChance / 100) ),
                Arcana = (short) (Value.Arcana * (rand.Next(100) * ValueChance / 100) ),
                Craft = (short) (Value.Craft * (rand.Next(100) * ValueChance / 100) ),
                Bulwark = (short) (Value.Bulwark * (rand.Next(100) * ValueChance / 100) ),
                HealthGain = (short) (Value.HealthGain * (rand.Next(100) * ValueChance / 100) ),
                Kindling = (short) (Value.Kindling * (rand.Next(100) * ValueChance / 100) ),
                Wander = (short) (Value.Wander * (rand.Next(100) * ValueChance / 100) ),
                Wealth = (short) (Value.Wealth * (rand.Next(100) * ValueChance / 100) ),
            };
        }
    }
}
