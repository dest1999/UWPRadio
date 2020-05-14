using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace TmpForTest
{
    [Serializable]
    public class Station
    {
        public string Name { get; set; }
        public string UrlStream { get; set; }
        public Station() { }
        public Station(string name, string urlStream)
        {
            Name = name;
            UrlStream = urlStream;
        }
    }

    class TmpForTestProgram
    {
        static void Main(string[] args)
        {

        }
    }
}
