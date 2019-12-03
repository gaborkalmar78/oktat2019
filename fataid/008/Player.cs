using System.Collections.Generic;

namespace _008
{
    public class Player
    {
        public string Name { get; set; }
        private List<Card> cards = new List<Card>();
        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        public override string ToString()
        {
            return Name;
        }
        public string ToHtml()
        {
            string CardCells = "";
            for (int i = 0; i < Cards.Count; i++)
            {
                CardCells += $"<td>{Cards[i].ToHtml()}</td>";
            }
            return CardCells;
        }
    }
}