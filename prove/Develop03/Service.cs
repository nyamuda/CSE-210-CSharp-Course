//This class contains the business logic for program
public class Service
{
    private string _scripture;


    public Service(string scripture)
    {
        this._scripture = scripture;
    }



    //The method hides random words from the given scripture
    public string hideScriptureWords()
    {
        Random random = new Random();

        //create a list from the scripture string
        string[] scriptureList = this._scripture.Split(" ");
        scriptureList.ToArray();
        //random number
        int randomNumber1 = random.Next(0, scriptureList.Length);
        int randomNumber2 = random.Next(0, scriptureList.Length);



        string scriptureWithHiddenWords = "";


        //replace a random word from the scripture list
        for (int i = 0; i < scriptureList.Length; i++)
        {
            string currentWord = scriptureList[i];
            //generate underscores
            string underscores = this.generateUnderscores(currentWord);


            //we select the word(s) to hide based on the random numbers
            if ((i == randomNumber1 || i == randomNumber2) && currentWord != underscores)
            {

                //add a space before the underscores unless if its the first word
                string underscoreWithSpace = $" {underscores}";

                scriptureWithHiddenWords += (i == 0) ? underscores : underscoreWithSpace;
            }
            else
            {
                //add a space on each word unless if its the first word
                string wordWithSpace = $" {currentWord}";

                scriptureWithHiddenWords += (i == 0) ? currentWord : wordWithSpace;
            }

        }

        return scriptureWithHiddenWords;



    }

    //The method generates a string of underscores depending on the number of characters in the given word
    //Example: if a word has 3 characters => 3 underscores will be generated
    private string generateUnderscores(string word)
    {
        string underscores = "";
        for (int i = 0; i < word.Length; i++)
        {
            underscores += "_";
        }

        return underscores;
    }


    public void setScripture(string scripture)
    {
        this._scripture = scripture;
    }


    //The function checks to see if all words in the scripture are hidden
    public bool checkAllWordsHidden()
    {
        string[] scriptureList = this._scripture.Split(" ");
        bool allHidden = false;

        //loop through the list to see if every word is underscored
        for (int i = 0; i < scriptureList.Length; i++)
        {
            string currentWord = scriptureList[i];
            //generate underscores for the current word
            string underscores = generateUnderscores(currentWord);


            //if we encounter a word that is not hidden
            //then all words in the scripture are not hidden
            //we stop the loop
            if (scriptureList[i] != underscores)
            {
                allHidden = false;

                break;
            }
            else
            {
                allHidden = true;
            }
        }

        return allHidden;
    }

}