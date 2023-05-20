
public class Reflection : Activity
{


    public Reflection(string name, string message) : base(name, message)
    {


    }



    public void startReflectionActivity()
    {
        ReflectionService activityService = new ReflectionService();


        //start the Reflection activity
        activityService.startActivity(base.getDuration());





    }




}