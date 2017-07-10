using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov_Example_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDatabase> Customers = new List<IDatabase>();
            Customers.Add(new SilverCustomer());
            Customers.Add(new GoldCustomer());
            //Customers.Add(new Enquiry());  Electronic duck is not a real duck :P

            foreach (IDatabase item in Customers)
            {
                item.Add();
            }
        }
    }
    interface IDiscount
    {
        double getDiscount(double TotalSales);
    }
    interface IDatabase
    {
        void Add();
    }
    public class Enquiry : IDiscount
    {
        public double getDiscount(double TotalSales)
        {
            return TotalSales - 5;
        }
    }
    public class Customer : IDiscount, IDatabase
    {
        private MyException obj = new MyException();

        public virtual void Add()
        {
            try
            {
                //Database code goes here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.ToString());
            }
        }
        public virtual double getDiscount(double TotalSales)
        {
            return TotalSales;
        }
    }
    public class MyException
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
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
