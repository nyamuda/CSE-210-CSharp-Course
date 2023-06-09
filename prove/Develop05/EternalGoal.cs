using System;

public class EternalGoal : Goal

{

    public EternalGoal(string GoalType, string Name, string Description, int TargetPoints) : base(GoalType, Name, Description, TargetPoints) { }



    public EternalGoal() { }



    //Eternal goal is never complete
    public override bool IsComplete()
    {
        return false;
    }

    public override void CreateGoalInfo()
    {
        Console.Write("What is the name of your goal? ");
        var name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        var description = Console.ReadLine();

        Console.Write("What is the number of points associated with this goal? ");
        var targetPoints = int.Parse(Console.ReadLine());



        this.GoalType = "Eternal Goal";
        this.Name = name;
        this.Description = description;
        this.TargetPoints = targetPoints;
        this.CurrentPoints = 0;

    }
}