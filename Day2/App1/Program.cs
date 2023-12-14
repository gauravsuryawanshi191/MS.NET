namespace App1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            obj.S = "Surya";
            obj.i2 = 1;
            Console.WriteLine(obj.i2);
            Console.WriteLine(obj.S);
        }
    }
    public class Class1
    {
        private int i;
        private string s;   
        public string S
        {
            get { return s; }
            set { s = value; }
        }
        
       public int i2 {  get; set; }  

    }
}
