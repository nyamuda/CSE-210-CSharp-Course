using System;

class Program
{
    static void Main(string[] args)
    {

        //first display the total points
        DisplayCurrentTotalPoints();


        //load general options
        var selectedGeneralOption = LoadGeneralMenu();


        while (selectedGeneralOption != 6)
        {
            //CREATE NEW GOAL
            if (selectedGeneralOption == 1)
            {
                //load goal options
                var selectedGoalOption = LoadGoalMenu();

                //create simple goal
                if (selectedGoalOption == 1)
                {
                    GoalService.CreateSimpleGoal();
                    DisplayCurrentTotalPoints();
                    selectedGeneralOption = LoadGeneralMenu();
                }

                //create eternal goal
                if (selectedGoalOption == 2)
                {
                    GoalService.CreateEternalGoal();
                    DisplayCurrentTotalPoints();
                    selectedGeneralOption = LoadGeneralMenu();
                }

                //create checklist goal
                if (selectedGoalOption == 3)
                {
                    GoalService.CreateChecklistGoal();
                    DisplayCurrentTotalPoints();
                    selectedGeneralOption = LoadGeneralMenu();
                }


            }


            //LIST THE GOALS
            if (selectedGeneralOption == 2)
            {
                GoalService.ListGoalsInfo();
                DisplayCurrentTotalPoints();
                selectedGeneralOption = LoadGeneralMenu();
            }

            //SAVE GOALS TO A FILE
            if (selectedGeneralOption == 3)
            {
                GoalFile.SaveToFile();
                DisplayCurrentTotalPoints();
                selectedGeneralOption = LoadGeneralMenu();
            }

            //LOAD GOALS FROM A FILE
            if (selectedGeneralOption == 4)
            {
                GoalFile.LoadGoals();
                DisplayCurrentTotalPoints();
                selectedGeneralOption = LoadGeneralMenu();
            }

            //RECORD EVENT
            if (selectedGeneralOption == 5)
            {
                GoalService.AccomplishGoal();
                DisplayCurrentTotalPoints();
                selectedGeneralOption = LoadGeneralMenu();

            }


        }


    }



    //The general menu
    static int LoadGeneralMenu()
    {
        Console.WriteLine();
        string[] menuOptions = { "Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit" };

        Console.WriteLine("Menu Options");
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{i + 1}. {menuOptions[i]}");
        }



        Console.Write("Select a choice from the menu: ");
        int selectedOption = int.Parse(Console.ReadLine());

        //If the user selects and invalid option)
        //keep them in a loop
        while (selectedOption < 1 || selectedOption > 6)
        {

            Console.WriteLine("Invalid option selected.");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            selectedOption = int.Parse(Console.ReadLine());
        }

        return selectedOption;
    }


    //Menu for the goals
    static int LoadGoalMenu()
    {
        Console.WriteLine();
        string[] menuOptions = { "Simple Goal", "Eternal", "Checklist Goal" };

        Console.WriteLine("Menu Options");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i + 1}. {menuOptions[i]}");
        }

        Console.Write("Which type of goal would you like to create? ");
        int selectedOption = int.Parse(Console.ReadLine());


        //If the user selects and invalid option
        //keep them in a loop
        while (selectedOption < 1 || selectedOption > 3)
        {

            Console.WriteLine("Invalid option selected.");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            selectedOption = int.Parse(Console.ReadLine());
        }

        return selectedOption;

    }


    //display current total points
    public static void DisplayCurrentTotalPoints()
    {
        Console.WriteLine();
        int totalPoints = GoalService.GetTotalPoints();
        Console.WriteLine($"You have {totalPoints} points.");

    }



}