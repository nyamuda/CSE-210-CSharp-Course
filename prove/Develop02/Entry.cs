using System;




public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;



    public Entry(string prompt, string response, string date)
    {
        this._prompt = prompt;
        this._response = response;
        this._date = date;
    }


    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {this._date} - Prompt: {this._prompt}");
        Console.WriteLine($"{this._response}");
    }

    public string getEntry()
    {
        string entry = $"Date: {this._date} - Prompt: {this._prompt}\n" + $"{this._response}";

        return entry;
    }

    public string getPrompt()
    {
        return this._prompt;
    }
    public string getResponse()
    {
        return this._response;
    }

    public string getDate()
    {
        return this._date;
    }

}