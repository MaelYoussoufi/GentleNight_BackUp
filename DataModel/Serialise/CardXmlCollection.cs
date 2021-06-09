using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Assets.Scripts.DataModel.Card;

namespace Assets.Scripts.DataModel.Serialise
{
    [XmlRoot("CardCollection")]
    public class CardXmlCollection
    {
        
        [XmlArray("CardsList"), XmlArrayItem("Card")]
        public CardDataModel[] Cards;

        public string GetXml()
        {
            var serializer = new XmlSerializer(typeof(CardXmlCollection));
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }

        public static CardXmlCollection Load(string data)
        {
            var serializer = new XmlSerializer(typeof(CardXmlCollection));
            using (TextReader reader = new StringReader(data))
            {
                return  serializer.Deserialize(reader) as CardXmlCollection;
            }

        }

        public static CardXmlCollection Load(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(CardXmlCollection));
            return serializer.Deserialize(stream) as CardXmlCollection;
        }

    }
}
