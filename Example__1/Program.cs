using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example__1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase i = new Customer();
            i.Add();

            IDatabaseReadSkill ir = new CustomerWithRead();
            ir.Read();
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
    interface IDatabaseReadSkill : IDatabase
    {
        void Read();
    }
    public class Enquiry : IDiscount
    {
        public double getDiscount(double TotalSales)
        {
            return TotalSales - 5;
        }
    }
    public class CustomerWithRead:IDatabase,IDatabaseReadSkill
    {
        public void Add()
        {
            Customer ctm = new Customer();
            ctm.Add();
        }
        public void Read()
        {
            Console.WriteLine("Customer wants to read");
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
