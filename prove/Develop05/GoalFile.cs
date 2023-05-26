using Microsoft.VisualBasic.FileIO;
public static class GoalFile
{

    public static string GoalsFileName { get; set; }



    //Save all the current goals to a file (.csv)
    public static void SaveGoals()
    {

        var filePath = $"./files/{GoalsFileName}";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Goal_Type|Goal_Name|Goal_Description|Target_Points|Current_Points|Bonus|Times_Required|Times_Accomplished");

            foreach (var goal in GoalService.GetGoals())
            {
                var goalType = goal.GoalType;
                var name = goal.Name;
                var description = goal.Description;
                var targetPoints = goal.TargetPoints;
                var currentPoints = goal.CurrentPoints;

                var fullGoalInfo = $"{goalType}|{name}|{description}|{targetPoints}|{currentPoints}";

                //check to see if the doesn't already exists in the file

                writer.WriteLine(fullGoalInfo);
            }



        }



    }

    //Loads the goals from a file

    public static void LoadGoals()
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

                //create goal
                var goal = new Goal(goalType, name, description, targetPoints);


                //add goal to the service
                GoalService.AddGoal(goal);

            }
        }

    }


    //The function checks to is if there any goals to save
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

    //check to see if goal doesn't already exists in the file
    public static bool goalExistsAlready(string goal)
    {
        var filePath = $"./files/{GoalsFileName}";
        using (StreamReader reader = new StreamReader(filePath))
        {
            var line = reader.ReadLine();
            if (line != null)
            {
                if (line == goal)
                {
                    return true;
                }

            }

        }
        return false;
    }

}