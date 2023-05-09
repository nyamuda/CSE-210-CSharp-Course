using System;
using System.Text.Json;


public class Scripture
{
    private List<string> _verses = new List<string>();

    private Reference _reference = new Reference();


    public void setVerses(string verse)
    {
        this._verses.Add(verse);
    }


    public string getVerses()
    {
        string fullVerse = "";
        for (int i = 0; i < this._verses.Count; i++)
        {

            fullVerse += this._verses[i];
        }

        return fullVerse;
    }

    public string getReference()
    {
        return this._reference.getReference();
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
                        this._verses.Add(beautifulVerse);
                    }


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