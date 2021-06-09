using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.Card;
using Assets.Scripts.DataModel.Card.Effect;
using Assets.Scripts.DataModel.CardModel;
using Assets.Scripts.DataModel.CardModel.EffectModel;
using Assets.Scripts.DataModel.Enum;
using Assets.Scripts.DataModel.Serialise;
using Assets.Scripts.Helpers;
using NUnit.Framework;

namespace Assets.Scripts.Tests.DataModel
{
    public class CardEffectSerialisationTest
    {
        private List<CardDataModel> testCardList = new List<CardDataModel>()
        {
            new CardDataModel()
            {
                Name = "Test1",Id = "Test2", Text = "YADA YADA YADA", Origin = CardOrigin.StartingDeck, Type = CardType.Kindle,
                BasicEffect = new StandardEffectModel(){Kindling = 1,Wealth = 1, Might = 1, Bulwark = 1},
                Effects = new List<EffectModelBase>(){new RandomizedStandardEffectModel()
                {
                    Value = new StandardEffectModel(){HealthGain = 1,Arcana = 1, Wander = 1, Craft = 1 },
                    ValueChance = 0.5f
                }}
            }
        };

        [Test]
        public void CreateXmlFile()
        {
            var collection = new CardXmlCollection() { Cards = testCardList.ToArray() };
            var file = collection.GetXml();
            Assert.That(file, Is.Not.Null);
        }
        [Test]
        public void DeserializeCardWithRandomizedStandardEffect()
        {
            CardXmlCollection cardCollection = null;
            Assert.DoesNotThrow(() =>
            {
                cardCollection = CardXmlCollection.Load(file);
            });
            Assert.That(cardCollection, Is.Not.Null);
            Assert.That(cardCollection.Cards, Is.Not.Null);
            Assert.That(cardCollection.Cards, Is.Not.Empty);
            Assert.That(cardCollection.Cards.First().Effects, Is.Not.Null);
            Assert.That(cardCollection.Cards.First().Effects, Is.Not.Empty);
            Assert.That(cardCollection.Cards.First().Effects.First(), Is.TypeOf(typeof(RandomizedStandardEffectModel)));

            var randEffect = cardCollection.Cards.First().Effects.First() as RandomizedStandardEffectModel;

            Assert.That(randEffect.ValueChance, Is.EqualTo(0.5));
            Assert.That(randEffect.Value, Is.Not.Null);
            Assert.That(randEffect.Value.Wander, Is.EqualTo(1));
        }

        public string file = @"<?xml version=""1.0"" encoding=""utf-16""?>
        <CardCollection xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
        <CardsList>
        <Card>
        <Name>Test1</Name>
        <Id>Test2</Id>
        <Text>YADA YADA YADA</Text>
        <Type>Kindle</Type>
        <Origin>StartingDeck</Origin>
        <BasicEffect>
        <Wander>0</Wander>
        <Kindling>1</Kindling>
        <Wealth>1</Wealth>
        <Might>1</Might>
        <Bulwark>1</Bulwark>
        <Craft>0</Craft>
        <Arcana>0</Arcana>
        <HealthGain>0</HealthGain>
        </BasicEffect>
        <Effects>
        <Effects xsi:type=""RandomizedStandardEffectModel"">
        <Value>
        <Wander>1</Wander>
        <Kindling>0</Kindling>
        <Wealth>0</Wealth>
        <Might>0</Might>
        <Bulwark>0</Bulwark>
        <Craft>1</Craft>
        <Arcana>1</Arcana>
        <HealthGain>1</HealthGain>
        </Value>
        <ValueChance>0.5</ValueChance>
        </Effects>
        </Effects>
        </Card>
        </CardsList>
        </CardCollection>";

    }
}
