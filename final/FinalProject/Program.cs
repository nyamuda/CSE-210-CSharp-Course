using System;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Clear();
        Console.WriteLine("Welcome to MeasureMate!");
        Console.WriteLine("This powerful program is designed to provide you with a seamless and efficient way to convert between various units of measurement.");
        Console.WriteLine("Whether you need to convert lengths, weights, temperatures, volumes, or more, our unit converter has got you covered.");


        //We display the root menu
        int rootMenuOption = Menu.DisplayRootMenu();

        while (rootMenuOption != 3)
        {
            //if user wants to convert a value
            if (rootMenuOption == 1)
            {
                await ConverterService.ConvertValue();
                rootMenuOption = Menu.DisplayRootMenu();
            }
            //if the user wants to play the quiz
            if (rootMenuOption == 2)
            {
                //display the unit categories
                Menu.DisplayCategoryMenu();
                //start the quiz
                await QuizService.StartQuizForCategory();
                rootMenuOption = Menu.DisplayRootMenu();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goodbye...");




    }



}