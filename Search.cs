namespace TextSearch;

public class Search
{
    public Search(string? word, string[]? arrayFile)
    {
        word = Word;
        ArrayFile = ArrayFile;
    }
    public string? Word { get; set; }
    public string? ArrayFile { get; set; }

    public string[] MakeSearch(string Word, string[] ArrayFile)
    {

        string searchTerm = Word;
        List<string> result = new List<string>();
        int loop = 0;
        foreach (string text in ArrayFile)
        {

            //Convert the string into an array of words (is like using stopwords)
            string[] v_ArrayFile = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);

            // Create the query.  Use the InvariantCultureIgnoreCase comparision to match "data" and "Data"
            var matchQuery = from word in v_ArrayFile
                             where word.Equals(searchTerm, StringComparison.InvariantCultureIgnoreCase)
                             select word;

            // Count the matches, which executes the query.  
            int wordCount = matchQuery.Count();

            //Console.WriteLine("{0}: {1} occurrences(s) of the search term \"{2}\" were found.", files[loop], wordCount, searchTerm);
            result.Add(wordCount + " occurrences(s) of " + searchTerm + " in " + ArrayFile[loop]);
            loop++;

        }

        return result.ToArray();
    }

}
