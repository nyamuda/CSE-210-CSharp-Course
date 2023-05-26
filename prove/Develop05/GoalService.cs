using System;

// This class contains all the logic done by the Goal class and its children
public static class GoalService
{
    static List<Goal> _allGoals = new List<Goal>();
    public static void AddGoal(Goal goal)
    {
        _allGoals.Add(goal);
    }

    //get all the goals
    public static List<Goal> GetGoals()
    {
        return _allGoals;
    }

    //get a list of the goals showing full information about each goal
    public static void ListGoalsInfo()
    {
        //if there are no goals

        if (GetGoals().Count == 0)
        {
            Console.WriteLine("You don't have any goals at the moment.");

        }

        else
        {
            Console.WriteLine("The goals are:");
            var index = 1;
            foreach (var goal in GetGoals())
            {
                Console.WriteLine($"{index}. {goal.GetGoalInfo()}");
                index++;

            }
        }
    }

    //get total points from all the goals
    public static int GetTotalPoints()
    {
        var totalPoints = 0;
        foreach (Goal goal in _allGoals)
        {
            totalPoints += goal.CurrentPoints;
        }
        return totalPoints;

    }

    public static void CreateChecklistGoal()
    {
        var checkListGoal = new ChecklistGoal();
        checkListGoal.CreateGoalInfo();

        _allGoals.Add(checkListGoal);


    }

    public static void AccomplishSimpleGoal()
    {
        var currentSimpleGoals = new List<Goal>();

        //get simple goals
        foreach (var goal in _allGoals)
        {
            if (goal.GoalType.Equals("Simple Goal"))
            {
                currentSimpleGoals.Add(goal);
            }
        }

        //show the menu
        Console.WriteLine("Your current simple goals are: ");
        for (int i = 0; i < currentSimpleGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {currentSimpleGoals[i].Name}");
        }




        //the simple goal accomplished
        Console.Write("Which goal did you accomplish? ");
        int optionSelected = int.Parse(Console.ReadLine());
        Goal accomplishedGoal = currentSimpleGoals[optionSelected - 1];


        //add points
        int pointsEarned = 50;
        accomplishedGoal.CurrentPoints += pointsEarned;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points.");



    }


}