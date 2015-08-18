using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostCommon
{
    /// <summary>
    /// Class 'MostCommonInteger'
    /// </summary>
    public class MostCommonInteger
    {
        /// <summary>
        /// The key is to use LINQ methods to find the most common elements, 
        /// and it will mainly use the following two methods both under Linq namespace:
        ///       Enumerable.GroupBy<TSource, TKey> Method (IEnumerable<TSource>, Func<TSource, TKey>)
        ///          Reference:https://msdn.microsoft.com/en-us/library/bb534501.aspx
        ///       Enumerable.Count<TSource> Method (IEnumerable<TSource>, Func<TSource, Boolean>)
        ///          Reference:https://msdn.microsoft.com/en-us/library/bb535181.aspx
        /// </summary>
        /// find the most common integer(s)  by LINQ, here comes the exactly 'stackoverflow' answer  
        ///    Reference: http://stackoverflow.com/questions/1169299/find-the-most-frequent-numbers-in-an-array-using-linq
        public int[] Most(int[] arr) 
        {
            int[] ar = new int[]{}; // create an local empty integer array for later return, waiting for argument passing in
            
            if (!arr.IsNullOrEmpty()) // When argument array is not null or empty -> go into if-clause
            {
                // group by value and count frequency
                var query = from i in arr.ToList()                
                    group i by i into g
                    select new { g.Key, Count = g.Count() };

                // compute the maximum frequency
                int frequency = query.Max(g => g.Count);

                // find the value with that frequency
                IEnumerable<int> modes = query
                    .Where(g => g.Count == frequency)
                    .Select(g => g.Key);

                // convert it back to array
                ar = modes.ToArray();
            }         
            // return array, it could be empty when passing in an empty or null array, check the cli sample outputs  
            return ar;                                             
        }
        
        /// <summary>
        ///  Call method 'Most' in Main() 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {

            // First of all, initialize sample arrays for benchmarks, empty and null conditions 
            int[] sample1 = new int[] {5,4,3,2,4,5,1,6,1,2,5,4};
            int[] sample2 = new int[] {1,2,3,4,5,1,6,7};
            int[] sample3 = new int[] {1,2,3,4,5,6,7};
            int[] sample4 = null;
            int[] sample5 = new int[] { };
            int[] arr;
                        
            // Class instantiation, in order to call 'Most' next
            MostCommonInteger mci = new MostCommonInteger();

            // sample1 {5,4,3,2,4,5,1,6,1,2,5,4}, output {5,4} 
            printInputArray(sample1);
            arr = mci.Most(sample1);
            printArray(arr);

            // sample2 {1,2,3,4,5,1,6,7}, output {1}
            printInputArray(sample2);
            arr = mci.Most(sample2);
            printArray(arr);

            // sample3 {1,2,3,4,5,6,7}, output {1,2,3,4,5,6,7}
            printInputArray(sample3);
            arr = mci.Most(sample3);
            printArray(arr);

            // sample4 is null, output warning message
            Console.WriteLine("Sample4 is null:");
            arr = mci.Most(sample4);
            printArray(arr);

            // sample5 is empty, output warning message
            Console.WriteLine("Sample5 is empty:");
            arr = mci.Most(sample5);
            printArray(arr);
        }

        // Create array print method just to display formated results on cli, after the array was returned
        static void printArray(int[] array) 
        {

            if (!array.IsNullOrEmpty()) 
            {
                Console.Write("The most common integer(s): {");
                Console.Write(string.Join(",", array));
                Console.WriteLine("}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Input array is either empty or null, can not be printed.");
                Console.ReadLine();
            }
        }

        // print input array
        static void printInputArray(int[] array)
        {
            if (!array.IsNullOrEmpty())
            {
                Console.Write("The input array: {");
                Console.Write(string.Join(",", array));
                Console.WriteLine("}");
            }
            else
            {
                Console.WriteLine("Input array is either empty or null, can not be printed.");
                Console.ReadLine();
            }
        }
    }

    // static class to store extension method
    static class A 
    {
        // Extension method to test if an array is null or empty 
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }
    }
}
