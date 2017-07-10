using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeEXample
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            Console.Read();
        }
    }

    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("SubSystemOne Method");
        }
    }

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThre Method");
        }
    }

    class SubSystemFour
    {
        public void Methodfour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }
    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade() {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }
        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ----");
            _one.MethodOne();
            _two.MethodTwo();
            _four.Methodfour();
        }
        internal void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }
}
