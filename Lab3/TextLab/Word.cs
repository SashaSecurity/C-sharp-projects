using System;
using System.Collections.Generic;
using System.Text;

namespace TextLab
{
    public class Word : Token
    {
        public string Value { get; set; }

        public Word(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;
    }
}

