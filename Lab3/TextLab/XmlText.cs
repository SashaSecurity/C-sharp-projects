using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextLab
{
    [XmlRoot("text")]
    public class XmlText
    {
        [XmlElement("sentence")]
        public List<XmlSentence> Sentences { get; set; } = new List<XmlSentence>();
    }

    public class XmlSentence
    {
        [XmlElement("word")]
        public List<string> Words { get; set; } = new List<string>();
    }
}