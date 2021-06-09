using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.Card.Effect;
using Assets.Scripts.DataModel.CardModel;
using NUnit.Framework;

namespace Assets.Scripts.Tests.DataModel.Effects
{
    public class RandomizedStandardEffectTest : EffectTestBase
    {
        [Test]
        public void CheckValueFromRandomizedEffect()
        {
            var player = MakePlayerStatusModel();
            var effect = new RandomizedStandardEffectModel()
            {
                Value = new StandardEffectModel()
                {
                    Craft = 10,
                    Might = 10,
                    Arcana = 10,
                    Bulwark = 10,
                    HealthGain = 10,
                    Kindling = 10,
                    Wealth = 10,
                    Wander = 10,
                },
                ValueChance = 0.5f
            };

            HackRandomValue(effect);

            Assert.DoesNotThrow(() => effect.Apply(player));
            CheckPlayerStatusRessources(player, 1, 2, 3, 4, 5, 6, 7, 8);
        }

        //Cheating - Might make an inner method to mod the random for testing only ?
        private void HackRandomValue(RandomizedStandardEffectModel effect)
        {
            effect.GetType().GetProperty("rand", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(effect, new Random(1337), null);
        }
    }
}
