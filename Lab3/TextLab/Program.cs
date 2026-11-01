using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextLab;

public class Program
{
    public static void Main(string[] args)
    {
        string inputFile = "input.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл input.txt отсутствует в директории.");
            return;
        }

        var pars = new Pars();
        Text text = pars.ReadingFile(inputFile);

        Console.WriteLine(" 1. Исходный текст из файла ");
        Console.WriteLine(text);

        Console.WriteLine("\n 2. Вывод по возрастанию количества слов");
        foreach (var sentence in text.SentencesByWordCount())
        {
            Console.WriteLine($"[{sentence.WordCount} слов]: {sentence}");
        }

        Console.WriteLine("\n 3. Вывод по возрастанию длины предложения");
        foreach (var sentence in text.SentencesByLength())
        {
            Console.WriteLine($"[{sentence.Length} симв.]: {sentence}");
        }

        Console.WriteLine("\n 4. Поиск слов длины 4 в вопросительных предложениях");
        var interrogativeWords = text.WordsInterrogativeSentences(4);
        if (interrogativeWords.Any())
        {
            foreach (var word in interrogativeWords)
            {
                Console.WriteLine($"- {word}");
            }
        }
        else
        {
            Console.WriteLine("Вопросительные предложения или подходящие слова не найдены.");
        }

       
        int sentenceIdx = 0;
        int wordLengthToReplace = 5;
        string replacement = "[ЗАМЕНЕНО]";

        text.ReplaceWordsInSentence(sentenceIdx, wordLengthToReplace, replacement);
        Console.WriteLine($"\n=== 5. Текст после замены слов длины {wordLengthToReplace} в предложении #{sentenceIdx + 1} ===");
        Console.WriteLine(text);

       
        string stopWordsFile = "stopwords_ru.txt";
        if (File.Exists(stopWordsFile))
        {
            var stopWordsList = File.ReadAllLines(stopWordsFile)
                                    .Select(line => line.Trim().ToLowerInvariant())
                                    .Where(line => !string.IsNullOrEmpty(line));

            ISet<string> stopWordsSet = new HashSet<string>(stopWordsList);
            text.RemoveStopWords(stopWordsSet);

            Console.WriteLine($"\n=== 6. Текст после удаления стоп-слов из '{stopWordsFile}' ===");
            Console.WriteLine(text);
        }
        else
        {
            Console.WriteLine($"\n=== 6. Файл со стоп-словами '{stopWordsFile}' не найден (пропущено) ===");
        }

       
        string xmlPath = "output.xml";
        text.ExportToXml(xmlPath);
        Console.WriteLine($"\n=== 7. Экспорт в XML сохранен в {xmlPath} ===");

       
        Console.WriteLine("\n=== 8. Конкорданс текста ===");
        text.PrintConcordance();
    }
}