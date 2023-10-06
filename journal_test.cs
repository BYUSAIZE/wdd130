using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
}

class Program
{
    static List<JournalEntry> journalEntries = new List<JournalEntry>();
    static string journalFilePath = "journal.txt";

    static void Main()
    {
        LoadJournal(); // Load journal entries from file at the start

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        WriteNewEntry();
                        break;
                    case 2:
                        DisplayJournal();
                        break;
                    case 3:
                        SaveJournal();
                        break;
                    case 4:
                        LoadJournal();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void WriteNewEntry()
    {
        Console.WriteLine("Writing a new entry...");

        // Generate a random prompt
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random random = new Random();
        string randomPrompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        // Create a new journal entry
        JournalEntry entry = new JournalEntry
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            Prompt = randomPrompt,
            Response = response
        };

        journalEntries.Add(entry);
        Console.WriteLine("Entry added to the journal.");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in journalEntries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine("---------------------------------------------------");
        }
    }

    static void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in journalEntries)
                {
                    writer.WriteLine($"Date: {entry.Date}");
                    writer.WriteLine($"Prompt: {entry.Prompt}");
                    writer.WriteLine($"Response: {entry.Response}");
                    writer.WriteLine("---------------------------------------------------");
                }
            }
            Console.WriteLine("Journal saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    static void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        try
        {
            if (File.Exists(filename))
            {
                journalEntries.Clear();
                using (StreamReader reader = new StreamReader(filename))
                {
                    JournalEntry entry = null;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("Date: "))
                        {
                            entry = new JournalEntry();
                            entry.Date = line.Substring("Date: ".Length);
                        }
                        else if (line.StartsWith("Prompt: ") && entry != null)
                        {
                            entry.Prompt = line.Substring("Prompt: ".Length);
                        }
                        else if (line.StartsWith("Response: ") && entry != null)
                        {
                            entry.Response = line.Substring("Response: ".Length);
                            journalEntries.Add(entry);
                        }
                    }
                }
                Console.WriteLine("Journal loaded from file successfully.");
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}