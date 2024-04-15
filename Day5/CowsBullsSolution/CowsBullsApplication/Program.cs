namespace CowsBullsApplication
{
    internal class Program
    {
        string CorrectWord = "golf";
        int Attempts = 0;

        string GetWordFromUser ()
        {
            string word = "";
            Console.WriteLine("");
            Console.Write("Enter the word: ");

            while (word == string.Empty || word.Length != 4)
            {
                word = Console.ReadLine() ?? "";

                if (word == string.Empty) Console.Write("Word should be of length 4. Please enter again: ");
            }

            Attempts++;
            return word;
        }

        void CalculateCowsAndBulls (string wordFromUser)
        {
            int cows = 0;
            int bulls = 0;

            while (true)
            {
                for (int i = 0; i < CorrectWord.Length; i++)
                {   
                    char letterToBeCheckedWith = CorrectWord[i];
                    for (int j = 0; j < wordFromUser.Length; j++)
                    {
                        char letterBeingChecked = wordFromUser[j];

                        if ((letterToBeCheckedWith == letterBeingChecked) && i == j) cows++;
                        else if (letterToBeCheckedWith == letterBeingChecked) bulls++;
                    }
                }

                if (cows == CorrectWord.Length)
                {
                    Console.WriteLine("=============================================================");
                    Console.WriteLine($"Congrats!! You've guessed right with {Attempts} attempts! \"{wordFromUser}\" is the word.");
                    break;
                }

                Console.WriteLine("====================================");
                Console.WriteLine("Ohoo! You've missed it. Try again :)");
                Console.WriteLine($"Cows: {cows} Bulls: {bulls}");

                cows = 0;
                bulls = 0;
                wordFromUser = GetWordFromUser();
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            string wordFromUser = program.GetWordFromUser();
            program.CalculateCowsAndBulls(wordFromUser);
        }
    }
}
