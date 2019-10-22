using System;

namespace _006
{
    class Program
    {
        static void Main(string[] args)
        {
            Classes.Animal animal = new Classes.Animal();
            Classes.WarmBlooded warm = new Classes.WarmBlooded();
            Classes.Bird bird = new Classes.Bird();
            bird.SetFlyHeight(5.0);
            Console.WriteLine((animal.Age).ToString());
        }
    }
}
