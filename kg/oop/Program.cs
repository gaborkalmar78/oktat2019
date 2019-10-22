using System;

namespace oop
{
    class Program
    {
        static void Main(string[] args)
        {

            Classes.Animal animal = new Classes.Animal();


            Classes.WarmBlooded wormBlooded = new Classes.WarmBlooded();

            Classes.Bird bird = new Classes.Bird();

            Console.WriteLine(animal.Age);
        }
    }
}
