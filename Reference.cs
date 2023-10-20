using System.Reflection.Metadata.Ecma335;

public class Reference
{
    private string _begRef;
    private string _startVerse;
    private string _endVerse;
    private int _verseDelta = 0;

    public Reference(string reference)
    {
        _begRef = reference;
    }

    public Reference(string begRef, string endVerse)
    {
        _begRef = begRef;

        _startVerse = begRef.Split(':')[1];

        _endVerse = endVerse;

        int firstVerse = Int32.Parse(_startVerse);

        int lastVerse = Int32.Parse(_endVerse);

        _verseDelta = lastVerse - firstVerse;
    }

    public string GetBegRef()
    {
        return _begRef;
    }

    public int GetVerseDelta()
    {
        return _verseDelta;
    }

    public string GetFullRef()
    {
        if (_verseDelta == 0)
        {
            return _begRef;
        }

        else
        {
            string fullRef = _begRef + "-" + _endVerse;

            return fullRef;
        }
    }
}