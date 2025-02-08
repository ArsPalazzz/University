using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;


namespace Lab45.Models
{
    public class Auto : INotifyPropertyChanged
    {
        private string title;
        private int cost;
        public ImageSource imgPath { get; set; }
        //public string imgPath;
        private string bodytype;
        private string rating;

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
        public string Bodytype
        {
            get { return bodytype; }
            set
            {
                if (bodytype == value)
                    return;
                bodytype = value;
                OnPropertyChanged("BodyType");
            }
        }
        public string Rating
        {
            get { return rating; }
            set
            {
                if (rating == value)
                    return;
                rating = value;
                OnPropertyChanged("Rating");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}