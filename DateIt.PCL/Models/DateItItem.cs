using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DateIt.PCL.Annotations;

namespace DateIt.PCL.Models
{
    public class DateItItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int BarcodeId { get; set; }
        public int ShelfLifeInDays { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
