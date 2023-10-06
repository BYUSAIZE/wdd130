using System.IO;

public class Journal
{
    //use the DateTime module to later save the current date into an entry
    DateTime currentTime = DateTime.Now;

    //create a PromptRandomizer instance to later get a random prompt for an entry
    PromptRandomizer promptRandomizer = new PromptRandomizer();

    //create the list to store all entries
    public List<Entry> _entries = new List<Entry>();

    //adding a new entry to the _entries list
    public void NewEntry()
    {
        Entry entry = new Entry();

        entry._date = currentTime.ToShortDateString();
        entry._prompt = promptRandomizer.ChoosePrompt();

        Console.WriteLine(entry._prompt);
        Console.Write($"> ");
        entry._entryText = Console.ReadLine();

        Console.WriteLine("How are you currently feeling? (happy, sad, angry, peaceful)");
        Console.Write($"> ");
        entry._emotion = Console.ReadLine();

        _entries.Add(entry);
    }
    
    //display the entire journal 
    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    //get the name of the file for either loading a journal or saving the journal
    public string GetFilename()
    {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        return filename;
    }

    //count how many times the user felt a certain way and display it
    public void EmotionCounter()
    {
        int happy = 0;
        int sad = 0;
        int angry = 0;
        int peaceful = 0;
        int undefined = 0;

        foreach (Entry entry in _entries)
        {
            if (entry._emotion.ToLower() == "happy")
            {
                happy += 1;
            }

            else if (entry._emotion.ToLower() == "sad")
            {
                sad += 1;
            }

            else if (entry._emotion.ToLower() == "angry")
            {
                angry += 1;
            }

            else if (entry._emotion.ToLower() == "peaceful")
            {
                peaceful += 1;
            }

            else
            {
                undefined += 1;
            }
        }

        Console.WriteLine($"For all entries in the journal, you have felt happy {happy} time(s), sad {sad} time(s), angry {angry} time(s), peaceful {peaceful} time(s) and with an undefined emotion {undefined} time(s).");
    }

    // load from a file
    public void Load(string filename)
    {
        _entries.Clear(); 
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] piece = line.Split("~");

            Entry entry = new Entry();

            entry._date = piece[0];
            entry._prompt = piece[1];
            entry._entryText = piece[2];
            entry._emotion = piece[3];

            _entries.Add(entry);
        }
    }

    // save to a file
    public void Save(string filename)
    {
        using (StreamWriter journalFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                journalFile.WriteLine($"{entry._date}~{entry._prompt}~{entry._entryText}~{entry._emotion}");
            }
        }
    }
}