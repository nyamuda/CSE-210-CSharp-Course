public class Activity : Animation
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


    public void greetingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {this.getName()} Activity.");
        Console.WriteLine();
        Console.WriteLine(this.getMessage());

        Console.WriteLine();

        Console.Write("How long do you want your session to last, in seconds? ");

        int seconds = int.Parse(Console.ReadLine());
        this.setDuration(seconds);
        Console.Clear();


        //load the loading animation
        Random random = new Random();
        int randInt = random.Next(3, 7);
        Console.WriteLine("Get ready...");


        loadingBarAnimation(randInt);
    }

    public void sayGoodbye()
    {
        Random random = new Random();
        int randInt = random.Next(3, 7);


        Console.WriteLine();
        beautifulTextAnimation(randInt, "Well done!!");


        Console.WriteLine();
        Console.WriteLine($"You've completed another {this.getDuration()} seconds of the {this.getName()} Activity.");

        loadingBarAnimation(randInt);
    }


}