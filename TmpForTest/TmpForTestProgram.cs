using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TmpForTest
{
    [DataContract]
    public class Station
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string UrlStream { get; set; }
        public Station(string name, string urlStream)
        {
            Name = name;
            UrlStream = urlStream;
        }
    }

    [DataContract]
    public class Person
    {
        [DataMember] public string Name;
        [DataMember] public int Age;
    }

    class TmpForTestProgram
    {

        static void Main(string[] args)
        {

            List<Station> stations = new List<Station>
            {
                new Station("Rock Arsenal", "https://online.rockarsenal.ru/rockarsenal_aacplus"),
                new Station("Test wrong URL", "https://online.rockarsenal.ru/rockrsenal_aacplus"),
                new Station("RetroDance", "http://stream.dancewave.online:8080/retrodance.mp3"),
                new Station("Коммерсантъ FM", "http://kommersant77.hostingradio.ru:8016/kommersant128.mp3"),
                new Station("Спутник RT", "http://audio2.video.ria.ru:80/voicerushi"),
                new Station("Маяк", "http://icecast.vgtrk.cdnvideo.ru/mayakfm_mp3_192kbps"),
                new Station("Радио России", "http://icecast.vgtrk.cdnvideo.ru/rrzonam_mp3_192kbps"),
                new Station("Культура", "http://icecast.vgtrk.cdnvideo.ru/kulturafm_mp3_192kbps"),
                new Station("Вести FM", "http://icecast.vgtrk.cdnvideo.ru/vestifm_mp3_192kbps"),
                new Station("Радио КП", "http://kpradio.hostingradio.ru:8000/russia.radiokp128.mp3"),
                new Station("М-Радио", "http://icecast.rest.str.ru:8000/mradio.aac")
            };
            /*  рабочий пример сериализации Microsoft
            FileStream file = new FileStream("stations.xml", FileMode.Create);
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(file);
            DataContractSerializer dataSerializer = new DataContractSerializer(typeof(List<Station>));
            dataSerializer.WriteObject(writer, stations);
            writer.Close();
            file.Close();
            */


            DataContractSerializer ds = new DataContractSerializer(typeof(List<Station>));

            using (Stream fileWrite = File.Create("person.xml"))
                ds.WriteObject(fileWrite, stations); // Сериализация

            stations.Clear();

            using (Stream fileRead = File.OpenRead("person.xml"))
                stations = (List<Station>)ds.ReadObject(fileRead); // десериализация


            Console.WriteLine();







        }
    }
}
