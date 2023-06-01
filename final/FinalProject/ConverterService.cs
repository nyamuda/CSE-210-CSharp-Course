//This class contains the business logic for the unit converter program.
public static class ConverterService
{



    //Convert a value fpr a given unit
    public static async Task ConvertValue()
    {
        Console.Clear();
        Console.WriteLine("Convert any unit you want into another unit.");
        Console.WriteLine("You can use words or symbols to write your units.");
        Console.WriteLine("Examples: 20 km to meters, 15 oz to lb, 10 feet to yd, etc.");
        Console.WriteLine();

        Console.Write("What would you like to convert?: ");
        string option = Console.ReadLine();

        UnitConverter unitConverter = new UnitConverter();

        string queryString = $"Convert {option}";

        //ask the user for confirmation
        Console.Write($"{queryString}? (yes/no) ");
        char confirmationValue = Console.ReadLine().ToLower()[0];



        while (confirmationValue != 'y' && confirmationValue != 'n')
        {
            Console.WriteLine("Invalid option selected. Please enter 'yes' or 'no' to confirm.");
            Console.WriteLine();
            Console.Write($"{queryString}? (yes/no): ");
            confirmationValue = Console.ReadLine().ToLower()[0];

        }

        //if the confirmation is yes
        //convert the value
        if (confirmationValue == 'y')
        {

            unitConverter.SearchQuery = queryString.ToLower();

            //Display random wait message
            Console.WriteLine();
            string waitMessage = unitConverter.GetWaitMessage();
            unitConverter.CoolMessageAnimation(waitMessage, 50);





            await unitConverter.ConvertUnit();
            //Display loading bar
            unitConverter.StartAnimation(20);

            Console.WriteLine();
            //Display data has arrived random message
            string arrivedMessage = unitConverter.GetDataArrivedMessage();
            unitConverter.CoolMessageAnimation(arrivedMessage, 40);
            Console.WriteLine();
            string result = $"Result: {unitConverter.Result}";
            unitConverter.CoolMessageAnimation(result, 50);
            Console.WriteLine();

        }







    }




}