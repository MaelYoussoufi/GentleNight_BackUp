using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.CardModel;
using NUnit.Framework;

namespace Assets.Scripts.Tests.DataModel
{
    public class StandardEffectModelTest
    {
        [Test]
        public void StandardEffectAdditionTest()
        {
            var standardEffectA = new StandardEffectModel()
            {
                Might = 1,
                Craft = 2,
                Arcana = 3,
                Bulwark = 4,
                HealthGain = 5,
                Kindling = 6,
                Wander = 7,
                Wealth = 8,
            };
            var standardEffectB = new StandardEffectModel()
            {
                Might = 1,
                Craft = 2,
                Arcana = 1,
                Bulwark = 0,
                HealthGain = 1,
                Kindling = 0,
                Wander = 3,
                Wealth = 1,
            };
            var stdEffectC = standardEffectB + standardEffectA;
            Assert.That(stdEffectC, Is.Not.Null);
            Assert.That(stdEffectC.Might, Is.EqualTo(2));
            Assert.That(stdEffectC.Craft, Is.EqualTo(4));
            Assert.That(stdEffectC.Arcana, Is.EqualTo(4));
            Assert.That(stdEffectC.Bulwark, Is.EqualTo(4));
            Assert.That(stdEffectC.HealthGain, Is.EqualTo(6));
            Assert.That(stdEffectC.Kindling, Is.EqualTo(6));
            Assert.That(stdEffectC.Wander, Is.EqualTo(10));
            Assert.That(stdEffectC.Wealth, Is.EqualTo(9));
        }
    }
}
