public class Scripture
{

    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }
    private List<Word> hiddenWords;
    private string Text;
    public Scripture(Reference reference,  string text)  //string referenceText, string text)
    {
        Reference = reference;
        Text = text;
        hiddenWords = new List<Word>();
        Words = Text.Split(' ').Select(word => new Word(word)).ToList();
    

    }
    public void HideRandomWord()
    {
        Random random = new Random();
        List<Word> wordsToHide = Words.Except(hiddenWords).ToList ();
        if (wordsToHide.Count > 0)
        {
            int index = random.Next(0, wordsToHide.Count);
            Word wordToHide = wordsToHide[index];
            wordToHide.Hide();
            hiddenWords.Add(wordToHide);
        }
    }
    public string GetRenderedText()
    {
        List<string> renderedWords = new List<string> ();

        foreach (Word word in Words)
        {
            if (word.IsHidden)
            {
                renderedWords.Add("------");
            }
            else
            {
                renderedWords.Add(word.Text);
            }
        }
        return string.Join (" ", renderedWords);
    }
    public bool IsCompletlyHidden()
    {
        return hiddenWords.Count == Words.Count;
    }

    public override string ToString()
    {
    return $"Scripture: {Reference}, Text: {Text}";
    }
    public void InteractiveWordHidding()
    {
        Console.Clear();
        Console.WriteLine($"{Reference}");
        Console.WriteLine(Text);

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "quit")
            {
                break;
            }

            HideRandomWord();
            Console.Clear();
            Console.WriteLine($"Scripture: {Reference}");
            Console.WriteLine(GetRenderedText());


            if (IsCompletlyHidden())
            {
                Console.WriteLine("\nAll words in the scripture are hidden");
                break;
            }
        }
    }
}