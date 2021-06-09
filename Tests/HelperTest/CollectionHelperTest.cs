using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Helpers;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Assets.Scripts.Tests.HelperTest
{
    public class CollectionHelperTest
    {
        [Test]
        public void ShufflingTest()
        {
            var listToShuffle = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var refList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.That(listToShuffle, Is.EqualTo(refList));
            listToShuffle.Shuffle();
            
            Assert.That(listToShuffle, Is.Not.Null);
            Assert.That(listToShuffle, Is.Not.Empty);
            Assert.That(listToShuffle, Has.Count.EqualTo(9));
            Assert.That(listToShuffle, Is.Not.EqualTo(refList));
        }

        [Test]
        public void GetDuplicateTestWithNoDuplicates()
        {
            var intListNoDuplicates = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var emptyList = new List<int>() ;
            List<int> nullList = null ;

            Assert.That(intListNoDuplicates.GetDuplicates(), Is.Empty);
            Assert.That(emptyList.GetDuplicates(), Is.Empty);
            Assert.That(nullList.GetDuplicates(), Is.Null);
        }
        [Test]
        public void GetDuplicateTest()
        {
            var intListWithDuplicates = new List<int>() { 9,1, 2,2, 3, 4, 5, 6, 7, 8,4, 9 };
            var duplicateList = intListWithDuplicates.GetDuplicates();

            Assert.That(duplicateList, Is.Not.Null);
            Assert.That(duplicateList, Is.Not.Empty);
            Assert.That(duplicateList.ToList(), Has.Count.EqualTo(3));
            Assert.That(duplicateList, Does.Contain(9));
            Assert.That(duplicateList, Does.Contain(2));
            Assert.That(duplicateList, Does.Contain(4));
        }
    }
}
