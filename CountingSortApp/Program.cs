using System;

namespace CountingSortApp
{
    public class CountingSort
    {
        public List<int> GetFrequencyArray()
        {
            List<int> inputArray;
            bool isValidate;
            Console.WriteLine($"Enter space-separated array of 100+ integers in 1...99 range:");
            do
            {
                inputArray = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                isValidate = ArrayValidation(inputArray);
            }
            while (!isValidate);
            List<int> frequencyArray = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                frequencyArray.Add(0);
            }
            for (int i = 0; i < inputArray.Count; i++)
            {
                frequencyArray[inputArray[i]]++;
            }
            return frequencyArray;
        }
        static bool ArrayValidation(List<int> inputArray)
        {
            if (inputArray.Count <= 100 || inputArray.Count > Math.Pow(10, 6))
            {
                Console.WriteLine("Incorrect array length, try again:");
                return false;
            }
            for (int i = 0; i < inputArray.Count; i++)
            {
                if (inputArray[i] <= 0 || inputArray[i] >= 100)
                {
                    Console.WriteLine($"{inputArray[i]} is incorrect value, enter correct values:");
                    return false;
                }
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CountingSort frequencyArray = new CountingSort();
            List <int> resultArray = frequencyArray.GetFrequencyArray();
            Console.WriteLine("Frequency array:");
            foreach (int integer in resultArray)
            {
                Console.Write(integer + " ");
            }
        }
    }
}