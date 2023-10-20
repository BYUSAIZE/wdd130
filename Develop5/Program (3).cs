using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
class Program
{
    static void Main(string[] args)
    {
        

        //get random scriptures
        ScriptureLibrary library = new ScriptureLibrary();

        //get a random scripture from the library 
        Scripture scripture = library.GetRandomScripture();

        // Start the interactive process 
        scripture.InteractiveWordHidding();

        // string referenceText = "John 3:16-16";
        // string scriptureText = "For God so loved the world, that he gave his only begotten Son,\n that whosoever believeth in him should not perish, but have heverlasting life.";
        // Scripture scripture = new Scripture(referenceText, scriptureText);

        // // Start the interactive process
        // scripture.InteractiveWordHidding();

    }
}