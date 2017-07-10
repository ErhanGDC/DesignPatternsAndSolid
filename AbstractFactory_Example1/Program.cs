using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america); // to important
            world.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    /// 
   public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    public class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
    public class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }


    //Animals
    public class Wolf : Carnivore
    {
        public Wolf() { Console.WriteLine("Wolf Called"); }
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name.ToString());
        }
    }
    public class Bison : Herbivore { public Bison() { Console.WriteLine("Bison called"); } }
    public class Wildebeest : Herbivore { public Wildebeest() { Console.WriteLine("Wildebeest called"); } }
    public class Lion : Carnivore
    {
        public Lion() { Console.WriteLine("Lion called\n"); }

        public override void Eat(Herbivore h)
        {
            //Eat Wildebeest
            Console.WriteLine(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }

   public abstract class Herbivore { }
   public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
    public class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}
