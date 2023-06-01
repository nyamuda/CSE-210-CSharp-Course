
//This class contains the business logic for the quiz. 

public static class QuizService
{
    private static int _correctAnswersGot = 0;
    private static int _totalQuestions = 0;

    private static UnitCategory _categoryForQuiz;

    private static double _currentCorrectAnswer;

    private static List<UnitCategory> _categories = new List<UnitCategory>();





    //the category of units for the quiz
    public static void SetCategoryForQuiz(UnitCategory category)
    {
        _categoryForQuiz = category;
    }

    public static void ClearCategories()
    {
        _categories.Clear();
    }



    public static List<UnitCategory> GetAllCategories()
    {
        return _categories;
    }


    //Start the quiz for a specific category
    public static async Task StartQuizForCategory()
    {
        Console.Clear();
        _totalQuestions = 0;
        _correctAnswersGot = 0;
        _currentCorrectAnswer = 0;
        var quiz = new Quiz();

        Console.WriteLine($"Welcome to the quiz. Practice converting units for {_categoryForQuiz.Name.ToLower()}.");
        Console.WriteLine("Try to give your decimal answers to at least two decimal places for better accuracy.");

        Console.WriteLine();
        //The number of questions of the quiz
        Console.Write("How many questions would you like to do? ");

        int numberOfQuestions = 0;
        try
        {
            numberOfQuestions = int.Parse(Console.ReadLine());

        }
        catch (System.FormatException)
        {

            Console.WriteLine();
            Console.WriteLine("Invalid option selected. Please try again.");


            await StartQuizForCategory();
        }

        while (_totalQuestions < numberOfQuestions && numberOfQuestions != 0)
        {

            //First, generate a random value to convert
            var random = new Random();
            double valueToConvert = Math.Round(random.NextDouble() * random.Next(1, 1000), 2);

            //Second, generate a random unit to convert
            int sourceUnitPosition = random.Next(0, _categoryForQuiz.Units.Count);
            Unit sourceUnit = _categoryForQuiz.Units[sourceUnitPosition]; //the source unit;

            //And third, generate a random unit to convert to
            int targetUnitPosition = random.Next(0, _categoryForQuiz.Units.Count);
            //Making sure the source unit and the target unit are different --> not at the same position
            while (sourceUnitPosition == targetUnitPosition)
            {
                targetUnitPosition = random.Next(0, _categoryForQuiz.Units.Count);
            }
            //once the positions of source and target units are different
            //then we can create the target unit
            Unit targetUnit = _categoryForQuiz.Units[targetUnitPosition];


            //Ask the user a question and check their answer
            bool isUserCorrect = await IsUserAnswerCorrect(valueToConvert, sourceUnit, targetUnit);



            //if answer is correct
            if (isUserCorrect)
            {
                Console.WriteLine();
                //get success message
                var successMessage = quiz.GetCorrectMessage();
                quiz.CoolMessageAnimation(successMessage, 20);
                Console.WriteLine();
                _correctAnswersGot += 1;


            }
            else
            {
                Console.WriteLine();
                //get failure message
                var failureMessage = quiz.GetFailureMessage();
                quiz.CoolMessageAnimation(failureMessage, 40);
                Console.WriteLine();
                quiz.CoolMessageAnimation($"The correct answer is: {_currentCorrectAnswer}", 20);

                Console.WriteLine();
            }

            _totalQuestions += 1;

            quiz.StartAnimation(100);
        }



        var marksMessage = $"You got {_correctAnswersGot} out of {_totalQuestions} questions correct.";
        Console.WriteLine();
        if (((double)_correctAnswersGot / (double)_totalQuestions) >= 0.5)
        {
            //get congratulatory messages
            var congratulatoryMessages = quiz.GetCongratulatoryMessage();
            quiz.CoolMessageAnimation(marksMessage, 30);
            Console.WriteLine();
            quiz.CoolMessageAnimation(congratulatoryMessages, 50);
            Console.WriteLine();



        }
        else
        {

            Console.WriteLine(marksMessage);
            Console.WriteLine();
        }


    }



    private static async Task<Boolean> IsUserAnswerCorrect(double valueToConvert, Unit sourceUnit, Unit targetUnit)
    {
        //Build the a statement to show the user

        Console.WriteLine();

        Console.Write($"Question {_totalQuestions + 1}) Convert {valueToConvert} {sourceUnit.Name} to {targetUnit.Name}: ");
        double userAnswer = 0;

        try
        {
            userAnswer = double.Parse(Console.ReadLine());
        }
        catch (System.FormatException)
        {
            Console.WriteLine();
            Console.WriteLine("Invalid value entered. Please try again.");
            Console.WriteLine();

            return await IsUserAnswerCorrect(valueToConvert, sourceUnit, targetUnit);



        }

        //fetch the equivalent of 1 source unit to the target unit
        //we get the multiplier
        //correct answer = multiplier * valueToConvert
        Quiz quiz = new Quiz(sourceUnit, targetUnit, valueToConvert);
        quiz.BuildQuery();
        //show some animation
        var waitMessage = quiz.GetWaitMessage();
        quiz.CoolMessageAnimation(waitMessage, 40);
        Console.WriteLine();
        await quiz.ConvertUnit();

        //get the correct answer
        _currentCorrectAnswer = quiz.ExtractNumberFromResult(quiz.Result);
        //round the value
        _currentCorrectAnswer = Math.Round(_currentCorrectAnswer, 4);



        //evaluate the answer to see if its true
        return CheckAnswer(_currentCorrectAnswer, userAnswer);

    }


    //Check if the answer is correct
    private static bool CheckAnswer(double correctAnswer, double userAnswer)
    {
        if (Math.Abs(correctAnswer - userAnswer) <= 0.9 || Math.Abs(userAnswer - correctAnswer) <= 0.9)
        {
            return true;
        }

        else
        {
            return false;
        }

    }






    //The function builds each category and its units
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
            "m",
            "cm",
            "km",
            "in",
            "ft",
            "yd",
            "mi"
        };

    // Weight/Mass units
    static List<string> weightUnits = new List<string>
        {
            "kg",
            "g",
            "mg",
            "lb",
            "oz",
            "t"
        };

    // Temperature units
    static List<string> temperatureUnits = new List<string>
        {
            "°C",
            "°F",
            "K"
        };

    // Time units
    static List<string> timeUnits = new List<string>
        {
            "s",
            "min",
            "hr",
            "day",
            "wk",
            "mo",
            "yr"
        };

    // Area units
    static List<string> areaUnits = new List<string>
        {
            "m²",
            "km²",
            "mi²",
            "ft²",
            "in²",
            "ha",
            "ac"
        };

    // Volume units
    static List<string> volumeUnits = new List<string>
        {
            "m³",
            "ft³",
            "L",
            "mL",
            "gal",
            "pt"
        };

    // Speed units
    static List<string> speedUnits = new List<string>
        {
            "m/s",
            "km/h",
            "mph",
            "kn",
            "ft/s"
        };

    // Pressure units
    static List<string> pressureUnits = new List<string>
        {
            "Pa",
            "atm",
            "bar",
            "psi",
            "Torr"
        };



}