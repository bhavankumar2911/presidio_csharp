namespace PolymorphismApplication
{
    class Base
    {
        public virtual void PrintClassName ()
        {
            Console.WriteLine("Base Class");
        }
    }

    class Derived: Base
    {
        public override void PrintClassName()
        {
            Console.WriteLine("Derived Class");
        }
    }

    class MethodOverloading
    {
        public void PrintClassName()
        {
            Console.WriteLine("MethodOverloading Class");
        }

        public void PrintClassName(string parameter)
        {
            Console.WriteLine($"MethodOverloading Class with overloaded method. {parameter}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Base baseClass = new Derived();
            baseClass.PrintClassName();
        }
    }
}
