using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TextLab
{
    public class Text
    {
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();

        public IEnumerable<Sentence> SentencesByWordCount()
        {
            return Sentences.OrderBy(s => s.WordCount);
        }

        public IEnumerable<Sentence> SentencesByLength()
        {
            return Sentences.OrderBy(s => s.Length);
        }

        public IEnumerable<string> WordsInterrogativeSentences(int wordLength)
        {
            return Sentences
                .Where(s => s.IsInterrogative)
                .SelectMany(s => s.Words)
                .Select(w => w.Value)
                .Where(w => w.Length == wordLength)
                .Distinct(StringComparer.OrdinalIgnoreCase);
        }

        public void RemoveWordsStartingWithConsonant(int wordLength)
        {
            var consonants = new HashSet<char>(
                "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz" +
                "БВГДЖЗЙКЛМНПРСТФХЦЧШЩBCDFGHJKLMNPQRSTVWXYZ"
            );

            foreach (var sentence in Sentences)
            {
                sentence.Tokens.RemoveAll(token =>
                    token is Word word &&
                    word.Value.Length == wordLength &&
                    consonants.Contains(word.Value[0]));
            }
        }

        public bool ReplaceWordsInSentence(int sentenceIndex, int wordLength, string replacement)
        {
            if (sentenceIndex < 0 || sentenceIndex >= Sentences.Count)
                return false;

            var sentence = Sentences[sentenceIndex];
            for (int i = 0; i < sentence.Tokens.Count; i++)
            {
                if (sentence.Tokens[i] is Word word && word.Value.Length == wordLength)
                {
                    sentence.Tokens[i] = new Word(replacement);
                }
            }
            return true;
        }

        public void RemoveStopWords(ISet<string> stopWords)
        {
            foreach (var sentence in Sentences)
            {
                sentence.Tokens.RemoveAll(token =>
                    token is Word word && stopWords.Contains(word.Value.ToLowerInvariant()));
            }
        }


        public void ExportToXml(string filePath)
        {
            var dto = new XmlText
            {
                Sentences = Sentences.Select(s => new XmlSentenceDto
                {
                    Words = s.Words.Select(w => w.Value).ToList()
                }).ToList()
            };

            var serializer = new XmlSerializer(typeof(XmlText));
            var settings = new System.Xml.XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true
            };

            using (var writer = System.Xml.XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, dto);
            }
        }


        public override string ToString()
        {
            return string.Join(" ", Sentences.Select(s => s.GetFormattedText()));
        }
    }
}