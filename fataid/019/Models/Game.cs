using System;
using System.Collections.Generic;

namespace _019.Models
{
    public class Game
    {
        public static Dictionary<string, Player> SessionPlayers = new Dictionary<string, Player>();
        private int index = 0;
        public int ActPlayerID { get; set; }
        public Player ActPlayer
        {
            get { return Players[ActPlayerID]; }
        }
        public int CalleeID { get; set; }
        public Player Callee
        {
            get { return Players[CalleeID]; }
        }
        public string CallProp { get; set; }
        public int[] CallCards { get; set; }
        public List<Card> SelectedCards { get; set; }
        public List<Card> Table { get; set; }
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }
        // public Game(Card[] deck, string[] names)
        // {
        //     Deck = deck;
        //     Players = new Player[names.Length];
        //     for (int i = 0; i < names.Length; i++)
        //     {
        //         Players[i] = new Player(names[i]);
        //     }
        //     index = deck.Length;
        //     ActPlayer = 0;
        //     Callee = 0;
        //     CallProp = null;
        //     CallCards = new int[names.Length];
        //     //Game.Instance = this;
        // }
        public Game(Card[] deck, Player[] players)
        {
            Deck = deck;
            Players = players;
            index = deck.Length;
            ActPlayerID = 0;
            CalleeID = 0;
            CallProp = null;
            CallCards = new int[players.Length];
            SelectedCards = new List<Card>();
            Table = new List<Card>();
        }
        public void Deal(int size)
        {
            for (; size > 0; size--)
            {
                for (int i = 0; i < Players.Length; i++)
                {
                    index--;
                    if (index < 0)
                    {
                        return;
                    }
                    Deck[index].CurrentOwnerID = i;
                    Players[i].Deck.Add(Deck[index]);
                }
            }
        }
        public void Next()
        {
            ActPlayerID = (ActPlayerID + 1) % Players.Length;
        }
        public int GetWinner()
        {
            int best = 0;
            // while (!Players[best].Active)
            // {
            //     best++;
            // }
            // for (int i = (best + 1); i < Players.Length; i++)
            // {
            //     if (Players[i].Active && Players[best].Deck[CallCards[best]].Strength(CallProp) < Players[i].Deck[CallCards[i]].Strength(CallProp))
            //     {
            //         best = i;
            //     }
            // }
            // return best;
            for (int i = (best + 1); i < SelectedCards.Count; i++)
            {
                if (SelectedCards[best].Strength(CallProp) < SelectedCards[i].Strength(CallProp))
                {
                    best = i;
                }
                else
                {
                    SelectedCards[i].Winner = false;
                }
            }
            SelectedCards[best].Winner = true;
            return SelectedCards[best].CurrentOwnerID;
        }
        public void Reward(int winner)
        {
            // for (int i = 0; i < Players.Length; i++)
            // {
            //     if (Players[i].Active)
            //     {
            //         Players[winner].Deck.Add(Players[i].Deck[CallCards[i]]);
            //         Players[i].Deck.RemoveAt(CallCards[i]);
            //     }
            // }
            for (int i = 0; i < SelectedCards.Count; i++)
            {
                SelectedCards[i].PreviousOwnerID = SelectedCards[i].CurrentOwnerID;
                SelectedCards[i].CurrentOwnerID = winner;
            }
            Table.Clear();
            Table.AddRange(SelectedCards);
            Players[winner].Deck.AddRange(SelectedCards);
            SelectedCards.Clear();
        }
        public bool IsFinished()
        {
            int counter = 0;
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Active)
                {
                    counter++;
                }
                else
                {
                    //Players[i].Rank++;
                }
            }
            return counter < 2;
        }
        public void UpdateRanks()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i].LookAtTable = true;
                if (!Players[i].Active)
                {
                    Players[i].Rank++;
                }
            }
        }
        public void SortPlayers()
        {
            bool cont = false;
            for (int i = 0; i < Players.Length; i++)
            {
                cont = false;
                for (int j = 1; j < (Players.Length - i); j++)
                {
                    cont = CompareRank(ref Players[j - 1], ref Players[j]) || cont;
                }
                if (!cont)
                {
                    break;
                }
            }
        }

        private bool CompareRank(ref Player Player1, ref Player Player2)
        {
            if (Player1.Rank > Player2.Rank)
            {
                Player temp;
                temp = Player1;
                Player1 = Player2;
                Player2 = temp;
                return true;
            }
            return false;
        }

        public void SortPlayersOld()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                for (int j = 1; j < Players.Length; j++)
                {
                    if (Players[j - 1].Rank > Players[j].Rank)
                    {
                        Player player;
                        player = Players[j - 1];
                        Players[j - 1] = Players[j];
                        Players[j] = player;
                    }
                }
            }
        }
        public void Cheat()
        {
            int altered;
            for (int i = 0; i < Players.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        altered = 55;
                        break;
                    case 1:
                        altered = 0;
                        break;
                    case 2:
                        altered = 33;
                        break;
                    case 3:
                        altered = 11;
                        break;
                    case 4:
                        altered = 22;
                        break;
                    default:
                        altered = 99 + i;
                        break;
                }
                Players[i].OriginalID = i;
                Players[i].Rank = altered;
            }
        }
    }
}
