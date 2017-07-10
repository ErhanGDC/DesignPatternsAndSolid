using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_1_
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
    public class Customer
    {
        private ILogger obj;
        public virtual void Add()
        {
            try
            {
                //Database works
            }
            catch (Exception ex)
            {
                obj.Log(ex.ToString());
            }
        }
        //Solution
        /// <summary>
        /// So here’s the modified code with INVERSION implemented.
        /// We have opened the constructor mouth and we expect someone else to pass the object rather than the customer class doing it.
        /// So now it’s the responsibility of the client who is consuming the customer object to decide which Logger class to inject.
        /// </summary>
        public Customer(ILogger logger)
        {
            obj = logger;
        }
    }

    public interface ILogger
    {
        void Log(string error);
    }
    public class FileLogger : ILogger
    {
        public void Log(string exception)
        {
            try
            {
                System.IO.File.WriteAllText(@"c:\Exceptions.txt", exception.ToString());
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Exceptions.txt", ex.ToString());
            }
        }
    }
    public class EverViewerLogger : ILogger
    {
        public void Log(string error)
        {
            Console.WriteLine("EverViewerLogger run");
        }
    }
    public class EMailLogger : ILogger
    {
        public void Log(string error)
        {
            Console.WriteLine("EMailLogger run");
        }
    }

}
