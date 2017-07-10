using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeRealWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //FACADE
            Mortgage mortgage = new Mortgage();

            //Evaluate Mortgage eligibility for customer
            Customer customer = new Customer("Erhan Gidici");
            bool eligible = mortgage.IsEligible(customer, 50000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));

            Console.ReadLine();
        }
    }
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank For " + c.Name);
            return true;
        }
    }
    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }
    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check Loans for " + c.Name);
            return false;
        }
    }
    class Customer
    {
        private string _name;
        //Constructor
        public Customer(string name)
        {
            this._name = name;
        }
        //Gets the Name
        public string Name
        {
            get { return _name; }
        }
    }
    class Mortgage
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
       cust.Name, amount);

            bool eligible = true;
            //Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }
            return eligible;
        }
    }
}
