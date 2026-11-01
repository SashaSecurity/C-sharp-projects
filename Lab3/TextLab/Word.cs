using System;
using System.Collections.Generic;
using System.Text;

namespace TextLab
{
    public class Word : Token
    {
        public string Value { get; set; }

        public int LineNumber{  get; set; }

        public Word(string value, int number=0)
        {
            Value = value;
            LineNumber=number;
        }


        public override string ToString() => Value;
    }
}

