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
        public string getName()
        {
            return Name;
        }
        public virtual void printInfo()
        {
            Console.WriteLine("Name: " + Name + "\nAge: " + Age + "\nWeight: " + Weight);
        }
        public void makeNoise()
        {
            Console.WriteLine(Name + ": " + Noise);
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
            Console.WriteLine(getName() + " is a cat.");
            base.printInfo();
        }
    }
    class Cassowary : Animal
    {
        // is this noise good enough?
        public Cassowary(string name, int age, double weight) : base(name, age, weight, "Boom!")
        { }
        public override void printInfo()
        {
            Console.WriteLine(getName() + " is a cassowary.");
            base.printInfo();
        }
    }
    class Cow : Animal
    {
        public Cow(string name, int age, double weight) : base(name, age, weight, "MOO!")
        { }
        public override void printInfo()
        {
            Console.WriteLine(getName() + " is a cow.");
            base.printInfo();
        }
    }
    class World
    {

        List<Animal> roster;
        public void printInstructions()
        {
            Console.WriteLine("Type 1 to add an animal to the zoo.");
            Console.WriteLine("Type 2 to remove an animal from the zoo.");
            Console.WriteLine("Type 3 to print a particular animal's information.");
            Console.WriteLine("Type 4 to print every animal's information.");
            Console.WriteLine("Type 5 to print every animal's name in the zoo.");
            Console.WriteLine("Type 6 to have every animal make noise one at a time.");
            Console.WriteLine("Type 7 to increase the age of every animal by a year.");
            Console.WriteLine("Type q to quit the program.");
            Console.WriteLine("Type h to print these instructions again.");
        }
        // given the name of an animal, returns the index of the animal in the list, or -1 if not found
        public int getAnimalIndex(string name)
        {
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].getName() == name)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            World zoo = new World();
            zoo.roster = new List<Animal>();

            string user_input;
            Console.WriteLine("Welcome to the zoo. You can add animals, remove animals, print an animal's info" +
                "have an animal make noise, and increase the age of an animal.");
            zoo.printInstructions();

            // for use in the menu, accepts user input
            string name;
            int age;
            int index;
            double weight;

            // ToLower allows for H and Q to be valid, but not explicitly recommended
            user_input = Console.ReadLine().ToLower();
            while (user_input != "q")
            {
                switch (user_input)
                {
                    case "1":
                        
                        Console.WriteLine("What is the animal's name? ");
                        name = Console.ReadLine();

                        Console.WriteLine("What is the animal's age? ");
                        age = int.Parse(Console.ReadLine());

                        Console.WriteLine("What is the animal's weight? ");
                        weight = double.Parse(Console.ReadLine());

                        Console.WriteLine("What type of animal is it? Available options: cat, cassowary, cow: ");
                        user_input = Console.ReadLine().ToLower();
                        // until a valid selection is made
                        while ( ! (user_input == "cat" || user_input == "cassowary" || user_input == "cow"))
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
                    case "2":
                        Console.WriteLine("What is the name of the animal you want to remove from the zoo (in the case of duplicates, the first one found): ");
                        name = Console.ReadLine();
                        index = zoo.getAnimalIndex(name);
                        // if the animal is in the zoo, otherwise ignore request
                        if (index != -1)
                        {
                            zoo.roster.RemoveAt(index);
                        }
                        break;
                    case "3":
                        Console.WriteLine("What is the name of the animal whose information you want printed: ");
                        name = Console.ReadLine();
                        index = zoo.getAnimalIndex(name);
                        // if the animal is in the zoo, otherwise ignore request
                        if (index != -1)
                        {
                            zoo.roster[index].printInfo();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Every animal's information in the zoo: ");
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            zoo.roster[i].printInfo();
                        }
                        break;
                    case "5":
                        Console.WriteLine("Every animal's name in the zoo: ");
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            Console.WriteLine(zoo.roster[i].getName());
                        }
                        break;
                    case "6":
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            zoo.roster[i].makeNoise();
                        }
                        break;
                    case "7":
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            zoo.roster[i].ageUp();
                        }
                        break;
                    case "h":
                        zoo.printInstructions();
                        break;
                    case "q":
                        // quits
                        break;
                    default:
                        // invalid input
                        Console.WriteLine("Invalid Input. Try again, or type h to see the instructions again: ");
                        break;
                }
                // readability after each command
                Console.WriteLine("-----------------------------");
                user_input = Console.ReadLine().ToLower();
            }
        }
    }
}
