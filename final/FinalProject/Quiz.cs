public class Quiz : UnitConverter
{


    public Quiz(Unit sourceUnit, Unit targetUnit, double value) : base(sourceUnit, targetUnit, value)
    {
        this.SourceUnit = sourceUnit;
        this.TargetUnit = targetUnit;
        this.Value = value;
    }

    public Quiz() { }

    public override void StartAnimation(int seconds)
    {
        Console.WriteLine();

        int totalBarWidth = seconds;

        int progress = 0;

        while (progress <= 100)
        {

            int filledWidth = (int)Math.Round((double)progress / 100 * totalBarWidth);
            int emptyWidth = totalBarWidth - filledWidth;


            string loadingBar = "" + new string('.', filledWidth) + new string(' ', emptyWidth);


            Console.Write("\r" + loadingBar);


            progress++;


            Thread.Sleep(5);
        }

        Console.WriteLine();

    }

    public override void CoolMessageAnimation(string text, int delay)
    {
        var color = GenerateColor();
        Random random = new Random();
        for (int i = 0; i < text.Length; i++)
        {
            Console.ForegroundColor = color;
            Console.Write(text[i]);
            Console.ResetColor();
            Thread.Sleep(delay);
        }
    }

    public ConsoleColor GenerateColor()
    {
        List<ConsoleColor> consoleColors = new List<ConsoleColor>
        {
            ConsoleColor.Black,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkYellow,
            ConsoleColor.Gray,
            ConsoleColor.DarkGray,
            ConsoleColor.Blue
        };

        Random random = new Random();
        int randValue = random.Next(0, consoleColors.Count);

        return consoleColors[randValue];
    }




    public override string GetWaitMessage()
    {
        List<string> waitMessages = new List<string>
        {
            "Calculating...",
            "Hold on, let me double-check that for you...",
            "Working out the answer in the unit conversion lab...",
            "Taking a moment to verify your response...",
            "Doing some magical number crunching...",
            "Applying the unit conversion formula...",
            "Engaging the conversion supercomputer...",
            "Just a few seconds, please...",
            "Time for the quiz brain to do its thing...",
            "Processing your answer..."
        };
        Random random = new Random();
        int randValue = random.Next(0, waitMessages.Count);

        return waitMessages[randValue];
    }

    public string GetCorrectMessage()
    {
        List<string> correctMessages = new List<string>
        {
            "You nailed it! Great job!",
            "Congratulations! You got it right!",
            "Correct! You're on a roll!",
            "Well done! Your answer is spot on!",
            "Bravo! You're a unit conversion expert!",
            "Excellent work! That's the right answer!",
            "You're crushing it! Correct once again!",
            "Hooray! Your answer is absolutely correct!",
            "You've got it! Keep up the good work!",
            "Right on target! You're doing fantastic!"
        };
        Random random = new Random();
        int randValue = random.Next(0, correctMessages.Count);

        return correctMessages[randValue];
    }

    public string GetFailureMessage()
    {
        List<string> wrongMessages = new List<string>
        {
            "Oops! That's not the correct answer.",
            "Don't worry, try again for the correct answer!",
            "Almost there, but not quite right.",
            "Not quite what we were looking for.",
            "Keep trying! You'll get it next time.",
            "Oopsie! That's not the right answer.",
            "Not quite on target. Give it another shot!",
            "Incorrect. Let's try another attempt.",
            "Don't give up! You'll crack it eventually."
        };
        Random random = new Random();
        int randValue = random.Next(0, wrongMessages.Count);

        return wrongMessages[randValue];
    }

    public string GetCongratulatoryMessage()

    {
        List<string> congratulatoryMessages = new List<string>
        {
            "Congratulations on a job well done!",
            "Brilliant performance! Keep up the great work!",
            "Well done! Your expertise in unit conversion is impressive!",
            "Fantastic job! Your knowledge shines through!",
            "Congratulations on acing the unit converter quiz!",
            "Outstanding work! Your accuracy is commendable.",
            "Great job! Your proficiency in unit conversion is remarkable.",
            "Impressive performance! You've mastered unit conversion.",
            "Congratulations! Your results reflect your dedication and skill.",
            "Superb work! Your understanding of unit conversion is outstanding."
        };
        Random random = new Random();
        int randValue = random.Next(0, congratulatoryMessages.Count);

        return congratulatoryMessages[randValue];
    }
    public void BuildQuery()
    {
        base.BuildSearchQuery();
    }

}