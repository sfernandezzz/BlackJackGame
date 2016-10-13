using BlackJackGame.Models;
using Xunit;

namespace BlackJackGame.Tests.Models
{

    public class HandTest
    {
        private Hand _aHand;

        public HandTest()
        {
            _aHand = new Hand();
        }

        [Fact]
        public void NewHand_HasNoCards()
        {
            Assert.Equal(0, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_EmptyHand_ResultsInHandWithOneCard()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            _aHand.AddCard(card);
            Assert.Equal(1, _aHand.NrOfCards);
        }

        [Fact]
        public void AddCard_AHandWithCards_AddsACard()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            BlackJackCard card2 = new BlackJackCard(Suit.Clubs, FaceValue.Three);
            _aHand.AddCard(card);
            _aHand.AddCard(card2);
            Assert.Equal(2, _aHand.NrOfCards);
        }

        [Fact]
        public void TurnAllCardsFaceUp_TurnsAllCardsFaceUp()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.AddCard(new BlackJackCard(Suit.Clubs, FaceValue.Two));
            _aHand.TurnAllCardsFaceUp();
            foreach (BlackJackCard c in _aHand.Cards)
                Assert.True(c.FaceUp);
        }

        [Fact]
        public void Value_EmptyHand_IsZero()
        {
            Assert.Equal(0, _aHand.NrOfCards);
        }

        [Fact]
        public void Value_HandWith6and5_Is11()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Six);
            BlackJackCard card2 = new BlackJackCard(Suit.Hearts, FaceValue.Five);
            card.TurnCard();
            card2.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(card2);
            Assert.Equal(11, _aHand.Value);
        }

        [Fact]
        public void Value_HandWith5AndKing_Is15()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Five);
            BlackJackCard card2 = new BlackJackCard(Suit.Hearts, FaceValue.King);
            card.TurnCard();
            card2.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(card2);
            Assert.Equal(15, _aHand.Value);
        }

        [Fact]
        public void Value_HandWithCardsFacingDown_DoesNotAddValuesOfCardsFacingDown()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Five);
            BlackJackCard card2 = new BlackJackCard(Suit.Hearts, FaceValue.King);
            _aHand.AddCard(card);
            _aHand.AddCard(card2);
            Assert.Equal(0, _aHand.Value);
        }

        [Fact]
        public void Value_HandWithAceAndNotExceeding21_TakesAceAs11()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            BlackJackCard card2 = new BlackJackCard(Suit.Hearts, FaceValue.Five);
            card.TurnCard();
            card2.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(card2);
            Assert.Equal(16, _aHand.Value);
        }

        [Fact]
        public void ValueHandWithAceAndExceeding21_TakesAceAs1()
        {
            BlackJackCard card = new BlackJackCard(Suit.Hearts, FaceValue.King);
            BlackJackCard card2 = new BlackJackCard(Suit.Hearts, FaceValue.Queen);
            BlackJackCard card3 = new BlackJackCard(Suit.Hearts, FaceValue.Ace);
            card.TurnCard();
            card2.TurnCard();
            card3.TurnCard();
            _aHand.AddCard(card);
            _aHand.AddCard(card2);
            _aHand.AddCard(card3);
            Assert.Equal(21, _aHand.Value);
        }
    }
}
