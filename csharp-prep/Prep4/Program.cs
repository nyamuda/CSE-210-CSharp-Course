using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> allNumbers = new List<int>();


        int num = 1;
        int sum = 0;
        float average;
        float largest;

        while (num != 0)
        {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            allNumbers.Add(num);

        }

        foreach (int val in allNumbers)
        {
            sum += val;
        }

        average = (sum / allNumbers.Count);
        largest = allNumbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");



    }
}