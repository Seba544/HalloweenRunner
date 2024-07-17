using System;
using System.ComponentModel;

namespace Controllers
{
    public interface ICandyScoreController : IDisposable,INotifyPropertyChanged
    {
        public int AmountOfCandies { get; set; }
    }
}