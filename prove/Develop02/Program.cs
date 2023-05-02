using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program");

        //Prompts
        string[] prompts = new string[]
        {
"Who was the most interesting person I interacted with today?",
"What was the best part of my day?",
"How did I see the hand of the Lord in my life today?",
"What was the strongest emotion I felt today?",
"If I had one thing I could do over today, what would it be?",
"If you could have any job in the world, what would it be and why?",
"Who is someone in your life that you are grateful for, and why are they important to you?"
        };

        //Create a Journal
        Journal myJournal = new Journal();

        //The Options
        string[] options = new string[] { "Write", "Display", "Load", "Save", "Quit" };
        int option = 0;

        //Prompt the user
        promptUser();


        void takeAction()
        {
            //"Write"to the journal
            if (option == 1)
            {
                Random random = new Random();
                string randomQuestion = prompts[random.Next(0, prompts.Length)];

                //ask the user the question
                //get user input
                Console.Write($"{randomQuestion} ");
                string response = Console.ReadLine();
                DateTime currentDate = DateTime.Now;


                //create a new entry
                Entry newEntry = new Entry(randomQuestion, response, currentDate.ToString("yyyy-MM-dd"));

                //save entry to the journal
                myJournal.setEntry(newEntry);

                promptUser();
                takeAction();

            }

            //You want to see your entries
            if (option == 2)
            {
                myJournal.DisplayEntries();
                promptUser();
                takeAction();
            }

            //load file
            if (option == 3)
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                File existingFile = new File(fileName: fileName);

                //load the information in the file to the Journal
                myJournal = existingFile.loadFile();

                promptUser();
                takeAction();
            }

            //save to file
            if (option == 4)
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                File newFile = new File(fileName: fileName);

                //save Journal contents to file
                newFile.saveFile(myJournal);

                promptUser();
                takeAction();
            }



        }
        void promptUser()
        {
            //Print available options
            Console.WriteLine("Please select one of the following choices: ");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            //get user input
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());

            takeAction();


        }



    }
}