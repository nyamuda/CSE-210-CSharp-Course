using System;
class Program
{
    static void Main(string[] args)
    {

        int optionValue = selectOption();

        while (optionValue < 1 || optionValue > 4)
        {
            Console.WriteLine("Invalid option selected.");
            optionValue = selectOption();
        }


        //Breathing Activity
        if (optionValue == 1)
        {
            string message = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
            Breathing breathing = new Breathing("Breathing", message);
            breathing.greetingMessage();
            breathing.startBreathingActivity();
            breathing.sayGoodbye();
            optionValue = selectOption();
        }
        //Reflection Activity
        if (optionValue == 2)
        {
            string message = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
            Reflection reflection = new Reflection("Reflection", message);
            reflection.greetingMessage();
            reflection.startReflectionActivity();
            reflection.sayGoodbye();
            optionValue = selectOption();
        }
        //Listing Activity
        if (optionValue == 3)
        {
            string message = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
            Listing listing = new Listing("Listing", message);
            listing.greetingMessage();
            listing.startListingActivity();
            listing.sayGoodbye();
            optionValue = selectOption();
        }


        Console.WriteLine();
        Console.WriteLine("Goodbye.");


    }




    static int selectOption()
    {
        List<String> options = new List<String>();

        options.Add("Start breathing activity");
        options.Add("Start reflection activity");
        options.Add("Start listing activity");
        options.Add("Quit");


        Console.Clear();
        Console.WriteLine("Menu Options:");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.Write("Select choice from the menu: ");
        int selectedOption = int.Parse(Console.ReadLine());

        return selectedOption;


    }
}