using System;

namespace CardGame
{
    public static class CardEx
    {
        public static string ToHtml(this Card card)
        {
            return $@"<table>
                <tr>
                    <td>Speed:</td>
                    <td>{card.MaxSpeed}</td>
                </tr>
                <tr>
                    <td>Weight:</td>
                    <td>{card.Weight}</td>
                </tr>
            </table>";
        }


        public static void CardSort(this Card[] cards, Func<Card, Card, bool> func)
        {
            Card c;
            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = 1; j < cards.Length; j++)
                {
                    if (func(cards[j - 1], cards[j]))
                    {
                        c = cards[j];
                        cards[j] = cards[j - 1];
                        cards[j - 1] = c;
                    }
                }
            }
        }
    }
}
