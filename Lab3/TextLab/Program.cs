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

       
        Text originalText = pars.ReadingFile(inputFile);
        Console.WriteLine("=== 1. Исходный текст из файла ===");
        Console.WriteLine(originalText);

        Console.WriteLine("\n=== 2. Конкорданс изначального текста ===");
        originalText.PrintConcordance();

        Console.WriteLine("\n=== 3. Предложения по возрастанию количества слов ===");
        foreach (var sentence in originalText.SentencesByWordCount())
        {
            Console.WriteLine($"[{sentence.WordCount} слов]: {sentence}");
        }

        Console.WriteLine("\n=== 4. Предложения по возрастанию длины ===");
        foreach (var sentence in originalText.SentencesByLength())
        {
            Console.WriteLine($"[{sentence.Length} симв.]: {sentence}");
        }

        Console.WriteLine("\n=== 5. Поиск слов длины 6 в вопросительных предложениях ===");
        var interrogativeWords = originalText.WordsInterrogativeSentences(6);
        if (interrogativeWords.Any())
        {
            foreach (var word in interrogativeWords)
            {
                Console.WriteLine($"- {word}");
            }
        }
        else
        {
            Console.WriteLine("Подходящие слова не найдены.");
        }

       

        
        Text textForConsonants = pars.ReadingFile(inputFile);
        int consonantLength = 5;
        textForConsonants.RemoveWordsStartingWithConsonant(consonantLength);
        Console.WriteLine($"\n=== 6. [Изначальный текст] После удаления слов длины {consonantLength}, начинающихся с согласной ===");
        Console.WriteLine(textForConsonants);

        
        Text textForReplace = pars.ReadingFile(inputFile);
        int sentenceIdx = 0;
        int wordLengthToReplace = 5;
        string replacement = "[ЗАМЕНЕНО]";
        textForReplace.ReplaceWordsInSentence(sentenceIdx, wordLengthToReplace, replacement);
        Console.WriteLine($"\n=== 7. [Изначальный текст] После замены слов длины {wordLengthToReplace} в предложении #{sentenceIdx + 1} ===");
        Console.WriteLine(textForReplace);

       
        Text textForStopWords = pars.ReadingFile(inputFile);
        string stopWordsFile = "stopwords_ru.txt";
        if (File.Exists(stopWordsFile))
        {
            var stopWordsList = File.ReadAllLines(stopWordsFile)
                                    .Select(line => line.Trim().ToLowerInvariant())
                                    .Where(line => !string.IsNullOrEmpty(line));

            ISet<string> stopWordsSet = new HashSet<string>(stopWordsList);
            textForStopWords.RemoveStopWords(stopWordsSet);

            Console.WriteLine($"\n=== 8. [Изначальный текст] После удаления стоп-слов из '{stopWordsFile}' ===");
            Console.WriteLine(textForStopWords);
        }

       
        string xmlPath = "output.xml";
        originalText.ExportToXml(xmlPath);
        Console.WriteLine($"\n=== 9. Экспорт исходного текста в XML сохранен в {xmlPath} ===");
    }
}