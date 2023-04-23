using System;

class Program
{
    static void Main(string[] args)
    {
        Random random=new Random();
        int magicNumber=random.Next(1,100);
        Console.WriteLine("The magic number has been generated.");
        Console.Write("What is your guess? ");
        int guessedNum=int.Parse(Console.ReadLine());

        while(magicNumber!=guessedNum) {
            if(guessedNum>magicNumber) {
                Console.WriteLine("Lower");
                Console.Write("What is your guess? ");
                guessedNum=int.Parse(Console.ReadLine());
            }
            if(guessedNum<magicNumber) {
                Console.WriteLine("Higher");
                Console.Write("What is your guess? ");
                guessedNum=int.Parse(Console.ReadLine());
            }
        }

        if(guessedNum==magicNumber) {
            Console.WriteLine("You guessed it!");
        }


    }
}