namespace TextLab
{
    public class Punctuation : Token
    {
        public string Value { get; set; }

        public int LineNumber { get; set; }

        public Punctuation(string value, int number = 0)
        {
            Value = value;
            LineNumber = number;
        }

        public override string ToString() => Value;
    }
}
