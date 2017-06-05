using System;

namespace GenericApp
{
    internal static class MultiDictionarySample
    {
        private static void Execute(string[] args)
        {
            var numbers = new MultiDictionary<int, string>
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {1, "ich"},
                {2, "nee"},
                {3, "sun"}
            };

            DisplayValues(numbers);
            DisplayKeyValues(numbers);

            numbers.Remove(1);

            DisplayValues(numbers);
        }

        private static void DisplayKeyValues(MultiDictionary<int, string> numbers)
        {
            foreach (var kv in numbers)
            {
                Console.WriteLine("{0} {1}", kv.Key, kv.Value);
            }
            Console.WriteLine();
        }

        private static void DisplayValues(MultiDictionary<int, string> numbers)
        {
            foreach (var value in numbers.Values)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }
    }
}