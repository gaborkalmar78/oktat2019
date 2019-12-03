using System;
using System.Collections.Generic;

namespace _008
{
    public static class CardEx
    {
        public static Card[] CreateDeck(int size)
        {
            Card[] deck = new Card[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                deck[i] = new Card(rnd);
            }
            return deck;
        }
        public static string ToHtml(this Card card)
        {
            return $@"<table rules=""all"" frame=""border"">
                <tr>
                    <th colspan=""2"">{card.Name}</th>
                </tr>
                <tr>
                    <td>Brand</td>
                    <td>{card.Brand}</td>
                </tr>
                <tr>
                    <td>MaxSpeed</td>
                    <td>{card.MaxSpeed}</td>
                </tr>
                <tr>
                    <td>Weight</td>
                    <td>{card.Weight}</td>
                </tr>
                <tr>
                    <td>Price</td>
                    <td>{card.Price}</td>
                </tr>
                <tr>
                    <td>Engine</td>
                    <td>{card.Engine}</td>
                </tr>
            </table>";
        }
    }
}