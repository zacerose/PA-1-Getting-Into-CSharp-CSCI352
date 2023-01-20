// Zachary Rose
// 1-24-2023
// CSCI 352
// This file contains the abstract animal class and three concrete subclasses, (cat, cassowary, cow), and a menu driven interface to add and remove them from a zoo, and to call their other functionality. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PA_1_Abstract_Animal
{
    // Class Animal
    // An abstract class for animals, contains information like name, noise, age, and weight, and an abstract method requiring a way to print this information
    abstract class Animal
    {
        private string Name, Noise;
        private int Age;
        private double Weight;

        // constructor for Animal, required to fill in private member variables
        // @string name the name of the animal
        // @int age the age of the animal
        // @double weight the weight of the animal
        // @string noise the noise an animal makes
        public Animal(string name, int age, double weight, string noise)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Noise = noise;
        }
        // @return string the name of the animal
        public string getName()
        {
            return Name;
        }

        // @return int the age of the animal
        public int getAge()
        {
            return Age;
        }
        // prints the information of the animal to console
        // @post information printed to console
        public virtual void printInfo()
        {
            Console.WriteLine("Name: " + Name + "\nAge: " + Age + "\nWeight: " + Weight);
        }
        // the animal makes a noise in the console
        // @post noise printed to console
        public void makeNoise()
        {
            Console.WriteLine(Name + ": " + Noise);
        }
        // increases the age of the animal by one. To be overriden by subclass adding more age based information.
        // @post age increased by one
        public virtual void ageUp()
        {
            Age++;
        }

    }
    // Class Cat
    // A cat is an animal that meows
    class Cat : Animal
    {
        // constructor for cat, fills in animal information and calls base Animal constructor
        // @string name name of the cat
        // @int age age of the cat
        // @double weight weight of the cat
        public Cat(string name, int age, double weight) : base(name, age, weight, "Meow!")
        {}
        
        // prints the cat's info
        // @post cat's info printed to console
        public override void printInfo()
        {
            Console.WriteLine(getName() + " is a cat.");
            base.printInfo();
        }
        
        // increases the cat's age by one year and prints the "age status." A cat 11 years or older is considered senior in this case.
        // @post cat's age increased, and "age status" printed to console
        public override void ageUp()
        {
            base.ageUp();
            if (getAge() >= 11)
            {
                Console.WriteLine(getName() + '(' + getAge() + ')' + " is getting a little old for a cat.");
            }
            else
                Console.WriteLine(getName() + '(' + getAge() + ')' + " is still young and spry for a cat!");
        }
    }
    // Class Cassowary
    // A cassowary is a bird that makes a low boom-like noise
    class Cassowary : Animal
    {
        // constructor for cassowary, fills in animal information and calls base Animal constructor
        public Cassowary(string name, int age, double weight) : base(name, age, weight, "Boom!")
        { }
        
        // prints the cassowary's info
        // @post cassowary's info printed to console
        public override void printInfo()
        {
            Console.WriteLine(getName() + " is a cassowary.");
            base.printInfo();
        }

        // increases the cassowary's age by one year and prints the "age status." A cassowary lives 40-50 years, so I'll consider 47 years to be senior in this case (arbitrary)
        // @post cassowary's age increased, and "age status" printed to console
        public override void ageUp()
        {
            base.ageUp();
            if (getAge() >= 47)
            {
                Console.WriteLine(getName() + '(' + getAge() + ')' + " is getting a little old for cassowary.");
            }
            else
                Console.WriteLine(getName() + '(' + getAge() + ')' + " is still young and spry for a cassowary!");
        }
    }
    // Class Cow
    // A cow is an animal that moos and probably eats grass
    class Cow : Animal
    {
        // constructor for cow, fills in animal information and calls base Animal constructor
        public Cow(string name, int age, double weight) : base(name, age, weight, "MOO!")
        { }
        
        // prints the cow's info
        // @post cow's info printed to console
        public override void printInfo()
        {
            Console.WriteLine(getName() + " is a cow.");
            base.printInfo();
        }

        // increases the cow's age by one year and prints the "age status." A cow in the wild lives about 26 years, so we'll consider a 24 year old cow to be senior.
        // @post cat's age increased, and "age status" printed to console
        public override void ageUp()
        {
            base.ageUp();
            if (getAge() >= 24)
            {
                Console.WriteLine(getName() + '(' + getAge() + ')' + " is getting a little old for a cow.");
            }
            else
                Console.WriteLine(getName() + '(' + getAge() + ')' + " is still young and spry for a cow!");
        }
    }
    
    // Class World
    // main class, a list of animals called a zoo and a driver for the user to make changes to the zoo from the console
    class World
    {
        // the list of animals in the zoo
        List<Animal> roster;

        // prints the possible commands that the user can use
        // @post menu commands printed to console
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

        // given the name of an animal, returns the index of the animal in the roster, or -1 if not found
        // @string name name of the animal to search for
        // @return the index of the animal in the roster, or -1 if not found
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

        // contains the menu driver for controlling the upkeep of the zoo
        static void Main(string[] args)
        {
            World zoo = new World();
            zoo.roster = new List<Animal>();

            // used for certain menu commands, and in the control of the menu loop
            string user_input;

            Console.WriteLine("Welcome to the zoo. You can add animals, remove animals, print an animal's info" +
                "have an animal make noise, and increase the age of an animal.");
            zoo.printInstructions();

            // for use in the menu, accepts user input for animal information
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
                    // add an animal to the zoo
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
                        if (user_input == "cat")
                        {
                            zoo.roster.Add(new Cat(name, age, weight));
                        }
                        else if (user_input == "cassowary")
                        {
                            zoo.roster.Add(new Cassowary(name, age, weight));
                        }
                        else if (user_input == "cow")
                        {
                            zoo.roster.Add(new Cow(name, age, weight));
                        }
                        break;
                    // remove an animal from the zoo
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
                    // print a particular animal's information
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
                    // print every animal's information one at a time
                    case "4":
                        Console.WriteLine("Every animal's information in the zoo: ");
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            zoo.roster[i].printInfo();
                            Console.WriteLine();
                        }
                        break;
                    // prints every animal's name
                    case "5":
                        Console.WriteLine("Every animal's name in the zoo: ");
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            Console.WriteLine(zoo.roster[i].getName());
                        }
                        break;
                    // has every animal in the zoo roster make noise
                    case "6":
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            zoo.roster[i].makeNoise();
                        }
                        break;
                    // every animal in the zoo roster becomes one year older
                    case "7":
                        for (int i = 0; i < zoo.roster.Count; i++)
                        {
                            zoo.roster[i].ageUp();
                        }
                        break;
                    // re-prints instructions
                    case "h":
                        zoo.printInstructions();
                        break;
                    // quits the program
                    case "q":
                        // quits
                        break;
                    // if no other commands are met, request another input
                    default:
                        // invalid input
                        Console.WriteLine("Invalid Input. Try again, or type h to see the instructions again: ");
                        break;
                }
                // readability line after each command
                Console.WriteLine("-----------------------------");
                user_input = Console.ReadLine().ToLower();
            }
        }
    }
}
