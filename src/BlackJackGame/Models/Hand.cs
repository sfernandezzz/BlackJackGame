using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackGame.Models;

namespace BlackJackGame.Tests.Models
{
    public class Hand
    {
        public int NrOfCards { get { return _cards.Count; } }
        public int Value { get {return CalculateValue();} }
        public IEnumerable<BlackJackCard> Cards => _cards;

        private IList<BlackJackCard> _cards;

        public void AddCard(BlackJackCard blackJackCard)
        {
            _cards.Add(blackJackCard);
        }

        private int CalculateValue()
        {
            int total = 0;

            foreach (var card in _cards)
            {
                if (total < 20 && card.Value == 1)
                    total += 11;
                else
                    total += card.Value;
            }

            return total;
        }

        public Hand()
        {
            _cards = new List<BlackJackCard>();
        }

        public void TurnAllCardsFaceUp()
        {
            foreach (var card in _cards)
            {
                if(!card.FaceUp)
                    card.TurnCard();
            }
        }
    }
}
