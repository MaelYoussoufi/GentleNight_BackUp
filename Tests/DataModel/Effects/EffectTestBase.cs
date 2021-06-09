using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel;
using Assets.Scripts.DataModel.CardModel;
using NUnit.Framework;

namespace Assets.Scripts.Tests.DataModel.Effects
{
    public class EffectTestBase
    {
        protected PlayerStatusModel MakePlayerStatusModel()
        {
            return new PlayerStatusModel()
            {
                CurrentRessources = new StandardEffectModel()
                {
                    Craft = 0,
                    Might = 0,
                    Arcana = 0,
                    Bulwark = 0,
                    HealthGain = 0,
                    Kindling = 0,
                    Wealth = 0,
                    Wander = 0,
                }
            };
        }

        protected void CheckPlayerStatusRessources(PlayerStatusModel player, short Craft, short Might, short Arcana, short Bulwark
            , short HealthGain, short Kindling, short Wealth, short Wander)
        {
            Assert.That(player.CurrentRessources, Is.Not.Null);
            var currentRessources = player.CurrentRessources;
            Assert.That(currentRessources.Craft, Is.EqualTo(Craft));
            Assert.That(currentRessources.Might, Is.EqualTo(Might));
            Assert.That(currentRessources.Arcana, Is.EqualTo(Arcana));
            Assert.That(currentRessources.Bulwark, Is.EqualTo(Bulwark));
            Assert.That(currentRessources.HealthGain, Is.EqualTo(HealthGain));
            Assert.That(currentRessources.Kindling, Is.EqualTo(Kindling));
            Assert.That(currentRessources.Wealth, Is.EqualTo(Wealth));
            Assert.That(currentRessources.Wander, Is.EqualTo(Wander));
        }

    }
}
