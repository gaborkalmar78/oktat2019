using System.Collections.Generic;

namespace _008
{
    public static class PlayerListEx
    {
        public static string ToHtml(this List<Player> players)
        {
            string PlayerRows = "";
            for (int i = 0; i < players.Count; i++)
            {
                PlayerRows += players[i].ToHtml();
            }
            return PlayerRows;
        }
    }
}