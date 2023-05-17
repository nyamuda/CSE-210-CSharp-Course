
public class Listing : Activity
{


    public Listing(string name, string message) : base(name, message)
    {


    }



    public void startListingActivity()
    {
        ListingService activityService = new ListingService();


        //start the Listing activity
        activityService.startActivity(base.getDuration());





    }




}