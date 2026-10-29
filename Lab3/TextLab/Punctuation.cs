using System;
using System.Collections.Generic;
using System.Text;

namespace TextLab
{
    public class Punctuation : Token
    {
        public string Value { get; set; }

        public Punctuation(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;
    }
}
