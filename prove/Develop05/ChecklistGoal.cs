using System;

public class ChecklistGoal : Goal

{
    public int NumberOfTimesRequired { set; get; }
    public int NumberAccomplished { get; set; }

    public int Bonus { get; set; }
    public ChecklistGoal(string GoalType, string Name, string Description, int TargetPoints) : base(GoalType, Name, Description, TargetPoints) { }



    public ChecklistGoal() { }

    public override string GetGoalInfo()
    {
        if (IsComplete())
        {
            var goal = $"[x] {this.Name} ({this.Description}) --- Goal completed: {this.NumberAccomplished}/{this.NumberOfTimesRequired}";
            return goal;
        }
        return $"[] {this.Name} ({this.Description}) --- Currently completed: {this.NumberAccomplished}/{this.NumberOfTimesRequired}";
    }

    public override void CreateGoalInfo()
    {
        Console.Write("What is the name of your goal? ");
        var name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        var description = Console.ReadLine();

        Console.Write("What is the number of points associated with this goal? ");
        var targetPoints = int.Parse(Console.ReadLine());

        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        var numberOfTimesRequired = int.Parse(Console.ReadLine());


        Console.WriteLine("What is the bonus for accomplishing it that many times?");
        var bonus = int.Parse(Console.ReadLine());




        this.Name = name;
        this.Description = description;
        this.TargetPoints = targetPoints;
        this.CurrentPoints = 0;
        this.NumberOfTimesRequired = numberOfTimesRequired;
        this.NumberAccomplished = 0;
        this.Bonus = bonus;
    }
}