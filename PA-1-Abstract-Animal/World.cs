using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// defend design decision everything in same file
namespace PA_1_Abstract_Animal
{
    abstract class Animal
    {
        private string Name, Noise;
        private int Age;
        private double Weight;
        public Animal(string name, int age, double weight, string noise)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Noise = noise;
        }
        public virtual void printInfo()
        {
            Console.WriteLine("Name: " + Name + "\nAge: " + Age + "\nWeight: " + Weight);
        }
        public void makeNoise()
        {
            Console.WriteLine(Noise);
        }
        public void ageUp()
        {
            Age++;
        }

    }
    class Cat : Animal
    {
        public Cat(string name, int age, double weight) : base(name, age, weight, "Meow!")
        {}
        public override void printInfo()
        {
            Console.WriteLine("This is a cat.");
            base.printInfo();
        }
    }
    class Cassowary : Animal
    {
        public Cassowary(string name, int age, double weight) : base(name, age, weight, "??")
        { }
        public override void printInfo()
        {
            Console.WriteLine("This is a cassowary.");
            base.printInfo();
        }
    }
    class Cow : Animal
    {
        public Cow(string name, int age, double weight) : base(name, age, weight, "MOO!")
        { }
        public override void printInfo()
        {
            Console.WriteLine("This is a cow.");
            base.printInfo();
        }
    }
    class World
    {

        List<Animal> roster;
        public void printInstructions()
        {
            Console.WriteLine("Type 1 to add an animal to the zoo.");
            Console.WriteLine("Type 2 to remove an animal to the zoo.");
            Console.WriteLine("Type 3 to print an animals information.");
            Console.WriteLine("Type 4 to print every animal's name in the zoo.");
            Console.WriteLine("Type 5 to have an animal make noise.");
            Console.WriteLine("Type 6 to have every animal make noise one at a time.");
            Console.WriteLine("Type 7 to increase the age of every animal by a year.");
            Console.WriteLine("Type q to quit the program.");
            Console.WriteLine("Type h to print these instructions again.");
        }
        static void Main(string[] args)
        {
            World zoo = new World();
            zoo.roster = new List<Animal>();

            string user_input;
            Console.WriteLine("Welcome to the zoo. You can add animals, remove animals, print an animal's info" +
                "have an animal make noise, and increase the age of an animal.");
            zoo.printInstructions();
            user_input = Console.ReadLine();
            while (user_input != "q")
            {
                switch (user_input)
                {
                    case "1":
                        string name;
                        int age;
                        double weight;
                        
                        Console.WriteLine("What is the animal's name? ");
                        name = Console.ReadLine();

                        Console.WriteLine("What is the animal's age? ");
                        age = int.Parse(Console.ReadLine());

                        Console.WriteLine("What is the animal's weight? ");
                        weight = double.Parse(Console.ReadLine());

                        Console.WriteLine("What type of animal is it? Available options: cat, cassowary, cow: ");
                        user_input = Console.ReadLine().ToLower();
                        // until a valid selection is made
                        while ( ! (user_input == "cat" || user_input == "cassowary" || user_input == "cassowary"))
                        {
                            Console.WriteLine("Please select cat, cassowary, or cow: ");
                            user_input = Console.ReadLine().ToLower();
                        }
                        if (user_input.ToLower() == "cat")
                        {
                            zoo.roster.Add(new Cat(name, age, weight));
                        }
                        else if (user_input.ToLower() == "cassowary")
                        {
                            zoo.roster.Add(new Cassowary(name, age, weight));
                        }
                        else if (user_input.ToLower() == "cow")
                        {
                            zoo.roster.Add(new Cow(name, age, weight));
                        }
                        break;
                    default:
                        break;
                }
                user_input = Console.ReadLine();
            }
        }
    }
}
