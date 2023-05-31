public static class Menu
{

    public static int DisplayRootMenu()
    {

        List<string> options = new List<string>
        {
            "Convert a unit",
            "Play a unit conversion game",
            "Quit"
        };



        //print the options
        Console.WriteLine();
        PrintOptions(options);


        Console.Write("Select a choice from the menu: ");
        int selectedOption;

        try
        {
            selectedOption = int.Parse(Console.ReadLine());
        }
        catch (System.FormatException)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid option selected. Please try again.");
            selectedOption = DisplayRootMenu();
        }



        while (selectedOption < 1 || selectedOption > 3)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid option selected. Please try again.");
            Console.WriteLine();

            //print the options again
            PrintOptions(options);
            Console.Write("Select a choice from the menu: ");
            selectedOption = int.Parse(Console.ReadLine());
        }

        return selectedOption;


    }

    //The function only prints the given options
    private static void PrintOptions(List<string> options)
    {
        Console.WriteLine("Menu Options:");
        for (int i = 0; i < options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");

        }

    }

    //Display the unit converter menu
    public static int DisplayCategoryMenu()
    {

        //print the menu of categories
        for (int i = 0; i < ConverterService.GetAllCategories().Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ConverterService.GetAllCategories()[i].Name}");

        }

        Console.Write("Which category of units would you like to convert? ");
        int selectedOption;

        try
        {
            selectedOption = int.Parse(Console.ReadLine());
        }
        catch (System.FormatException)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid option selected. Please try again.");
            selectedOption = DisplayCategoryMenu();
        }

        while (selectedOption < 1 || selectedOption > ConverterService.GetAllCategories().Count + 1)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid option selected. Please try again.");
            Console.WriteLine();

            //print the options again
            Console.Write("Which category of units would you like to convert? ");
            selectedOption = int.Parse(Console.ReadLine());
        }

        return selectedOption;


    }
}