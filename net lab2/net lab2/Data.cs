
using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace net_lab2
{

    [Serializable, XmlRoot("Data")]
    public class Data
    {
        [XmlElement("Commandants")]
        public List<Commandant> Commandants { get; set; } = new List<Commandant>();
        [XmlElement("Studnets")]
        public List<Student> Students { get; set; } = new List<Student>();
        [XmlElement("Hostels")]
        public List<Hostel> Hostels { get; set; } = new List<Hostel>();
        [XmlElement("Settlements")]
        public List<Settlement> Settlements { get; set;} = new List<Settlement>();
    }
}
