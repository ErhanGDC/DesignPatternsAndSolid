using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class FileLogger
    {
        public void Handle(string Error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt",Error);
        }
    }
    public class Customer
    {
        private FileLogger obj = new FileLogger();
        public virtual void Add()
        {
            try
            {
                //DataBase Codes Here
            }
            catch (Exception ex)
            {
                obj.Handle(ex.ToString());
            }
        }
    }
}
