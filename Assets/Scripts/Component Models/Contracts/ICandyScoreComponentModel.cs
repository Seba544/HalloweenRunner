using System;
using System.ComponentModel;

namespace Component_Models.Contracts
{
    public interface ICandyScoreComponentModel : IDisposable,INotifyPropertyChanged
    {
        public int AmountOfCandies { get; set; }
    }
}