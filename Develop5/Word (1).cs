using System.Text.RegularExpressions;

public class Word
{
    private string _word;
    private bool _isModified;

    public Word(string word)
    {
        _word = word;

        _isModified = false;
    }

    public string GetWord()
    {
        return _word;
    }

    public void ModWord()
    {
        _word = Regex.Replace(_word, ".", "_");

        _isModified = true;
    }

    public bool GetModStatus()
    {
        return _isModified;
    }
}