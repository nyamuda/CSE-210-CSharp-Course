using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }


        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        static int SquareNumber(int num)
        {
            return num * num;
        }

        static void DisplayResult(string name, int squaredNum)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNum}");
        }

        string name = PromptUserName();
        int num = PromptUserNumber();
        int squaredNum = SquareNumber(num);

        DisplayResult(name, squaredNum);
    }
}