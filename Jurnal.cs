using System.Runtime.CompilerServices;
using System.Transactions;

/// <summary>
/// This class is responsoble for creating a Jurnal:
/// add new Entries to the Jurnal,
/// save Jurnal to the file,
/// load data from the file and Displays the Jurnal
/// </summary>

class Journal
{
    public string _fileName;
    public Entry _entryJournal;
    public List<Entry> _entriesJournal = new List<Entry>();
    
    public void AddEntry()
    // Adds the curent enrty to the list of Juornal entries
    {
        _entriesJournal.Add(_entryJournal);
    }

    public void SaveToFile()
    // Saves the list of entries to a file. Name of the file must be input by the user
    // In addition the line with the status of the download was added
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (Entry element in _entriesJournal)
            {
               outputFile.WriteLine($"{element._prompt} | {element._date} | {element._answer} | {element._mood}");
            }
        }
        Console.WriteLine("The file has been saved.");
    }

    public List<Entry> LoadFromFile()
    // Loads the data from the file and saves it to the list
    // In addition the line with the stattus of the download was added
    {
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(" | ");
            Entry entry = new Entry();
            entry._prompt = parts[0];
            entry._date = parts[1];
            entry._answer = parts[2];
            entry._mood = parts[3];
            _entriesJournal.Add(entry);
            
        }
        Console.WriteLine("The file has been downloaded.");
        return _entriesJournal;
    }

    public void DisplayJournal()
    // Displays every entry in the Jurnal using the ShowEntry() method
    {
        foreach (Entry element in _entriesJournal){
            element.ShowEntry();
            Console.WriteLine();
        }
    }

}