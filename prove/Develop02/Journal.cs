using System;



public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<String> _textEntries = new List<string>();

    private string _savedFileName = ".csv";


    public void setEntry(Entry entry)
    {
        this._entries.Add(entry);
    }


    public void setTextEntry(string entry)
    {
        this._textEntries.Add(entry);
    }


    public void setSavedFileName(string fileName)
    {
        this._savedFileName = fileName;
    }

    public void DisplayEntries()
    {
        //Check to see if the file is a .txt or .csv
        string fileName = this._savedFileName;
        string fileExtension = fileName.Substring(fileName.Length - 4);

        if (fileExtension == ".txt")
        {
            foreach (string entry in _textEntries)
            {

                Console.WriteLine(entry);
            }
        }
        else
        {
            foreach (Entry entry in _entries)
            {

                entry.DisplayEntry();
                Console.WriteLine("");
            }
        }

    }

    public List<Entry> getEntries()
    {
        return this._entries;

    }

    public List<string> getTextEntries()
    {
        return this._textEntries;

    }

    public string getSavedFileName()
    {
        return this._savedFileName;
    }


}