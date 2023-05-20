public class Animation
{

    //Animation displays a spinner
    public static void runSpinnerAnimation(int min, int max)
    {
        Random random = new Random();
        int randomSeconds = random.Next(min, max);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(randomSeconds);


        while (DateTime.Now < endTime)
        {
            Console.Write("/");
            Thread.Sleep(100);

            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("-");
            Thread.Sleep(100);

            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("\\");
            Thread.Sleep(100);

            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write("|");
            Thread.Sleep(100);

            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.Write("\b \b");
    }


    //Animation changes the color of the text
    public static void beautifulTextAnimation(int seconds, string text)
    {
        // Duration of the fade in milliseconds
        int fadeDuration = seconds * 1000;
        // Number of fade steps
        int steps = 10;

        // Calculate the delay between each fade step
        int fadeDelay = fadeDuration / steps;

        //make the color black
        Console.ForegroundColor = ConsoleColor.Black;

        // Loop through each fade step
        for (int step = 1; step <= steps; step++)
        {
            // Clear the console to remove the previous text
            Console.Clear();
            // Calculate the new intensity value for the text color
            int intensity = (int)((double)step / steps * 15);

            // Set the text color with the new intensity
            Console.ForegroundColor = (ConsoleColor)intensity;

            // Display the text
            Console.WriteLine(text);

            // Delay before the next fade step
            Thread.Sleep(fadeDelay);


        }

        // Restore the default text color
        Console.ResetColor();

    }

    //Animation displays a loading bar
    public static void loadingBarAnimation(int seconds)
    {
        // Total width of the loading bar
        int totalWidth = seconds;
        // Current progress
        int progress = 0;
        // Loop until the the time is up
        while (progress <= 100)
        {
            // Calculate the number of filled and empty slots in the loading bar
            int filledWidth = (int)Math.Round((double)progress / 100 * totalWidth);
            int emptyWidth = totalWidth - filledWidth;

            // Build the loading bar string
            string loadingBar = "[" + new string('=', filledWidth) + new string(' ', emptyWidth) + "] " + progress + "%";

            // Display the loading bar
            Console.Write("\r" + loadingBar);

            // Increment the progress
            progress++;

            // Delay before the next update
            Thread.Sleep(50); // Adjust the delay as desired
        }

    }



}