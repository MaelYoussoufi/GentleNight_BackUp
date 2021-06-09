using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.DataModel.Card;
using Assets.Scripts.Helpers;

namespace Assets.Scripts.DataModel.Deck
{
    // Root card deck for serialisation & deck creation
    public class CardSetModel : ICloneable
    {
        public List<CardDataModel> CardSet = new List<CardDataModel>();

        public void Add(CardSetModel set)
        {
            CardSet.AddRange(set.CardSet);
        }

        public void Shuffle()
        {
            CardSet.Shuffle();
        }

        public object Clone()
        {
            var newSet = new CardSetModel();
            CardSet.ForEach((card) =>
            {
                newSet.CardSet.Add(card.GetCopy<CardDataModel>());
            });
            return newSet;
        }
    }
}
