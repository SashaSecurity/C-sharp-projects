using System;
using System.IO;
using TextLab;

public class Program
{

    public static void Main(string[] args)
    {
        string inputFile = "input.txt";
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл отсутсвует");
            return;
        }
        var pars = new Pars();
        Text text = pars.ReadingFile(inputFile);
        Console.WriteLine("--- Прочитанный и распарсенный текст из файла ---");
        Console.WriteLine(text);
    }
}