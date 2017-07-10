using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1
{
    class Program
    {
        static void Main(string[] args)
        {
            GoldCustomer dd = new GoldCustomer();
            Console.WriteLine(dd.getDiscount(100));

            ChangeRequest gc1 = new ChangeRequest();
            Console.WriteLine(gc1.getDiscount(100));

            SilverCustomer gc2 = new SilverCustomer();
            Console.WriteLine(gc2.getDiscount(100));

            Console.ReadLine();
        }
    }
   public class Customer
    {
        public virtual double getDiscount(double TotalSales)
        {
            return TotalSales;
        }
    }

   public class SilverCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 50;
        }
    }

   public class GoldCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 100;
        }
    }
    public class ChangeRequest : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 90;
        }
    }
}
