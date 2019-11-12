﻿using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Card[] cards = new Card[] {
			new Card() {Name = "car1", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car2", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car3", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car4", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car5", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car6", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car7", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
			new Card() {Name = "car8", MaxSpeed = 0, Weight = 0, Price = 0, Brand = "", Engine = 0},
		};
		Game game = new Game(null, null);
		//Console.WriteLine("Hello World");
	}
}

public class Card {
	public string Name {get; set;}
	public string Brand {get; set;}
	public int MaxSpeed {get; set;}
	public int Weight {get; set;}
	public int Price {get; set;}
	public int Engine {get; set;}
}
public class Player {
	public List<Card> Cards {get; set;}
	
}

public class Game {
	public Game(Card[] cards, Player[] players) {
		NumOfCards = cards.Length;
		Cards = new List<Card>(cards);
		Players = players;
	}
	private List<Card> Cards;
	private Player[] Players;
	private int NumOfCards = 0;
	
	public void Shuffle() {
		List<Card> Original = new List<Card>(Cards);
		Cards.Clear();
		Random rand = new Random();
		for (int i = 0; i < NumOfCards; i++) {
			int iR = rand.Next(Original.Count);
			Cards.Add(Original[iR]);
			Original.RemoveAt(iR);
			
		}
	}
	
	public void Deal(int count) {
		for(int i = 0; i < count; i++) {
			foreach(Player p in Players) {
				p.Cards.Add(Cards[0]);
				Cards.RemoveAt(0);
			}
		}
	}
	public void Play() {
		
	}
	
	public Player WhoIsWinner() {
		for(int i = 0; i < Players.Length; i++) {
			if(Players[i].Cards.Count == NumOfCards) {
				return Players[i];
			}
		}
		return null;
	}
}

public class genericType<T> {
	public int Count(T[] items) {
		return items.Length;
		
	}
	public T First(T[] items) {
		return items[0];
		
	}
}