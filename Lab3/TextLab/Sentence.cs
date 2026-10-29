using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextLab
{
    public class Sentence
    {
        public List<Token> Tokens { get; set; } = new List<Token>();

        public IEnumerable<Word> Words => Tokens.OfType<Word>();
        public IEnumerable<Punctuation> Punctuations => Tokens.OfType<Punctuation>();

        public int WordCount => Words.Count();

        public bool IsInterrogative
        {
            get
            {
                var lastPunctuation = Punctuations.LastOrDefault();
                return lastPunctuation != null && lastPunctuation.Value.Contains("?");
            }
        }

        public int Length => GetFormattedText().Length;

        public string GetFormattedText()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Tokens.Count; i++)
            {
                var token = Tokens[i];
                if (i > 0 && token is Word && Tokens[i - 1] is Word)
                {
                    sb.Append(" ");
                }
                else if (i > 0 && token is Word && Tokens[i - 1] is Punctuation prevPunct && prevPunct.Value != "(")
                {
                    sb.Append(" ");
                }
                sb.Append(token.Value);
            }
            return sb.ToString();
        }

        public override string ToString() => GetFormattedText();
    }
}