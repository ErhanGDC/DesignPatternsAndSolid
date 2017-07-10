using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();
            aB.TemplateMethod();

            // Wait for user
            Console.ReadKey();
        }
    }/// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>
    abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        // The "Template method"
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    } /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }
      /// <summary>
  /// A 'ConcreteClass' class
  /// </summary>
  class ConcreteClassB : AbstractClass
  {
    public override void PrimitiveOperation1()
    {
      Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
    }
    public override void PrimitiveOperation2()
    {
      Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
    }
  }
}

