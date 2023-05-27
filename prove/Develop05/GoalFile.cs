using Microsoft.VisualBasic.FileIO;
public static class GoalFile
{

    public static string GoalsFileName { get; set; }



    //Save all the current goals to a file (.csv)
    private static void SaveGoals()
    {

        var filePath = $"./files/{GoalsFileName}";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Goal_Type|Goal_Name|Goal_Description|Target_Points|Current_Points|Bonus|Times_Required|Times_Accomplished");

            foreach (var goal in GoalService.GetGoals())
            {


                var fullGoalInfo = "";

                //checklist goal has more fields
                if (goal.GoalType == "Checklist Goal")
                {
                    fullGoalInfo = SaveChecklistGoal((ChecklistGoal)goal);

                }

                else
                {
                    var goalType = goal.GoalType;
                    var name = goal.Name;
                    var description = goal.Description;
                    var targetPoints = goal.TargetPoints;
                    var currentPoints = goal.CurrentPoints;


                    fullGoalInfo = $"{goalType}|{name}|{description}|{targetPoints}|{currentPoints}";
                }
                writer.WriteLine(fullGoalInfo);
            }



        }



    }

    //Loads the goals from a file

    public static void LoadGoals()
    {
        try
        {
            Console.Write("What is the filename for the goal file? ");
            GoalsFileName = Console.ReadLine();
            var filePath = $"./files/{GoalsFileName}";
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("|");

                //skip the first line
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    var goalType = fields[0];
                    var name = fields[1];
                    var description = fields[2];
                    var targetPoints = int.Parse(fields[3]);
                    var currentPoints = int.Parse(fields[4]);




                    //checklist goal has this extra fields
                    if (goalType.Equals("Checklist Goal"))
                    {


                        //the extra fields a checklist goal has
                        var bonus = fields[5];
                        var timesRequired = fields[6];
                        var timesAccomplished = fields[7];

                        //create goal
                        var goal = new ChecklistGoal(goalType, name, description, targetPoints);
                        goal.Bonus = int.Parse(bonus);
                        goal.NumberOfTimesRequired = int.Parse(timesRequired);
                        goal.NumberAccomplished = int.Parse(timesAccomplished);
                        goal.CurrentPoints = currentPoints;
                        //add goal to the service
                        GoalService.AddGoal(goal);

                    }

                    if (goalType.Equals("Simple Goal"))
                    {
                        var goal = new SimpleGoal(goalType, name, description, targetPoints);
                        //add goal to the service
                        GoalService.AddGoal(goal);
                        goal.CurrentPoints = currentPoints;

                    }
                    if (goalType.Equals("Eternal Goal"))
                    {
                        var goal = new EternalGoal(goalType, name, description, targetPoints);
                        //add goal to the service
                        GoalService.AddGoal(goal);
                        goal.CurrentPoints = currentPoints;

                    }



                }
            }

        }
        catch (System.IO.FileNotFoundException)
        {

            Console.WriteLine();

            Console.WriteLine("Sorry, the file doesn't exists.");

            Console.WriteLine();
        }



    }


    //The function checks to see if there any goals to save
    public static void SaveToFile()
    {
        //if there are not goals
        if (GoalService.GetGoals().Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, you currently don't have any goals to save.");
            Console.WriteLine();
        }
        else
        {
            Console.Write("What is the filename for the goal file? ");
            GoalsFileName = Console.ReadLine();
            SaveGoals();
        }
    }

    // //check to see if goal doesn't already exists in the file
    // public static bool goalExistsAlready(string goal)
    // {
    //     var filePath = $"./files/{GoalsFileName}";
    //     using (StreamReader reader = new StreamReader(filePath))
    //     {
    //         var line = reader.ReadLine();
    //         if (line != null)
    //         {
    //             if (line == goal)
    //             {
    //                 return true;
    //             }

    //         }

    //     }
    //     return false;
    // }

    private static string SaveChecklistGoal(ChecklistGoal goal)
    {
        var goalType = goal.GoalType;
        var name = goal.Name;
        var description = goal.Description;
        var targetPoints = goal.TargetPoints;
        var currentPoints = goal.CurrentPoints;
        var bonus = goal.Bonus;
        var timesRequired = goal.NumberOfTimesRequired;
        var timesAccomplished = goal.NumberAccomplished;
        var fullGoalInfo = $"{goalType}|{name}|{description}|{targetPoints}|{currentPoints}|{bonus}|{timesRequired}|{timesAccomplished}";

        return fullGoalInfo;

    }



}