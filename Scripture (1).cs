using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
public class Scripture
{
    private Reference _reference;
    private List<Verse> _verseList;
    private string _verseText;
    private List<Word> _wordList;
    private int _difficulty;
    private int _wordCounter = 0;

    public Scripture(string reference, int difficulty)
    {
        bool verseRange = reference.Contains('-');

        if (verseRange)
        {
            string begRef = reference.Split('-')[0];

            string endVerse = reference.Split('-')[1];

            _reference = new Reference(begRef, endVerse);
        }

        else
        {
            _reference = new Reference(reference);
        }

        _difficulty = difficulty;

        _verseList = this.LoadVerses();

        _verseText = this.BuildText();

        _wordList = this.BuildWordList();
    }

    public string GetText()
    {
        return _verseText;
    }

    public string GetReference()
    {
        return _reference.GetFullRef();
    }

    private List<Verse> LoadVerses()
    {
        using FileStream json = File.OpenRead("lds-scriptures.txt");

        List<Verse> verseList = JsonSerializer.Deserialize<List<Verse>>(json);

        return verseList;
    }

    private string BuildText()
    {
        foreach (Verse verse in _verseList)
        {
            if (verse._verseTitle == _reference.GetBegRef())
            {
                string verseText = verse._scriptureText;

                int indexOfVerse = _verseList.IndexOf(verse);

                for (int i = 0; i < _reference.GetVerseDelta(); i++)
                {
                    verseText = verseText + " " + _verseList[(indexOfVerse + 1 + i)]._scriptureText;
                }

                return verseText;
            }
        }

        return "Scripture not found.";
    }

    private List<Word> BuildWordList()
    {
        string[] words = _verseText.Split(' ');

        List<Word> wordList = new List<Word>();

        foreach (var word in words)
        {
            Word newWord = new Word(word);

            wordList.Add(newWord);
        }

        return wordList;
    }

    public void ModifyWords()
    {
        if (_difficulty == 4)
        {
            _wordCounter = _wordList.Count;

            foreach (Word word in _wordList)
            {
                word.ModWord();
            }
        }

        else
        {
            int length = _wordList.Count;

            Random randNum = new Random();

            for (int i = 0; i < (_difficulty * 3); i++)
            {
                if (_wordCounter < length)
                {
                    bool notModified = true;

                    while (notModified)
                    {
                        int number = randNum.Next(0, length);

                        if (_wordList[number].GetModStatus() == false)
                        {
                            _wordList[number].ModWord();

                            notModified = false;

                            _wordCounter++;
                        }
                    }
                }

                else
                {
                    break;
                }
            }
        }
    }

    public int AreAllWordsModified()
    {
        if (_wordCounter == _wordList.Count())
        {
            return 1;
        }

        else
        {
            return 0;
        }
    }

    private string GetModifiedText()
    {
        string modifiedText = "";

        foreach (Word word in _wordList)
        {
            modifiedText = modifiedText + word.GetWord() + " ";
        }

        return modifiedText;
    }

    public void DisplayScriptures()
    {
        Console.Clear();

        this.ModifyWords();

        Console.WriteLine($"{_reference.GetFullRef()} - {this.GetModifiedText()}");
    }
}