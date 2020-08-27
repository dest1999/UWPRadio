using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace UWP_test
{
    [DataContract]
    public class Station: IComparable<Station>
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string UrlStream { get; set; }

        public int CompareTo(Station s)
        {
            return this.Name.CompareTo(s.Name);
        }

        public Station() { }

        public Station(string name, string urlStream)
        {
            this.Name = name;
            this.UrlStream = urlStream;
        }
    }
}
