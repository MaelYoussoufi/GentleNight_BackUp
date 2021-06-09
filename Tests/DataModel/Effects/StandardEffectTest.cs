using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.CardModel;
using NUnit.Framework;

namespace Assets.Scripts.Tests.DataModel.Effects
{
    public class StandardEffectTest : EffectTestBase
    {
        [Test]
        public void AplyEffect_Test()
        {
            var player = MakePlayerStatusModel();
            var effect = new StandardEffectModel()
            {
                Craft = 1,
                Might = 2,
                Arcana = 3,
                Bulwark = 4,
                HealthGain = 5,
                Kindling = 6,
                Wealth = 7,
                Wander = 8,
            };
            Assert.DoesNotThrow(()=> effect.Apply(player));
            CheckPlayerStatusRessources(player, 1,2,3,4,5,6,7,8);
        }

        [Test]
        public void AplyEffect_WorksWith_NegativeValue_Test()
        {
            var player = MakePlayerStatusModel();
            var effect = new StandardEffectModel()
            {
                Craft = -1,
                Might = -2,
                Arcana = -3,
                Bulwark = -4,
                HealthGain = -5,
                Kindling = -6,
                Wealth = -7,
                Wander = -8,
            };
            Assert.DoesNotThrow(() => effect.Apply(player));
            CheckPlayerStatusRessources(player, -1, -2, -3, -4, -5, -6, -7, -8);
        }
    }
}
