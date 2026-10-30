

namespace TextLab
{
    public class Punctuation : Token
    {
        public string Value { get; set; }
        public int Linenumber {  get; set; }

        public Punctuation(string value,int  number=0)
        {
            Value = value;
            Linenumber = number;
        }

        public override string ToString() => Value;
    }
}
