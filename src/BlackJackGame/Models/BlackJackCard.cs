using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class BlackJackCard : Card
    {
        public bool FaceUp { get; private set; }
        public int Value
        {
            get
            {
                if (FaceUp)
                    return Math.Min(10, (int) FaceValue);
                else
                {
                    return 0;
                }
            }
        }

        public BlackJackCard(Suit suit, FaceValue faceValue) : base(suit, faceValue)
        {
        }

        public void TurnCard()
        {
            FaceUp = !FaceUp;
        }
    }
}
