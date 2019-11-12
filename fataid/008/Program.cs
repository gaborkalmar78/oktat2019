using System;
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


public class genericType<T>
{
    public int Count(T[] items)
    {
        return items.Length;

    }
    public T First(T[] items)
    {
        return items[0];

    }
}