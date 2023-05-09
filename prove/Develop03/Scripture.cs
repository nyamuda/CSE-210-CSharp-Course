using System;
using System.Text.Json;


public class Scripture
{
    private List<string> _verse = new List<string>();

    private Reference _reference;

    public Scripture(string verse, string reference)
    {
        this._verse.Add(verse);
        this._reference = new Reference(reference);

    }

    public void setVerse(string verse)
    {
        this._verse.Add(verse);
    }


    public List<string> getVerse()
    {
        return this._verse;
    }

    public Reference getReference()
    {
        return this._reference;
    }



    //The function fetches the verse(s) for a given reference from an API 
    public async Task fetchScriptureFromAPI(string scriptureReference)
    {
        try
        {

            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.GetAsync($"https://bible-api.com/{scriptureReference}");

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response);
                    // Read the response content as a stream
                    using Stream verseData = await response.Content.ReadAsStreamAsync();

                    // Parse the JSON response
                    using JsonDocument document = await JsonDocument.ParseAsync(verseData);

                    string reference = document.RootElement.GetProperty("reference").ToString();
                    this._reference.setReference(reference);
                    //one of the properties('verses') contains an array of objects
                    //the objects contains the verse
                    //to get the verses
                    //we loop through that array
                    JsonElement versesArray = document.RootElement.GetProperty("verses");

                    foreach (JsonElement verseElement in versesArray.EnumerateArray())
                    {
                        //the verse we want
                        string beautifulVerse = verseElement.GetProperty("text").ToString();
                        this._verse.Add(beautifulVerse);
                    }
                    Console.WriteLine(reference);


                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }




}