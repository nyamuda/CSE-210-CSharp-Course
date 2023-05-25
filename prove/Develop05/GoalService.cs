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

    public static void CreateSimpleGoal()
    {

        Console.Write("What is the name of your goal? ");
        var name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        var description = Console.ReadLine();
        Console.Write("What is the number of points associated with this goal? ");
        var targetPoints = int.Parse(Console.ReadLine());


        var simpleGoal = new SimpleGoal(name, description, targetPoints);
        simpleGoal.GoalType = "Simple Goal";

        _allGoals.Add(simpleGoal);


    }


}