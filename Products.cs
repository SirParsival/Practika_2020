using System;
using System.Xml.Serialization;

namespace ConsoleApplication2
{
    [XmlType(TypeName = "Products")]
    public class Products
    {
        [XmlAttribute(AttributeName = "Id")]
        public int Number { get; set; }

        [XmlAttribute(AttributeName = "Price")]
        public int Price { get; set; }

        [XmlAttribute(AttributeName = "Name of product")]
        public string Name_of_product { get; set; }
        
        [XmlAttribute(AttributeName = "Category")]
        public string Category { get; set; }

        [XmlAttribute(AttributeName = "Description")]
        public string Description { get; set; }
    }
}
