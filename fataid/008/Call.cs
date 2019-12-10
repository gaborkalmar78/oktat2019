using System.Collections.Generic;

namespace _008
{
    public abstract class CallBase
    {
        public Player Call(Card card, Player[] opponents)
        {
            Player winner = null;
            int Winnerspeed = card.MaxSpeed;
            foreach (Player opponent in opponents)
            {
                foreach (Card ocard in opponent.Cards)
                {
                    if (ocard.MaxSpeed > Winnerspeed)
                    {
                        Winnerspeed = ocard.MaxSpeed;
                        winner = opponent;
                    }
                }
            }
            return winner;
        }
        protected abstract bool Check(Card card1, Card card2);

        public Card BestCard(List<Card> cards)
        {
            Card best = cards[0];
            for (int i = 1; i < cards.Count; i++)
            {
                if (Check(best, cards[i]))
                {
                    best = cards[i];
                }
            }
            return best;
        }
        public int WinnerIndex(Card[] cards)
        {
            int best = 0;
            for (int i = 1; i < cards.Length; i++)
            {
                if (Check(cards[best], cards[i]))
                {
                    best = i;
                }
            }
            return best;
        }
    }

    public class MaxSpeedCall : CallBase
    {
        protected override bool Check(Card card1, Card card2)
        {
            return card1.MaxSpeed < card2.MaxSpeed;
        }
        public override string ToString()
        {
            return "Max sebesség";
        }
    }

    public class MinSpeedCall : CallBase
    {
        protected override bool Check(Card card1, Card card2)
        {
            return card1.MaxSpeed > card2.MaxSpeed;
        }
        public override string ToString()
        {
            return "Min sebesség";
        }

    }
    public class MinWeightCall : CallBase
    {
        protected override bool Check(Card card1, Card card2)
        {
            return card1.Weight > card2.Weight;
        }
        public override string ToString()
        {
            return "Min súly";
        }
    }
    public class MaxWeightCall : CallBase
    {
        protected override bool Check(Card card1, Card card2)
        {
            return card1.Weight < card2.Weight;
        }
        public override string ToString()
        {
            return "Max súly";
        }
    }
}