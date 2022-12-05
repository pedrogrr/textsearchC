using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using static System.Net.WebRequestMethods;

namespace TextSearch;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter directory:");
        String p_dir;
        p_dir = Console.ReadLine();


        String p_word = "";


        string v_path = AppDomain.CurrentDomain.BaseDirectory;
        string v_searchword = "exit";

        if (p_dir != "") { v_path = @p_dir; };
        Directorio dir = new Directorio(v_path);

        Files files = new Files(dir);
        string[] v_ArrayFile = files.LoadFiles(dir.path);

        Console.WriteLine("{0} files in {1}", files.numFiles, dir.path);
        
        Search search = new Search(p_word, v_ArrayFile);

        while (p_word != "exit")
        {
            Console.WriteLine("Enter searchword ('exit' to end):");
            p_word = Console.ReadLine();
            if (p_word != "exit") { v_searchword = @p_word; }
            else break;

            string[] result = search.MakeSearch(v_searchword, v_ArrayFile);

            Comparison<string> comparador = new Comparison<string>((cadena1, cadena2) => cadena2.CompareTo(cadena1));
            // Llamar a Array.Sort, pasando el arreglo a ordenar y el comparador
            Array.Sort<string>(result, comparador);
            // Ahora simplemente imprimimos
            string encontrado = result[0].Substring(0, 1);
            
            if (encontrado == "0")
            {
                Console.WriteLine("no matches found");
            }
            else
            {
                int top =result.Length;
                if (top>10) { top = 10; };
                for (int i = 0; i < top; i++)
                {
                    Console.WriteLine("{0}", string.Join("\n", result[i]));
                }
            }
        };




    }


}






