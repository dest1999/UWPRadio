using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace UWP_test
{
    //[Serializable]

    public class Station
    {
        public string Name { get; }
        public Uri UriStream { get; }
        public Station() { }
        public Station(string name, string urlStream)
        {
            Name = name;
            UriStream = new Uri(urlStream);
        }
    }
}
