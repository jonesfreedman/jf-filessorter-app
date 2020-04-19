using System;

namespace FilesSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the path: ");
                var path = Console.ReadLine();
                Sort sort = new Sort(path);
                Console.WriteLine("Sort successful!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error encountered " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
