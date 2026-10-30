using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextLab
{
    public class Pars
    {
        public Text ReadingFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException($"Файл не найден");

            }
            string FullText = File.ReadAllText(file);
            return SearchSentence(FullText);
        }
        public Text SearchSentence(string FullText)
        {
            var text = new Text();
            if (string.IsNullOrEmpty(FullText)) return text;

            var matcher = Regex.Matches(FullText, @"[\p{L}\p{Nd}]+(?:-[\p{L}\p{Nd}]+)*|[^\s\p{L}\p{Nd}]+|\s+");
            var currSentence = new Sentence();

            for (int i = 0; i < matcher.Count; i++)
            {
                Match match = matcher[i];
                string tokenStr = match.Value;

                if (string.IsNullOrEmpty(tokenStr)) continue;

                if (Regex.IsMatch(tokenStr, @"^[\p{L}\p{Nd}]+(?:-[\p{L}\p{Nd}]+)*$"))
                {
                    currSentence.Tokens.Add(new Word(tokenStr));
                }
                else
                {
                    currSentence.Tokens.Add(new Punctuation(tokenStr));

                    if (Regex.IsMatch(tokenStr, @"[.!?]"))
                    {
                        text.Sentences.Add(currSentence);
                        currSentence = new Sentence();
                    }
                }
            }
            if (currSentence.Tokens.Any())
            {
                text.Sentences.Add(currSentence);
            }
            return text;
        }
    }
}
