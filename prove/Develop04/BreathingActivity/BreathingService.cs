using System;

//The following class contains the business logic for the breathing activity
public class BreathingService
{




    public void startActivity(int duration)
    {


        //split the duration into pieces of seconds
        //where their sums will be equal to the duration
        List<int> splitSeconds = generateRandomNumbers(duration);


        for (int i = 0; i < splitSeconds.Count; i++)
        {
            //the breath in activity is a bit shorter -- 1 third of the time
            //and the breath out activity is a bit longer -- 2 thirds of the time
            int breathInTime = splitSeconds[i] / 3;
            int breathOutTime = 2 * (splitSeconds[i] / 3);

            Console.WriteLine();
            Console.WriteLine();
            countDownTimer(breathInTime, "Breath in...");
            Console.WriteLine();
            countDownTimer(breathOutTime, "Now breath out...");
        }


    }



    //show the seconds for a breath in or out activity
    private void countDownTimer(int randomSeconds, string breathType)
    {
        Console.Write($"{breathType}...");
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