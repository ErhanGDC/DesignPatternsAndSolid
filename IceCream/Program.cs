using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCream
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 3; i++)
            {
                var type = Factory.Get(i);
                if (type!=null)
                {
                    Console.WriteLine("All Species :"+type.GetType().Name.ToString());
                    Console.WriteLine("This is Product " + type.Functionality());
                }
            }
        }
    }
    interface IIceCream
    {
        string Functionality();
    }
    class ChoclateIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Choclate Ice Cream";
        }
    }
    class VanillaIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Vanilla Ice cream";
        }
    }
    class StrawberryIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Strawberry Ice cream";
        }
    }

    static class Factory
    {
        /// <summary>
        /// This is the Factory method
        /// </summary>
        public static IIceCream Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new ChoclateIceCream();
                case 1:
                    return new VanillaIceCream();
                case 2:
                    return new StrawberryIceCream();
                default:
                    return null;
            }
        }
    }

}
