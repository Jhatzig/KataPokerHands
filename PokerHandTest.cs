using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KataPokerHands
{
    [TestClass]
    public class PokerHandTest
    {

        [TestMethod]
        public void WinWith_CardHigh_Nine()
        {
            List<Card> cards = new List<Card> 
            { 
                new Card { CardType = CardType.Hearts, Value = CardValue.Two},
                new Card { CardType = CardType.Diamonds, Value = CardValue.Three},  
                new Card { CardType = CardType.Spades, Value = CardValue.Five},  
                new Card { CardType = CardType.Clubs, Value = CardValue.Nine},  
                new Card { CardType = CardType.Diamonds, Value = CardValue.Four},    
            };

            PokerHand PokerHand = new PokerHand(cards ,null);
            var result = PokerHand.ResolveCards(cards);
            var excepted = new PokerHandResult { Card = new Card { Value = CardValue.Nine, CardType = CardType.Clubs }, Type = PokerType.HighCard };
            Assert.AreEqual(excepted.Type, result.Type);
            Assert.AreEqual(excepted.Card.Value, result.Card.Value);
            Assert.AreEqual(excepted.Card.CardType, result.Card.CardType);
        }

        [TestMethod]
        public void WinWith_Pair_Two()
        {
            List<Card> cards = new List<Card> 
            { 
                new Card { CardType = CardType.Hearts, Value = CardValue.Two},
                new Card { CardType = CardType.Diamonds, Value = CardValue.Two},  
                new Card { CardType = CardType.Spades, Value = CardValue.Five},  
                new Card { CardType = CardType.Clubs, Value = CardValue.Nine},  
                new Card { CardType = CardType.Diamonds, Value = CardValue.Four},    
            };

            PokerHand PokerHand = new PokerHand(cards, null);
            var result = PokerHand.ResolveCards(cards);
            var excepted = new PokerHandResult { Card = new Card { Value = CardValue.Two }, Type = PokerType.Pair };
            Assert.AreEqual(excepted.Type, result.Type);
            Assert.AreEqual(excepted.Card.Value, result.Card.Value);
        }

        [TestMethod]
        public void WinWith_ThreeOfAKing_Two()
        {
            List<Card> cards = new List<Card> 
            { 
                new Card { CardType = CardType.Hearts, Value = CardValue.Two},
                new Card { CardType = CardType.Diamonds, Value = CardValue.Two},  
                new Card { CardType = CardType.Spades, Value = CardValue.Two},  
                new Card { CardType = CardType.Clubs, Value = CardValue.Nine},  
                new Card { CardType = CardType.Diamonds, Value = CardValue.King},    
            };

            PokerHand PokerHand = new PokerHand(cards, null);
            var result = PokerHand.ResolveCards(cards);
            var excepted = new PokerHandResult { Card = new Card { Value = CardValue.Two }, Type = PokerType.ThreeOfAKind };
            Assert.AreEqual(excepted.Type, result.Type);
            Assert.AreEqual(excepted.Card.Value, result.Card.Value);
        }


        [TestMethod]
        public void PlayersOneWinWithHighCardAce()
        {
            List<Card> cardsOne = new List<Card> 
            { 
                new Card { CardType = CardType.Hearts, Value = CardValue.Two},
                new Card { CardType = CardType.Diamonds, Value = CardValue.Three},  
                new Card { CardType = CardType.Spades, Value = CardValue.Five},  
                new Card { CardType = CardType.Clubs, Value = CardValue.Nine},  
                new Card { CardType = CardType.Diamonds, Value = CardValue.King},    
            };

            List<Card> cardsTwo = new List<Card> 
            { 
                new Card { CardType = CardType.Clubs, Value = CardValue.Two},
                new Card { CardType = CardType.Hearts, Value = CardValue.Three},  
                new Card { CardType = CardType.Spades, Value = CardValue.Four},  
                new Card { CardType = CardType.Clubs, Value = CardValue.Height},  
                new Card { CardType = CardType.Hearts, Value = CardValue.Ace},    
            };

            PokerHand PokerHand = new PokerHand(cardsOne, cardsTwo);
            var result = PokerHand.Resolve();
            var excepted = new PokerHandResult { Winner = "Two", Card = new Card { Value = CardValue.Ace, CardType = CardType.Hearts } };
            Assert.AreEqual(excepted, result);

        }
    }
}
