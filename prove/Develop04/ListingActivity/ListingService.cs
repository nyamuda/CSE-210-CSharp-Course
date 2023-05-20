using System;

//The following class contains the business logic for the Listing activity
public class ListingService : IActivityService
{




    public void startActivity(int duration)
    {


        thinkPrompt();
        userInput(duration);


    }

    //show the seconds for a listing activity
    public void countDownTimer(int randomSeconds, string sentence)
    {
        Console.Write($"{sentence}...");
        for (int i = randomSeconds; i > 0; i--)
        {

            Console.Write($"{i}");
            Thread.Sleep(1000);
            Console.Write("\b \b");

        }
    }




    //the function splits an integer(the argument) into random numbers
    // and ensures that the sum of those random numbers is equal to the argument
    public List<int> generateRandomNumbers(int target)
    {
        Random random = new Random();
        List<int> randomNumbers = new List<int>();

        while (target > 0)
        {
            if (target >= 20)
            {
                int randomNumber = random.Next(8, 14);
                randomNumbers.Add(randomNumber);
                target -= randomNumber;
            }
            else
            {
                int randomNumber = random.Next(6, 11);
                randomNumbers.Add(randomNumber);
                target -= randomNumber;
            }
        }

        return randomNumbers;
    }



    // display the first prompt for the user to think about
    public void thinkPrompt()
    {
        List<string> prompts = new List<string>();

        prompts.Add("Who are people that you appreciate?");
        prompts.Add("What are personal strengths of yours?");
        prompts.Add("Who are people that you have helped this week?");
        prompts.Add("When have you felt the Holy Ghost this month?");
        prompts.Add("Who are some of your personal heroes?");

        Random random = new Random();
        int randValue = random.Next(0, prompts.Count - 1);

        string prompt = prompts[randValue];
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"---- {prompt} ----");

        Console.WriteLine();



        //show the countdown timer before the user gets started
        int randSeconds = random.Next(3, 6);
        this.countDownTimer(randSeconds, "You may begin in");
        Console.WriteLine();
    }


    //listen an get the user user input
    //the input will be multiple sentences
    public void userInput(int seconds)
    {
        List<string> entries = new List<string>();

        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("* ");
            Console.Write("");
            string input = Console.ReadLine().Trim();
            entries.Add(input);
        }

        Console.WriteLine($"You listed {entries.Count} items!");

    }




}