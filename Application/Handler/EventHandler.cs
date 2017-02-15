using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App1.Annotations;
using App1.Converter;
using App1.Model;
using App1.Persistency;
using App1.View;
using App1.ViewModel;

namespace App1.Handler
{
    public class EventHandler : INotifyPropertyChanged
    {
        public EventViewModel EventViewModel { get; set; }
        
        public EventHandler(EventViewModel ev)
        {
            EventViewModel = ev;
        }

        public void LoadEvents()
        {
            EventViewModel.CatalogSingleton.LoadEventsAsync();
        }

        public void CreateEvent()
        {
            try
            {
                EventViewModel.CatalogSingleton.Add(new Event()
                {
                    Name = EventViewModel.Name,
                    Description = EventViewModel.Description,
                    Place = EventViewModel.Place,
                    Time = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time),
                    ID = EventViewModel.CatalogSingleton.list.Count + 1
                });
            }
            catch (ArgumentOutOfRangeException e)
            {
                EventViewModel.Message = e.Message;
                OnPropertyChanged(nameof(EventViewModel.Message));
            }
           
        }

        public void RemoveEvent()
        {
            EventViewModel.CatalogSingleton.RemoveEvent(EventViewModel.SelectedEventIndex);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
