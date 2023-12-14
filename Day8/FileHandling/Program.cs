using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FileHandling
{
    internal class Program
    {
        static void Main()
        {
            Console.ReadLine();
            Class1.createDirectory();
            Console.WriteLine("Directory Created!");
            Console.ReadLine();
            Class1.createFile();
            Console.WriteLine("File Created!");
            //Console.ReadLine();
            //Class1.writeInFile();
            //Console.ReadLine();
            //Class1.readFromFile();
            Console.ReadLine();
            Class1.storeData();
            Console.WriteLine("File Writen");
            Console.ReadLine();
            Console.WriteLine("File Data:");
            Class1.readData();  

        }
    }
    public class Class1
    {
        public static void createDirectory()
        {
            Directory.CreateDirectory("E:\\temp");
        }
        public static void createFile()
        {
            FileInfo file = new FileInfo("E:\\temp\\a.txt");
            //File.Create("E:\\temp\\a.txt");
        }
        public static void writeInFile()
        {
            StreamWriter write = File.CreateText("E:\\temp\\a.txt");
            write.WriteLine("Surya");

            write.Close();
        }
        public static void readFromFile()
        {
            string s;
            StreamReader reader = File.OpenText("E:\\temp\\a.txt");
            while ((s = reader.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
            reader.Close();
        }
        public static void storeData()
        {
            Student s1 = new Student("Surya", 22);
            Student s2 = new Student("Saurabh", 23);
            DataContractJsonSerializer jser = new DataContractJsonSerializer(typeof(Student));
            Stream s = new FileStream("E:\\temp\\a.txt", FileMode.Create);
            jser.WriteObject(s, s1);
            //jser.WriteObject(s, s2);
            s.Close();
        }
        public static void readData()
        {
            DataContractJsonSerializer jser= new DataContractJsonSerializer(typeof (Student));  
            Stream s= new FileStream("E:\\temp\\a.txt",FileMode.Open);
            Student s1= (Student)jser.ReadObject(s);
            //Student s2 = (Student)jser.ReadObject(s);
            Console.WriteLine(s1);
            //Console.WriteLine(s2);
            s.Close();
        }

    }
    [Serializable]
    public class Student
    {
        public string name;
        public int age;
        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string? ToString()
        {
            return "Name: "+name+" Age:"+age;
        }
    }
}