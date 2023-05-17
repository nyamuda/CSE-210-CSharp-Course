public class Activity
{
    private string _name;
    private string _message;
    private int _duration;


    public Activity(string name, string message)
    {
        this._message = message;
        this._name = name;
    }



    public string getName()
    {
        return this._name;
    }
    public string getMessage()
    {
        return this._message;
    }

    public void setMessage(string message)
    {
        this._message = message;
    }
    public int getDuration()
    {
        return this._duration;
    }

    public void setDuration(int duration)
    {
        this._duration = duration;
    }

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

    public void greetingMessage()
    {
        Console.WriteLine($"Welcome to the {this.getName()} Activity.");
        Console.WriteLine();
        Console.WriteLine(this.getMessage());

        Console.WriteLine();

        Console.Write("How long do you want your session to last, in seconds? ");

        int seconds = int.Parse(Console.ReadLine());



        this.setDuration(seconds);
        Console.Clear();
        Console.WriteLine("Get ready...");
        runSpinnerAnimation(3, 6);
    }

    public void sayGoodbye()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Well done");
        runSpinnerAnimation(3, 6);


        Console.WriteLine();
        Console.WriteLine($"You've completed another {this.getDuration()} seconds of the {this.getName()} Activity.");
        runSpinnerAnimation(3, 6);
    }


}