using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextLab
{
    [XmlRoot("text")]
    public class XmlText
    {
        [XmlElement("sentence")]
        public List<XmlSentenceDto> Sentences { get; set; } = new List<XmlSentenceDto>();
    }

    public class XmlSentenceDto
    {
        [XmlElement("word")]
        public List<string> Words { get; set; } = new List<string>();
    }
}
