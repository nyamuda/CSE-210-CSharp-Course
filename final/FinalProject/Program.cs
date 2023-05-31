using System;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Clear();
        Console.WriteLine("Welcome to MeasureMate!");
        Console.WriteLine("This program allows you to convert between different units of measurement and offers an interactive quiz where you answer random conversion questions.");

        //First, we build the unit categories
        ConverterService.BuildCategories();

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
        }

        Console.WriteLine();
        Console.WriteLine("Goodbye...");




    }



}