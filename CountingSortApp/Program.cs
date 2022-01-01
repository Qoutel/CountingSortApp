using System;

namespace CountingSortApp
{
    class Program
    {
        static bool LengthValidation (int arrayLength)
        {
            if (arrayLength <= 0 || arrayLength > Math.Pow(10,6))
            {
                Console.WriteLine("Incorrect array length, try again:");
                return false;
            }
            return true;
        }
        static bool ArrayValidation(List<int> inputArray, int arrayLength)
        {
            if (inputArray.Count != arrayLength)
            {
                Console.WriteLine($"The number of integers in array must be not less and not above than {arrayLength}, try again:");
                return false;
            }
            for (int i = 0; i < inputArray.Count; i++)
            {
                if (inputArray[i] <= 0 || inputArray[i] >=100)
                {
                    Console.WriteLine($"{inputArray[i]} is incorrect value, enter correct values:");
                    return false;
                }
            }
            return true;
        }
        static List<int> GetFrequencyArray (List<int> inputArray)
        {
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
        static void Main(string[] args)
        {
            int arrayLength;
            bool isValidateLength;
            bool isValidateArray;
            List<int> inputArray;
            Console.WriteLine("Enter array length:");
            do
            {
                isValidateLength = Int32.TryParse(Console.ReadLine(), out arrayLength) && LengthValidation(arrayLength);
            }
            while (!isValidateLength);
            Console.WriteLine($"Enter space-separated array of {arrayLength} integers in 1...99 range:");
            do
            {
                inputArray = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
                isValidateArray = ArrayValidation(inputArray, arrayLength);
            }
            while (!isValidateArray);
            List<int> output = GetFrequencyArray(inputArray);
            Console.WriteLine("Frequency array:");
            foreach (int i in output)
            {
                Console.Write(i + " ");
            }
        }
    }
}