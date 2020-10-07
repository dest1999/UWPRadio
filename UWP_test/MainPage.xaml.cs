using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Xml;
//using System.Xml.Serialization;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Media.Core;
using System.Runtime.Serialization;
using System.Threading;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWP_test
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>

        /*TODO
         * сохранение и считывание станций через файл (сериализация?)
         * ИЛИ БД
         * добавление и удаление станций
         */



    public sealed partial class MainPage : Page
    {
        #region Globals

        Uri uriFileStations = new Uri("ms-appx:///assets/Stations.xml");
        List<Station> stations = new List<Station>();

        //XmlSerializer serializer = new XmlSerializer(typeof(List<Station>));
        string content;

        #endregion

        #region URL RadioStations
        /*
         * string addr = "https://online.rockarsenal.ru/rockarsenal_aacplus";
         * addr = "http://stream2.dancewave.online:8080/retrodance.ogg";
         * 
        Sputnik (Московское радио, Голос России) (1929) © МИА «Россия сегодня»
        256 - http://audio2.video.ria.ru:80/voicerushi

        Маяк (1964) © ВГТРК
        192 - http://icecast.vgtrk.cdnvideo.ru/mayakfm_mp3_192kbps

        Радио России (1990) © ВГТРК
        192 - http://icecast.vgtrk.cdnvideo.ru/rrzonam_mp3_192kbps

        Радио Культура (2004) © ВГТРК
        192 - http://icecast.vgtrk.cdnvideo.ru/kulturafm_mp3_192kbps

        Вести FM (2008) © ВГТРК
        192 - http://icecast.vgtrk.cdnvideo.ru/vestifm_mp3_192kbps

        Радио Комсомольская правда (2009) © ИД «Комсомольская правда»
        128 - http://kpradio.hostingradio.ru:8000/russia.radiokp128.mp3

        Коммерсантъ FM (2010) © ИД «Коммерсантъ»
        128 - http://kommersant77.hostingradio.ru:8016/kommersant128.mp3

        М Радио 103,3 FM 
        http://icecast.rest.str.ru:8000/mradio.aac

        Сайт: retro.dancewave.online
        MP3 128 - http://stream.dancewave.online:8080/retrodance.mp3
        MP3 128 - http://stream2.dancewave.online:8080/retrodance.mp3
        OGG - http://stream2.dancewave.online:8080/retrodance.ogg
        
        */

        #endregion
        
        //заполнили список станций, после успешного добавления сериализации нужно убрать
        void DirectAddStationsToList()
        {
            stations.Add(new Station("Rock Arsenal", "https://online.rockarsenal.ru/rockarsenal_aacplus"));
            stations.Add(new Station("Test wrong URL", "https://online.rockarsenal.ru/rockrsenal_aacplus"));
            stations.Add(new Station("RetroDance", "http://stream.dancewave.online:8080/retrodance.mp3"));
            stations.Add(new Station("Коммерсантъ FM", "http://kommersant77.hostingradio.ru:8016/kommersant128.mp3"));
            stations.Add(new Station("Спутник RT", "http://audio2.video.ria.ru:80/voicerushi"));
            stations.Add(new Station("Маяк", "http://icecast.vgtrk.cdnvideo.ru/mayakfm_mp3_192kbps"));
            stations.Add(new Station("Радио России", "http://icecast.vgtrk.cdnvideo.ru/rrzonam_mp3_192kbps"));
            stations.Add(new Station("Культура", "http://icecast.vgtrk.cdnvideo.ru/kulturafm_mp3_192kbps"));
            stations.Add(new Station("Вести FM", "http://icecast.vgtrk.cdnvideo.ru/vestifm_mp3_192kbps"));
            stations.Add(new Station("Радио КП", "http://kpradio.hostingradio.ru:8000/russia.radiokp128.mp3"));
            stations.Add(new Station("М-Радио", "http://icecast.rest.str.ru:8000/mradio.aac"));
        }

        private void SaveStationsToFile()
        {
            stations.Add(new Station("!tmp", ""));
            stations.Sort();

            var ds = new DataContractSerializer(typeof(List<Station>));

            using (var fileWrite = File.Create("Stations.xml"))
                ds.WriteObject(fileWrite, stations);
        }

        private void AddStationsToList()
        {
            #region закомментированные станции для добавления в List
            //stations.Add(new Station("Rock Arsenal", "https://online.rockarsenal.ru/rockarsenal_aacplus"));
            //stations.Add(new Station("Test wrong URL", "https://online.rockarsenal.ru/rockrsenal_aacplus"));
            //stations.Add(new Station("RetroDance", "http://stream.dancewave.online:8080/retrodance.mp3"));
            //stations.Add(new Station("Коммерсантъ FM", "http://kommersant77.hostingradio.ru:8016/kommersant128.mp3"));
            //stations.Add(new Station("Спутник RT", "http://audio2.video.ria.ru:80/voicerushi"));
            //stations.Add(new Station("Маяк", "http://icecast.vgtrk.cdnvideo.ru/mayakfm_mp3_192kbps"));
            //stations.Add(new Station("Радио России", "http://icecast.vgtrk.cdnvideo.ru/rrzonam_mp3_192kbps"));
            //stations.Add(new Station("Культура", "http://icecast.vgtrk.cdnvideo.ru/kulturafm_mp3_192kbps"));
            //stations.Add(new Station("Вести FM", "http://icecast.vgtrk.cdnvideo.ru/vestifm_mp3_192kbps"));
            //stations.Add(new Station("Радио КП", "http://kpradio.hostingradio.ru:8000/russia.radiokp128.mp3"));
            //stations.Add(new Station("М-Радио", "http://icecast.rest.str.ru:8000/mradio.aac"));
            #endregion

            var ds = new DataContractSerializer(typeof(List<Station>));
            
            using (var fileRead = File.OpenRead("Assets/Stations.xml"))
                stations = (List<Station>)ds.ReadObject(fileRead); // десериализация из файла
            
            /*
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync("Stations.xml");

            var stream = await file.OpenAsync(FileAccessMode.Read);
            ulong size = stream.Size;
            using(var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);

                    //stations = (List<Station>)ds.ReadObject(dataReader);


                    //ds = dataReader.ReadBytes(numBytesLoded);

                }
            }
            */


            //var buffer = await FileIO.ReadBufferAsync(file);
            //using(var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            //{
            //    ds = dataReader.ReadBuffer(buffer.Length);
            //}


            stations.Sort();
        }

        public MainPage()
        {
            this.InitializeComponent();

            if (stations.Count == 0) // станций в списке нет, нужно добавить
            {
                AddStationsToList();
                //DirectAddStationsToList();

            }
            //stations.Sort();
        }

        void StopMediaPlaybackMethod()
        {
            mediaPlayerElement.MediaPlayer.Source = null;

        }

        void PlayMethod()
        {
            mediaPlayerElement.MediaPlayer.SetUriSource(new Uri(stations[listBoxStations.SelectedIndex].UrlStream));
            
            //mediaPlayerElement.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(stations[listBoxStations.SelectedIndex].UrlStream)); с этим методом происходит утечка трафика и памяти
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            PlayMethod();
        }

        private void ListBoxStations_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            PlayMethod();
        }

        private void ListBoxStations_Loaded(object sender, RoutedEventArgs e)
        {
            //stations.Sort();
            listBoxStations.SelectedIndex = 0;
            
        }

        
        private void Pause_Save_Click(object sender, RoutedEventArgs e)
        {
            StopMediaPlaybackMethod();
            //SaveStationsToFile();
        }

        private void CheckBoxRealTimeTransport_Click(object sender, RoutedEventArgs e)
        {
            if ( checkBoxRealTimeTransport.IsChecked == true )
                mediaPlayerElement.MediaPlayer.RealTimePlayback = true; //уменьшение зависаний звука при начале воспроизведения
            else
                mediaPlayerElement.MediaPlayer.RealTimePlayback = false; //уменьшение зависаний звука при начале воспроизведения

        }

        private void ToggleSwitchAlarmClock_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var timespan = new TimeSpan();
            timespan = AlarmTimeSetter.Time - DateTime.Now.TimeOfDay;
            //(DateTime);

            var alarmTimerTask = Task.Delay(timespan);
            PlayMethod();
        }

        //https://docs.microsoft.com/ru-ru/uwp/api/windows.ui.xaml.controls.timepicker.time?view=winrt-19041#Windows_UI_Xaml_Controls_TimePicker_Time
        //https://docs.microsoft.com/en-us/dotnet/api/system.timespan?redirectedfrom=MSDN&view=netcore-3.1
        //https://docs.microsoft.com/ru-ru/windows/uwp/design/controls-and-patterns/toggles

        private void ToggleSwitchAlarmClock_IsEnabledChanged(object sender, RoutedEventArgs e)
        {
            if (toggleSwitchAlarmClock.IsOn)
            {
                AlarmTimeSetter.IsEnabled = true;

            }
            else
            {
                AlarmTimeSetter.IsEnabled = false;

            }
        }


    }
}
