
public class Breathing : Activity
{


    public Breathing(string name, string message) : base(name, message)
    {


    }



    public void startBreathingActivity()
    {
        BreathingService activityService = new BreathingService();


        //start the breathing activity
        activityService.startActivity(base.getDuration());





    }




}