using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodRealWorld
{
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Product();
            daoProducts.Run();

            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>
    abstract class DataAccessObject
    {
        protected string connectionString;
        protected DataSet dataSet;
        public virtual void Connect()
        {
            // Make sure mdb is available to app
            connectionString =
              "provider=Microsoft.JET.OLEDB.4.0; " +
              "data source=..\\..\\..\\db1.mdb";
        }
        public abstract void Select();
        public abstract void Process();
        public virtual void Disconnect()
        {
            connectionString = "";
        }
        //The 'Template Method'
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }
    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    class Categories:DataAccessObject
    {
        public override void Select()
        {
            string sql = "Select CategoryName from Categories";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connectionString);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Categories");
        }
        public override void Process()
        {
            Console.WriteLine("Categories ---");
            DataTable dataTable = dataSet.Tables["Categories"];
            foreach (DataRow  row in dataTable.Rows)
            {
                Console.WriteLine(row["CategoryName"]);
            }
            Console.WriteLine();
        }
    }
    class Product:DataAccessObject
    {
        public override void Select()
        {
            string sql = "Select ProductName from Products";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connectionString);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Products");
        }
        public override void Process()
        {
            Console.WriteLine("Products ----");
            DataTable dataTable = dataSet.Tables["Products"];
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine(row["ProductName"]);
            }
            Console.WriteLine();
        }
    }
}
