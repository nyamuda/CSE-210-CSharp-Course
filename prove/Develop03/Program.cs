using System;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Program!");
        Console.WriteLine("Let's dive in and start memorizing together!");

        Console.WriteLine();
        Console.Write("Enter the scripture reference (e.g., John 3:16, Genesis 1:1-3, Daniel 1:8-9): ");
        string scriptureReference = Console.ReadLine();

        Scripture scripture = new Scripture();

        //fetch the verse(s) from an API
        await scripture.fetchScriptureFromAPI(scriptureReference);



        Service scriptureService = new Service(scripture.getVerses());

        //where we put the scripture with hidden words
        string hiddenScripture = scripture.getVerses();


        string response = promptUser(hiddenScripture, scriptureService);


        while (response != "quit")
        {

            scriptureService.setScripture(hiddenScripture);

            //create hidden scripture
            hiddenScripture = scriptureService.hideScriptureWords();
            response = promptUser(hiddenScripture, scriptureService);

        }


        Console.WriteLine();
        Console.WriteLine("Goodbye, and may your spiritual journey be filled with blessings!");

    }



    static string promptUser(string scripture, Service scriptureService)
    {
        string response = "";
        Console.Clear();
        Console.WriteLine(scripture);


        //if all words are hidden
        if (scriptureService.checkAllWordsHidden())
        {

            response = "quit";
        }

        else
        {

            Console.Write("Press enter to continue or type 'quit' to finish: ");
            response = Console.ReadLine();


        }

        return response;

    }



}