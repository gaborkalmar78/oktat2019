using System;
using System.Collections.Generic;

namespace _019.Models
{
    static class Waitingroom
    {
        private static Dictionary<int, List<Player>> rooms = new Dictionary<int, List<Player>>();
        public static Player[] AddPlayer(Player player, int cap)
        {
            if (!rooms.ContainsKey(cap))
            {
                rooms.Add(cap, new List<Player>());
            }
            List<Player> room = rooms[cap];
            room.Add(player);
            Player[] group = null;
            if (room.Count == cap)
            {
                group = room.ToArray();
                room.Clear();
            }
            return group;
        }
    }
}