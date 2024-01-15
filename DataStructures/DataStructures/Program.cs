using System;
using DataStructures.Array;

namespace DataStructures // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main()
        {
            Array<int> myArray = new Array<int>(10);
            
            myArray.AddElement(30);
            myArray.SetElement(1,10);
            myArray.AddElement(45);
            myArray.AddElement(32);
            myArray.AddElement(67);
            myArray.AddElement(12);
            myArray.AddElement(78);
            myArray.AddElement(54);
            myArray.AddElement(23);
            myArray.AddElement(55);

            myArray.Sort();
            
            Console.WriteLine("Sorted array elements:");
            for (int i = 0; i <= myArray.Length; i++)
            {
                Console.WriteLine(myArray.GetElement(i));
            }
        }
    }
}