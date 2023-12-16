using System.Collections.Generic;
namespace sort
{
    internal interface ISorter<T>
    {
        List<T> Sort(List<T> list);
    }

    public class Sorter<T> : ISorter<T> where T : IComparable
    {
        public List<T> Sort(List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int firstIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (Comparer<T>.Default.Compare(list[j], list[firstIndex]) < 0)
                    {
                        firstIndex = j;
                    }
                }
                if (firstIndex != i)
                {
                    T temp = list[i];
                    list[i] = list[firstIndex];
                    list[firstIndex] = temp;
                }
            }
            return list;
        }
    }
    internal class Program
    {
        static void SortAndPrintList<T>(List<T> list) where T : IComparable
        {
            Sorter<T> sorter = new Sorter<T>();
            list = sorter.Sort(list);
            Console.WriteLine("Sorted Data:");
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Options:\n" +
                "1.Integer Sorting\n" +
                "2.String Sorting\n" +
                "3.Double Sorting");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    List<int> intList = new List<int> { 3, 1, 2, 5, 4 };
                    SortAndPrintList(intList);
                    break;

                case 2:
                    List<string> stringList = new List<string> { "Surya","Shubham","Saurabh","Shivani" };
                    SortAndPrintList(stringList);
                    break;
                case 3:
                    List<double> doublelist = new List<double> {2.89,5.43,2.23,8.76,4.98};
                    SortAndPrintList(doublelist);
                    break;

                default:
                    Console.WriteLine("!Invalid Choice!");
                    break;
            }
            Console.ReadLine();
        }
    }
}