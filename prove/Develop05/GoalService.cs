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

    // CREATE GOALS

    public static void CreateChecklistGoal()
    {
        var checkListGoal = new ChecklistGoal();
        checkListGoal.CreateGoalInfo();

        _allGoals.Add(checkListGoal);


    }

    public static void CreateSimpleGoal()
    {
        var simpleGoal = new SimpleGoal();
        simpleGoal.CreateGoalInfo();

        _allGoals.Add(simpleGoal);

    }

    public static void CreateEternalGoal()
    {
        var eternalGoal = new EternalGoal();
        eternalGoal.CreateGoalInfo();

        _allGoals.Add(eternalGoal);


    }




    // ACCOMPLISH GOALS

    public static void AccomplishGoal()
    {

        //show the uncompleted goals
        Console.WriteLine("Your current goals are: ");
        for (int i = 0; i < _allGoals.Count; i++)
        {
            //if the goal is not complete
            if (!_allGoals[i].IsComplete())
            {
                Console.WriteLine($"{i + 1}. {_allGoals[i].Name}");
            }

        }




        //get the goal accomplished
        Console.Write("Which goal did you accomplish? ");
        int optionSelected = int.Parse(Console.ReadLine());
        Goal accomplishedGoal = _allGoals[optionSelected - 1];


        int earnedPoints = 0;
        //only if the goal is not complete
        if (!accomplishedGoal.IsComplete())
        {
            if (accomplishedGoal.GoalType.Equals("Simple Goal"))
            {
                earnedPoints = AccomplishSimpleGoal(accomplishedGoal);
            }

            if (accomplishedGoal.GoalType.Equals("Checklist Goal"))
            {
                earnedPoints = AccomplishChecklistGoal((ChecklistGoal)accomplishedGoal);

            }
            if (accomplishedGoal.GoalType.Equals("Eternal Goal"))
            {
                earnedPoints = AccomplishEternalGoal(accomplishedGoal);

            }

        }




        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points.");



    }


    private static int AccomplishSimpleGoal(Goal goal)
    {
        int earnedPoints = goal.TargetPoints;
        goal.CurrentPoints += earnedPoints;

        return earnedPoints;


    }

    private static int AccomplishChecklistGoal(ChecklistGoal goal)
    {
        //if this is the final time
        if (goal.NumberOfTimesRequired - goal.NumberAccomplished == 1)
        {
            //add bonus to the current points
            goal.CurrentPoints += goal.Bonus;
            goal.NumberAccomplished += 1;

            return goal.Bonus;
        }

        //add points
        int earnedPoints = goal.TargetPoints;
        goal.CurrentPoints += earnedPoints;

        //add to the total number of tasks completed
        goal.NumberAccomplished += 1;

        return earnedPoints;


    }

    private static int AccomplishEternalGoal(Goal goal)
    {
        int earnedPoints = goal.TargetPoints;
        goal.CurrentPoints += earnedPoints;

        return earnedPoints;


    }



}