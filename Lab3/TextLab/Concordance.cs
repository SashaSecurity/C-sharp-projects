using System.Collections.Generic;

namespace TextLab
{
    public class ConcordanceItem
    {
        public string Word { get; set; }
        public int Frequency { get; set; }
        public SortedSet<int> LineNumbers { get; set; } = new SortedSet<int>();

        public string GetFormattedString(int maxWordLength)
        {
            int dotsCount = (maxWordLength + 5) - Word.Length;
            if (dotsCount < 1) dotsCount = 1;

            string dots = new string('.', dotsCount);
            string lines = string.Join(" ", LineNumbers);

            return $"{Word}{dots}{Frequency}: {lines}";
        }
    }
}