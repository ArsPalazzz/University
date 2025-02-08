using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;


namespace Lab45.Vinyl
{
    public class Record : INotifyPropertyChanged
    {
        private string title;
        private int cost;
        private ulong article;
        private string songs;
        private string genre;
        private string year;

        public ImageSource imgPath { get; set; }
        //public string imgPath;
        //private string bodytype;
        //private string rating;

        public string Title
        {
            get { return title; }
            set
            {
                if (title == value)
                    return;
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                if (cost == value)
                    return;
                cost = value;
                OnPropertyChanged("Cost");
            }
        }
        //public string ImgPath
        //{
        //    get { return imgPath; }
        //    set
        //    {
        //        if (imgPath == value)
        //            return;
        //        imgPath = value;
        //        OnPropertyChanged("ImgPath");
        //    }
        //}
        //public string Description
        //{
        //    get { return description; }
        //    set
        //    {
        //        if (description == value)
        //            return;
        //        description = value;
        //        OnPropertyChanged("Description");
        //    }
        //}
        public string Songs
        {
            get { return songs; }
            set
            {
                if (songs == value)
                    return;
                songs = value;
                OnPropertyChanged("Songs");
            }
        }

        public ulong Article
        {
            get { return article; }
            set
            {
                if (article == value)
                    return;
                article = value;
                OnPropertyChanged("Article");
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                if (genre == value)
                    return;
                genre = value;
                OnPropertyChanged("Genre");
            }
        }

        public string Year
        {
            get { return year; }
            set
            {
                if (year == value)
                    return;
                year = value;
                OnPropertyChanged("Year");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}