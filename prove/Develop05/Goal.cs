using System;

public class Goal
{
    public string GoalType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int TargetPoints { get; set; }
    public int CurrentPoints { get; set; }



    public Goal(string name, string description, int targetPoints)
    {
        this.Name = name;
        this.Description = description;
        this.TargetPoints = targetPoints;

    }

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




}
