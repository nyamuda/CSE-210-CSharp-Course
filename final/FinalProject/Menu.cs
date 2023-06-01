public static class Menu
{

    public static int DisplayRootMenu()
    {

        List<string> options = new List<string>
        {
            "Convert a Unit",
            "Challenge Your Knowledge with a Unit Conversion Game",
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

    //Display a list of available categories for the quiz
    //The function allows the user to select the unit category (e.g., length, weight, volume, etc.) for the quiz.
    public static int DisplayCategoryMenu()
    {
        Console.Clear();
        QuizService.ClearCategories();
        //first build the categories
        QuizService.BuildCategories();
        Console.WriteLine("Menu Options:");
        var allCategories = QuizService.GetAllCategories();
        //print the menu of categories
        for (int i = 0; i < allCategories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {allCategories[i].Name}");

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

        while (selectedOption < 1 || selectedOption > allCategories.Count + 1)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid option selected. Please try again.");
            Console.WriteLine();

            //print the options again
            Console.Write("Which category of units would you like to convert? ");
            selectedOption = int.Parse(Console.ReadLine());
        }

        //Add the selected category to the quiz service/store
        QuizService.SetCategoryForQuiz(allCategories[selectedOption - 1]);

        return selectedOption;


    }




}