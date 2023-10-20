public class ScriptureLibrary
{
    public List<Scripture> Scriptures { get; private set;}

    public ScriptureLibrary()
    {
        Scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John 3:16.16"),"For God so loved the world, that he gave his only begotten Son,\nthat whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs 3:5.6"),"Trust in the Lord with all thine heart; and lean not unto thine own understanding.\n In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Nephi 1:3.4"),"And they had all things common among them; therefore there were not rich and poor, bond and free, but they were all made free, and partakers of the heavenly gifrt.\nAnd it came to pass that the thity and seventh year passed away also, and there still continued to be peace in the land"),           
        };
    }
    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, Scriptures.Count);
        return Scriptures[randomIndex];
    }
}