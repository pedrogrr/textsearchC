namespace TextSearch;

public class Files
{
    public Files(Directorio directorio)
    {
       
        Directorio = directorio;
    }
    
    public Directorio? Directorio { get; set; }
    public string[]? ArrayFile;
    public string[]? FileNames;

    public int numFiles;
    public string[] LoadFiles(string Directorio)
    {
        string[] ArrayFile;
        ArrayFile = Directory.GetFiles(Directorio, "*.txt");
        
        //Console.WriteLine("LoadFiles: Construyo array de {0} elementos\n", ArrayFile.Length);
        numFiles = ArrayFile.Length;
        int eje_X = 0;
        foreach (string files in ArrayFile)
        {
            //string[] renglones = File.ReadAllLines(archivo).Select(s => s.ToLowerInvariant()).ToArray();
            string[] renglones = File.ReadAllLines(files);
            ArrayFile[eje_X] = files.ToString() +"\n"+string.Join("\n", renglones);
            eje_X++;
        }

        

        return ArrayFile;


    }
}
