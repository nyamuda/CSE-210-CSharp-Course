using Microsoft.VisualBasic.FileIO;

public class File
{
    private string _fileName;


    public File(string fileName)
    {
        this._fileName = fileName;
    }


    //Save the file as CSV or TXT
    public void saveFile(Journal journal)
    {
        {


            string fileName = this._fileName;

            //Check to see if the file is a .txt or .csv
            string fileExtension = fileName.Substring(fileName.Length - 4);

            //if the file is a TXT file
            if (fileExtension == ".txt")
            {
                using (FileStream fs = new FileStream($"./files/{fileName}", FileMode.Create))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    //loop all the entries in the Journal and save each one to the file
                    foreach (Entry entry in journal.getEntries())
                    {
                        writer.WriteLine(entry.getEntry());
                        writer.WriteLine();
                    }
                }

            }

            //if the file is a CSV file
            if (fileExtension == ".csv")
            {
                using (FileStream fs = new FileStream($"./files/{fileName}", FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Prompt|Response|Date");
                    //loop all the entries in the Journal and save each one to the file
                    foreach (Entry entry in journal.getEntries())
                    {

                        writer.WriteLine($"{entry.getPrompt()}|{entry.getResponse()}|{entry.getDate()}");
                    }
                }

            }


        }
    }

    //Load the file and save the contents to the Journal
    //And then return the journal
    public Journal loadFile()
    {
        Journal journal = new Journal();

        string fileName = this._fileName;


        //the file name the journal was in
        journal.setSavedFileName(fileName);

        //Check to see if the file is a .txt or .csv
        string fileExtension = fileName.Substring(fileName.Length - 4);

        if (fileExtension == ".txt")
        {
            // Open the file and read its contents
            using (FileStream fs = new FileStream($"./files/{fileName}", FileMode.Open))
            using (StreamReader reader = new StreamReader(fs))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    journal.setTextEntry(line);
                }
            }
        }


        if (fileExtension == ".csv")
        {
            // Open the file and read its contents
            using (TextFieldParser parser = new TextFieldParser($"./files/{fileName}"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("|");

                //skip the first line
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    string prompt = fields[0];
                    string response = fields[1];
                    string date = fields[2];

                    //Create a new entry
                    Entry entry = new Entry(prompt: prompt, response: response, date: date);

                    //save it to the journal
                    journal.setEntry(entry);


                }
            }
        }


        return journal;
    }
}