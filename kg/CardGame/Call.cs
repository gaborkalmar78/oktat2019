using System.Collections.Generic;

namespace CardGame
{
    public abstract class CallBase
    {
        public Player Call(Card card, Player[] opponents)
        {
            Player winner = null;
            Card winnerCard = card;

            foreach (Player opponent in opponents)
            {
                foreach (Card oCard in opponent.Cards)
                {
                    if (Check(oCard, winnerCard))
                    {
                        winner = opponent;
                        winnerCard = oCard;
                    }
                }
            }

            return winner;
        }

        protected abstract bool Check(Card card1, Card card2);

        public Card Best(List<Card> cards)
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
    }
}

public class MaxSpeedCall : CallBase
{
    protected override bool Check(Card card1, Card card2)
    {
        return card1.MaxSpeed > card2.MaxSpeed;
    }
}
public class MinSpeedCall : CallBase
{
    protected override bool Check(Card card1, Card card2)
    {
        return card1.MaxSpeed < card2.MaxSpeed;
    }
}
}