using System;

public class Goal
{
    public string GoalType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int TargetPoints { get; set; }
    public int CurrentPoints { get; set; }



    public Goal(string goalType, string name, string description, int targetPoints)
    {
        this.GoalType = goalType;
        this.Name = name;
        this.Description = description;
        this.TargetPoints = targetPoints;


    }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Goal() { }

    public virtual bool IsComplete()
    {
        return CurrentPoints >= TargetPoints;
    }

    public virtual void SaveGoal() { }
    public virtual void LoadGoal() { }
    public virtual void RecordEvent() { }



    public virtual string GetGoalInfo()
    {

        if (IsComplete())
        {
            var goal = $"[x] {this.Name} ({this.Description})";
            return goal;
        }
        return $"[] {this.Name} ({this.Description})";


    }

    public virtual void CreateGoalInfo()
    {
        Console.Write("What is the name of your goal? ");
        var name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        var description = Console.ReadLine();
        Console.Write("What is the number of points associated with this goal? ");
        var targetPoints = int.Parse(Console.ReadLine());


        this.Name = name;
        this.Description = description;
        this.TargetPoints = targetPoints;
        this.CurrentPoints = 0;

    }




}
