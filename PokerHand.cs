using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataPokerHands
{
    public class PokerHand
    {

        public List<Card> CardsOne { get; set; }
        public List<Card> CardsTwo { get; set; }


        public PokerHand(List<Card> cards0ne, List<Card> cardsTwo)
        {
            CardsOne = cards0ne;
            CardsTwo = cardsTwo;
        }

        public PokerHandResult ResolveCards(List<Card> cards)
        {
            PokerHandResult pokerResult = new PokerHandResult();
            bool isHighCardResult = cards.Where(x => (int)x.Value <= 10).Count() == 5 ? true : false;
            bool isPairCardResult = cards.GroupBy(x => x.Value).Select(x => x.First()).Count() == 4 ? true : false;
            bool isThreeofAKingResult = cards.GroupBy(x => x.Value).Select(x => x.First()).Count() == 3 ? true : false;
            
            if (isHighCardResult && !isPairCardResult && !isThreeofAKingResult)
            {
                return getHighCardResult(cards, pokerResult);
            }
            
            if (isPairCardResult)
            {
                return getPairCardResult(cards, pokerResult);
            }

            if (isThreeofAKingResult)
            {
                return getThreeOfAKingCardResult(cards, pokerResult);
            }
            
            return pokerResult;
        }

        private static PokerHandResult getHighCardResult(List<Card> cards, PokerHandResult pokerResult)
        {

            int maxValue = cards.Max(x => (int)x.Value);
            Card card = cards.First(x => (int)x.Value == maxValue);
            pokerResult = new PokerHandResult { Card = card, Type = PokerType.HighCard };
            return pokerResult;
        }

        private static PokerHandResult getPairCardResult(List<Card> cards, PokerHandResult pokerResult)
        {
            var cardPair = cards.GroupBy(x => x.Value).Select(x => x.First()).First();
            Card card = new Card { Value = cardPair.Value };
            pokerResult = new PokerHandResult { Card = card, Type = PokerType.Pair };
            return pokerResult;
        }

        private static PokerHandResult getThreeOfAKingCardResult(List<Card> cards, PokerHandResult pokerResult)
        {
            var cardPair = cards.GroupBy(x => x.Value).Select(x => x.First()).First();
            Card card = new Card { Value = cardPair.Value };
            pokerResult = new PokerHandResult { Card = card, Type = PokerType.ThreeOfAKind };
            return pokerResult;
        }


        public PokerHandResult Resolve()
        {

            PokerHandResult pokerResult = new PokerHandResult();
            pokerResult = ResolveCards(CardsOne);
            //ResolveCards(CardsTwo);
            return pokerResult;
        }
    }

    public class PokerHandResult
    {
        public string Winner { get; set; }
        public Card Card { get; set; }
        public PokerType Type { get; set; }
    }
}
