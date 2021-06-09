using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.DataModel.Card;
using Assets.Scripts.DataModel.CardModel;
using Assets.Scripts.DataModel.Enum;
using Assets.Scripts.DataModel.Serialise;
using Assets.Scripts.Helpers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CardSerialisationTest
    {
        private CardXmlCollection testCardList = new CardXmlCollection() {
            Cards = new CardDataModel[]
        {
            new CardDataModel()
            {
                Name = "Test1",Id = "Test2", Text = "YADA YADA YADA", Origin = CardOrigin.StartingDeck, Type = CardType.Kindle,
                BasicEffect = new StandardEffectModel(){Kindling = 1,Wealth = 1, Might = 1, Bulwark = 1}
            },
            new CardDataModel()
            {
                Name = "NotATest",Id = "MaybeItIs",Text = "BLAH BLAH BLAH", Origin = CardOrigin.Boon, Type = CardType.AsheOf,
                BasicEffect = new StandardEffectModel(){HealthGain = 1,Arcana = 1, Wander = 1, Craft = 1 }
            },
        }};

        [Test]
        public void DeSerializeTest()
        {
            var dataCreated =CardXmlCollection.Load(file);
            ValidateDataAgainstCardList(dataCreated.Cards);
        }
        [Test]
        public void DeSerializeFromPartialFileTest()
        {
            var dataCreated = CardXmlCollection.Load(filePartial);
            ValidateDataAgainstCardList(dataCreated.Cards);
        }

        private void ValidateDataAgainstCardList(CardDataModel[] cardDataModels)
        {
            Assert.That(cardDataModels, Is.Not.Null);
            Assert.That(cardDataModels, Is.Not.Empty);
            Assert.That(cardDataModels, Has.Length.EqualTo(2));
            Assert.That(cardDataModels[0], Is.Not.Null);
            Assert.That(cardDataModels[0].Name, Is.EqualTo(testCardList.Cards.First().Name));
            Assert.That(cardDataModels[0].BasicEffect.Wander, Is.EqualTo(testCardList.Cards.First().BasicEffect.Wander));
        }

        public string file =>
@"<?xml version=""1.0"" encoding=""utf-16""?>
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
        <Effects />
        </Card>
        <Card>
        <Name>NotATest</Name>
        <Id>MaybeItIs</Id>
        <Text>BLAH BLAH BLAH</Text>
        <Type>AsheOf</Type>
        <Origin>Boon</Origin>
        <BasicEffect>
        <Wander>1</Wander>
        <Kindling>0</Kindling>
        <Wealth>0</Wealth>
        <Might>0</Might>
        <Bulwark>0</Bulwark>
        <Craft>1</Craft>
        <Arcana>1</Arcana>
        <HealthGain>1</HealthGain>
        </BasicEffect>
        <Effects />
        </Card>
        </CardsList>
        </CardCollection>
        ";

        public string filePartial =>
            @"<?xml version=""1.0"" encoding=""utf-16""?>
        <CardCollection xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
        <CardsList>
        <Card>
        <Name>Test1</Name>
        <Id>Test2</Id>
        <Text>YADA YADA YADA</Text>
        <Type>Kindle</Type>
        <Origin>StartingDeck</Origin>
        <BasicEffect>
        <Kindling>1</Kindling>
        <Wealth>1</Wealth>
        <Might>1</Might>
        <Bulwark>1</Bulwark>
        </BasicEffect>
        <Effects />
        </Card>
        <Card>
        <Name>NotATest</Name>
        <Id>MaybeItIs</Id>
        <Text>BLAH BLAH BLAH</Text>
        <Type>AsheOf</Type>
        <Origin>Boon</Origin>
        <BasicEffect>
        <Wander>1</Wander>
        <Craft>1</Craft>
        <Arcana>1</Arcana>
        <HealthGain>1</HealthGain>
        </BasicEffect>
        <Effects />
        </Card>
        </CardsList>
        </CardCollection>
        ";
    }
}
