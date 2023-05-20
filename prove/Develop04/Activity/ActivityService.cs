//This class contains the business logic for the activities


public interface IActivityService
{

    //start the activity
    public void startActivity(int duration);

    //run the count down timer
    public void countDownTimer(int randomSeconds, string sentence);


    //the function splits an integer(the argument) into random numbers
    // and ensures that the sum of those random numbers is equal to the argument
    public List<int> generateRandomNumbers(int target);


}