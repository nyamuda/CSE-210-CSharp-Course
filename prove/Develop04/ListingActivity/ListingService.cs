using System;

//The following class contains the business logic for the breathing activity
public class ListingService
{




    public void startActivity(int duration)
    {


        //split the duration into pieces of seconds
        //where their sums will be equal to the duration
        List<int> splitSeconds = generateRandomNumbers(duration);


        Console.WriteLine();
        this.thinkPrompt();
        Console.Clear();
        for (int i = 0; i < splitSeconds.Count; i++)
        {
            this.reflectPrompt(splitSeconds[i]);
        }


    }


    // display the first prompt for the user to think about
    public void thinkPrompt()
    {
        List<string> prompts = new List<string>();

        prompts.Add("Think of a time when you stood up for someone else");
        prompts.Add("Think of a time when you did something really difficult.");
        prompts.Add("Think of a time when you helped someone in need.");
        prompts.Add("Think of a time when you did something truly selfless.");

        Random random = new Random();
        int randValue = random.Next(0, prompts.Count - 1);

        string prompt = prompts[randValue];

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"---- {prompt} ----");

        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");


        //wait for the use to press enter
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                int randSeconds = random.Next(3, 6);




                //show the countdown timer before the user gets started
                Console.WriteLine();
                Console.WriteLine("Now ponder each of the following questions as they relate to this experience:");
                this.countDownTimer(randSeconds);

                break;
            }
        }


    }


    //the reflection prompts
    public void reflectPrompt(int seconds)
    {
        List<string> prompts = new List<string>();

        prompts.Add("Why was this experience meaningful to you?");
        prompts.Add("Have you ever done anything like this before?");
        prompts.Add("How did you get started?");
        prompts.Add("How did you feel when it was complete?");
        prompts.Add("What made this time different than other times when you were not as successful?");
        prompts.Add("What is your favorite thing about this experience?");
        prompts.Add("What could you learn from this experience that applies to other situations?");
        prompts.Add("What did you learn about yourself through this experience?");

        Random random = new Random();
        int randValue = random.Next(0, prompts.Count - 1);

        string prompt = prompts[randValue];

        //show prompt and spinner
        Console.Write($"> {prompt} ");
        Activity.runSpinnerAnimation(seconds, seconds);
        Console.WriteLine();

    }



    //show the seconds for a breath in or out activity
    private void countDownTimer(int randomSeconds)
    {
        Console.Write($"You may begin in: ");
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



}