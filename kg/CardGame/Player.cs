using System.Collections.Generic;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }

        private List<Card> cards = new List<Card>();
        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }

        public override string ToString()
        {
            return $"-={Name}=-";
        }

        public string ToHtml(bool winner)
        {
            string cardCells = "";
            for (int i = 0; i < Cards.Count; i++)
            {

                cardCells += $"<td>{Cards[i].ToHtml()}";
                if (winner)
                {
                    cardCells += $"<input name=\"card\" type=\"radio\" value=\"{i}\">";
                }
                cardCells += "</td>";
            }

            string html = $"<tr><td>{Name}";
            if (winner)
            {
                html += "<select name=\"call\">";
                html += "<option value=\"0\">Max Speed</option>";
                html += "<option value=\"1\">Min Speed</option>";
                html += "<option value=\"2\">Max Weight</option>";
                html += "</select>";
                html += "<input type=\"submit\" value=\"Call\">";
            }
            html += $"</td>{cardCells}</tr>";
            return html;
        }
    }
}