public class Word
{
    public string Text{get; private set; }
    private bool _isHidden;

    public Word( string text)
    {
        Text = text;
        _isHidden = false; // By default, the word is not hidden.
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show ()
    {
        _isHidden = false; 
    }

    public bool IsHidden
    {
        get{return _isHidden; }
        private set {_isHidden = value; }
    }
    public string GetRenderedText()
    {
        return _isHidden? "-----" : Text;
    }
}