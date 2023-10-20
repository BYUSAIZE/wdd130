class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Please enter a scripture reference (e.g., '1 Nephi 3:7' or 'Proverbs 3:5-6').");
        Console.WriteLine();

        string reference = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Please enter a difficulty level:");
        Console.WriteLine();
        Console.WriteLine("'1' for Easy");
        Console.WriteLine("'2' for Moderate");
        Console.WriteLine("'3' for Hard");
        Console.WriteLine("'4' for Show-off");
        Console.WriteLine();

        string difficultyChoice = Console.ReadLine();

        int difficulty = Int16.Parse(difficultyChoice);

        Scripture scripture = new Scripture(reference, difficulty);

        Console.Clear();

        Console.WriteLine($"{scripture.GetReference()} - {scripture.GetText()}");

        Console.WriteLine();

        Console.WriteLine("Press enter to continue or type 'quit' to finish:");

        Console.WriteLine();

        string proceedOrQuit = Console.ReadLine();

        while (proceedOrQuit != "quit" && scripture.AreAllWordsModified() == 0)
        {
            if (scripture.AreAllWordsModified() == 0)
            {
                scripture.DisplayScriptures();

                Console.WriteLine();

                Console.WriteLine("Press enter to continue or type 'quit' to finish:");

                Console.WriteLine();

                proceedOrQuit = Console.ReadLine();
            }

            else
            {
                return;
            }
        }

        return;
    }
}