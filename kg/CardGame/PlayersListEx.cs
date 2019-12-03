using System;
using System.Collections.Generic;

namespace CardGame
{
    public static class PlayersListEx
    {
        public static string ToHtml(this List<Player> players, int winner)
        {
            string playerRows = "";
            for (int i = 0; i < players.Count; i++)
            {
                playerRows += players[i].ToHtml(winner == i);
            }

            return "";
        }
    }
}
