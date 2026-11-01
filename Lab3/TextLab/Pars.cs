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
            if (string.IsNullOrWhiteSpace(FullText)) return text;
            string[] lines = FullText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            
            var currSentence = new Sentence();

            for (int i = 0; i < lines.Length; i++)
            {
                int currentLineNumber = i + 1;
                var matcher = Regex.Matches(lines[i], @"[\p{L}\p{Nd}]+(?:-[\p{L}\p{Nd}]+)*|[^\s\p{L}\p{Nd}]+|\s+");


                for (int j = 0; j < matcher.Count; j++)
                {
                    int currentLineNumber = j + 1
                    Match match = matcher[j];
                    string tokenStr = match.Value;

                    if (string.IsNullOrWhiteSpace(tokenStr)) continue;

                    if (Regex.IsMatch(tokenStr, @"^[\p{L}\p{Nd}]+(?:-[\p{L}\p{Nd}]+)*$"))
                    {
                        currSentence.Tokens.Add(new Word(tokenStr, currentLineNumber));
                    }
                    else
                    {
                        currSentence.Tokens.Add(new Punctuation(tokenStr, currentLineNumber));

                        if (Regex.IsMatch(tokenStr, @"[.!?]"))
                        {
                            text.Sentences.Add(currSentence);
                            currSentence = new Sentence();
                        }
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
