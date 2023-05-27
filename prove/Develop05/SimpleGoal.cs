using System;

public class SimpleGoal : Goal

{

    public SimpleGoal(string GoalType, string Name, string Description, int TargetPoints) : base(GoalType, Name, Description, TargetPoints) { }



    public SimpleGoal() { }



    public override void CreateGoalInfo()
    {
        Console.Write("What is the name of your goal? ");
        var name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        var description = Console.ReadLine();

        Console.Write("What is the number of points associated with this goal? ");
        var targetPoints = int.Parse(Console.ReadLine());



        this.GoalType = "Simple Goal";
        this.Name = name;
        this.Description = description;
        this.TargetPoints = targetPoints;
        this.CurrentPoints = 0;

    }
}