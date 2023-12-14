namespace Contructors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o1= new Class1();
            Class1 o2 = new Class1(15);
        }
    }
    public class Class1
    {
        //public Class1 ()
        //{
        //    Console.WriteLine("Default Ctor!");
        //}
        //public Class1(int i)
        //{
        //    Console.WriteLine("Parameterized Ctor!"+ i);
        //}
        public Class1(double j = 10)
        {
            Console.WriteLine("Default value Ctor!"+j);
        } 
    }
}
