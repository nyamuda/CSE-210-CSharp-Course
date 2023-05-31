using System.Text.Json;
public class UnitConverter : Animation
{
    public Unit SourceUnit { get; set; }
    public Unit TargetUnit { get; set; }

    public double Value { get; set; }

    public string SearchQuery { get; set; }
    public string Result { get; set; }


    public UnitConverter(Unit sourceUnit, Unit targetUnit, double value)
    {
        this.SourceUnit = sourceUnit;
        this.TargetUnit = targetUnit;
        this.Value = value;
    }

    public UnitConverter()
    {

    }


    /*The function sends a string containing what unit needs to be converted and to what unit,
	and then fetches the data of the converted unit.*/

    private async Task<String> FetchResult(string URL)
    {


        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(URL);

            //if the request is a success
            if (response.IsSuccessStatusCode)
            {

                // Read the response content as a stream
                using Stream conversionData = await response.Content.ReadAsStreamAsync();

                // Parse the JSON response
                using JsonDocument jsonDocument = await JsonDocument.ParseAsync(conversionData);


                //Get an array containing the the result
                JsonElement resultArray = jsonDocument.RootElement.GetProperty("queryresult").GetProperty("pods")[1].GetProperty("subpods");


                var resultString = resultArray[0].GetProperty("plaintext").ToString();

                return resultString;


            }

            else
            {

                return "Error: " + response.StatusCode;
            }

        }
    }
    public async Task ConvertUnit()
    {

        // API endpoint for Wolfram Alpha
        var URL = "http://api.wolframalpha.com/v2/query?";
        //API Parameters
        var unitAPIParameters = new APIParameters(this.SearchQuery);

        var URLWithParams = URL + unitAPIParameters.GetParameters();

        string conversionResult = await FetchResult(URLWithParams);

        Result = conversionResult;


    }

    public override void StartAnimation(int seconds)
    {
        Console.WriteLine();

        int totalBarWidth = seconds;

        int progress = 0;

        while (progress <= 100)
        {

            int filledWidth = (int)Math.Round((double)progress / 100 * totalBarWidth);
            int emptyWidth = totalBarWidth - filledWidth;


            string loadingBar = "" + new string('>', filledWidth) + new string(' ', emptyWidth) + " " + progress + "%";


            Console.Write("\r" + loadingBar);


            progress++;


            Thread.Sleep(13);
        }

        Console.WriteLine();

    }

    public override void CoolMessageAnimation(string text, int delay)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(delay);
        }
    }

    public string GetWaitMessage()
    {
        List<string> waitMessages = new List<string>
        {
            "Holding on while the hamsters fetch the data...",
            "Finding the missing pieces of information...",
            "Counting the seconds until the data arrives...",
            "Summoning the data from the digital realm...",
            "Polishing the bits and bytes...",
            "Asking the API nicely to hurry up...",
            "Entertaining you with a joke while waiting...",
            "Convincing the server to share its secrets...",
            "Unraveling the mysteries of the data universe...",
            "Taking a coffee break while the data gets ready..."
        };
        Random random = new Random();
        int randValue = random.Next(0, waitMessages.Count);

        return waitMessages[randValue];
    }

    public string GetDataArrivedMessage()
    {
        List<string> arrivedMessages = new List<string>
        {
            "Data retrieved from the intergalactic API!",
            "Unicorns delivered the data just for you!",
            "Congratulations! You've won the API data jackpot!",
            "API data acquired. Time to do the happy dance!",
            "Hold on to your hat, the data is here!",
            "Data has arrived, grab some popcorn and enjoy!",
            "Your data has been beamed down from the API mothership!",
            "API data successfully captured. Mission accomplished!",
            "The API genie granted your data wish. Ta-da!",
            "Data has landed safely. Prepare for awesomeness!"
        };

        Random random = new Random();
        int randValue = random.Next(0, arrivedMessages.Count);

        return arrivedMessages[randValue];
    }
}