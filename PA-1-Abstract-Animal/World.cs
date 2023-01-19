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
        private int Age, Weight;
        public abstract void printInfo();
        public abstract void makeNoise();
        public abstract void ageUp();

    }
    class Cat : Animal
    {
        public override void printInfo()
        {

        }
        public override void makeNoise()
        {

        }
        public override void ageUp()
        {

        }
    }
    class Cassowary : Animal
    {
        public override void printInfo()
        {

        }
        public override void makeNoise()
        {

        }
        public override void ageUp()
        {

        }
    }
    class Cow : Animal
    {
        public override void printInfo()
        {

        }
        public override void makeNoise()
        {

        }
        public override void ageUp()
        {

        }
    }
    class World
    {
        List<Animal> roster;
        static void Main(string[] args)
        {
            World zoo = new World();
            zoo.roster = new List<Animal>();
        }
    }
}
