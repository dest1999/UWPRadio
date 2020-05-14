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
using System.Xml.Serialization;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWP_test
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>

        /*TODO
         * сохранение и считывание станций через файл (сериализация?)
         * добавление и удаление станций
         * сортировка списка станций
         * биндинг из коллекции в listboxStations
         * фоновое воспроизведение
         */



    public sealed partial class MainPage : Page
    {
        #region Globals

            Uri uri = new Uri("ms-appx:///assets/Lady_Gaga_-_Alejandro.mp3");
            Uri uriHot = new Uri("ms-appx:///assets/Katy Perry - Hot N Cold.mp3");
            List<Station> stations = new List<Station>();

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
        
        * mediaElement.Source = new Uri(addr);
        */

        #endregion

        private void AddStationsToList()
        {
            stations.Add(new Station("Rock Arsenal", "https://online.rockarsenal.ru/rockarsenal_aacplus"));
            stations.Add(new Station("RetroDance", "http://stream.dancewave.online:8080/retrodance.mp3"));
            stations.Add(new Station("Коммерсантъ FM", "http://kommersant77.hostingradio.ru:8016/kommersant128.mp3"));
            stations.Add(new Station("Спутник RT", "http://audio2.video.ria.ru:80/voicerushi"));
            stations.Add(new Station("Маяк", "http://icecast.vgtrk.cdnvideo.ru/mayakfm_mp3_192kbps"));
            stations.Add(new Station("Радио России", "http://icecast.vgtrk.cdnvideo.ru/rrzonam_mp3_192kbps"));
            stations.Add(new Station("Культура", "http://icecast.vgtrk.cdnvideo.ru/kulturafm_mp3_192kbps"));
            stations.Add(new Station("Вести FM", "http://icecast.vgtrk.cdnvideo.ru/vestifm_mp3_192kbps"));
            stations.Add(new Station("Радио КП", "http://kpradio.hostingradio.ru:8000/russia.radiokp128.mp3"));
            stations.Add(new Station("М-Радио", "http://icecast.rest.str.ru:8000/mradio.aac"));

            //stations.Sort()
            FillListBoxStations();
        }

        private void FillListBoxStations()
        {
            foreach (var item in stations)
            {
                listBoxStations.Items.Add(item.Name);
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            if (stations.Count == 0) // станций в списке нет, нужно добавить
            {
                AddStationsToList();
            }
            listBoxStations.SelectedIndex = 0;

        }

        void PlayMethod()
        {
            mediaElement.Source = stations[listBoxStations.SelectedIndex].UriStream;
            mediaElement.Play();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            PlayMethod();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void ChangeTrack_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Source = uri;
            mediaElement.Play();
        }

        private void ChangeHot_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Source = uriHot;
            mediaElement.Play();
        }

        private void ListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            PlayMethod();
        }
    }
}
