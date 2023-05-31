public static class ConverterService
{
    private static List<UnitCategory> _categories = new List<UnitCategory>();





    public static List<UnitCategory> GetAllCategories()
    {
        return _categories;
    }


    //Convert a value
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

    //The functions build each category of units
    public static void BuildCategories()
    {
        //First, add the length category
        CreateUnitsForCategory("Length", lengthUnits);
        //Second, add the weight category
        CreateUnitsForCategory("Weight", weightUnits);

        //Third, add the temperature category
        CreateUnitsForCategory("Temperature", temperatureUnits);

        //Fourth, add the time category
        CreateUnitsForCategory("Time", timeUnits);

        //Fifth, add the area category
        CreateUnitsForCategory("Area", areaUnits);

        //Sixth, add the volume category
        CreateUnitsForCategory("Volume", volumeUnits);
        //7th, add the speed category
        CreateUnitsForCategory("Speed", speedUnits);

        //8th, add the pressure category
        CreateUnitsForCategory("Pressure", pressureUnits);




    }



    //The function create a new category and its units
    private static void CreateUnitsForCategory(string category, List<string> units)
    {
        //First, add the length categories
        var newCategory = new UnitCategory(category);
        foreach (var item in units)
        {
            //create unit
            var unit = new Unit(item);
            //add unit to category
            newCategory.Units.Add(unit);

        }

        //add the new category to the store --- _categories
        _categories.Add(newCategory);

    }




    //THE FOLLOWING ARE THE COMMON UNIT CATEGORIES AND THEIR UNITS
    //THESE ARE THE UNITS THE QUIZ WILL BE USING

    // Length units
    static List<string> lengthUnits = new List<string>
        {
            "Meter (m)",
            "Centimeter (cm)",
            "Kilometer (km)",
            "Inch (in)",
            "Foot (ft)",
            "Yard (yd)",
            "Mile (mi)"
        };

    // Weight/Mass units
    static List<string> weightUnits = new List<string>
        {
            "Kilogram (kg)",
            "Gram (g)",
            "Milligram (mg)",
            "Pound (lb)",
            "Ounce (oz)",
            "Ton (t)"
        };

    // Temperature units
    static List<string> temperatureUnits = new List<string>
        {
            "Celsius (°C)",
            "Fahrenheit (°F)",
            "Kelvin (K)"
        };

    // Time units
    static List<string> timeUnits = new List<string>
        {
            "Second (s)",
            "Minute (min)",
            "Hour (hr)",
            "Day (day)",
            "Week (wk)",
            "Month (mo)",
            "Year (yr)"
        };

    // Area units
    static List<string> areaUnits = new List<string>
        {
            "Square Meter (m²)",
            "Square Kilometer (km²)",
            "Square Mile (mi²)",
            "Square Foot (ft²)",
            "Square Inch (in²)",
            "Hectare (ha)",
            "Acre (ac)"
        };

    // Volume units
    static List<string> volumeUnits = new List<string>
        {
            "Cubic Meter (m³)",
            "Cubic Foot (ft³)",
            "Liter (L)",
            "Milliliter (mL)",
            "Gallon (gal)",
            "Pint (pt)"
        };

    // Speed units
    static List<string> speedUnits = new List<string>
        {
            "Meter per Second (m/s)",
            "Kilometer per Hour (km/h)",
            "Mile per Hour (mph)",
            "Knot (kn)",
            "Foot per Second (ft/s)"
        };

    // Pressure units
    static List<string> pressureUnits = new List<string>
        {
            "Pascal (Pa)",
            "Atmosphere (atm)",
            "Bar (bar)",
            "Pound per Square Inch (psi)",
            "Torr (Torr)"
        };


}