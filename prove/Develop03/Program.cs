using System;

class Program
{
    static async Task Main(string[] args)
    {
        Scripture scripture = new Scripture("hello", "John3:16");
        await scripture.fetchScriptureFromAPI("John3:16");

        // Console.WriteLine(scripture.getVerse());
        // string scripture = "My name is tatenda and I live in Cape Town, South Africa";
        // Service scriptureService = new Service(scripture);

        // string response = promptUser(scripture, scriptureService);


        // while (response != "quit")
        // {

        //     scriptureService.setScripture(scripture);
        //     //create hidden scripture
        //     scripture = scriptureService.hideScriptureWords();
        //     response = promptUser(scripture, scriptureService);





        // }

    }



    static string promptUser(string scripture, Service scriptureService)
    {
        string response = "";
        Console.Clear();
        Console.WriteLine(scripture);


        //if all words are hidden
        if (scriptureService.checkAllWordsHidden())
        {
            Console.WriteLine();
            response = "quit";
        }

        else
        {
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            response = Console.ReadLine();


        }

        return response;

    }



}