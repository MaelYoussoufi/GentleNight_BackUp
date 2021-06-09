using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.DataModel;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    //Integration test to validate that the compendium config data are correctly loaded & formatted during dev cycles
    //Run regularly while updating card data
    [TestFixture]
    public class CardCompendiumValidation
    {
        [Test]
        public void CardCompendiumLoadsWithoutException()
        {
            var compendium = new CardCompendium();
            Assert.DoesNotThrow(() => compendium.Load());
        }

        [Test]
        public void CardCompendiumLoadsSomeCards()
        {
            var compendium = new CardCompendium();
            compendium.Load();
            Assert.That(compendium.CardList, Is.Not.Null);
            Assert.That(compendium.CardList, Is.Not.Empty);
        }

        [Test]
        public void CardCompendiumLoadsSomeCardsFromMultipleFiles()
        {
            var compendium = new CardCompendium();
            compendium.Load();
            Assert.That(compendium.FilesLoaded, Does.Contain("BarracksCards.txt"));
            Assert.That(compendium.FilesLoaded, Does.Contain("BaseCards.txt"));
            Assert.DoesNotThrow(() => compendium.GetCard("BasicMight"));
            Assert.DoesNotThrow(() => compendium.GetCard("BasicKindling"));
            Assert.DoesNotThrow(() => compendium.GetCard("BasicBoot"));
            Assert.That(compendium.GetCard("BasicMight"), Is.Not.Null);
            Assert.That(compendium.GetCard("BasicKindling"), Is.Not.Null);
            Assert.That(compendium.GetCard("BasicBoot"), Is.Not.Null);
        }
    }
}
