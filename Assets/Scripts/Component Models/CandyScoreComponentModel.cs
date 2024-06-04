using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Component_Models.Contracts;
using Events;

namespace Component_Models
{
    public class CandyScoreComponentModel : ICandyScoreComponentModel
    {
        private readonly IEventBus _eventBus;
        private int _amountOfCandies;

        public CandyScoreComponentModel(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _eventBus.Subscribe<CollectCandyEvent>(OnCollectCandyEvent);
        }

        private void OnCollectCandyEvent(CollectCandyEvent _)
        {
            AmountOfCandies++;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<CollectCandyEvent>(OnCollectCandyEvent);
        }

        public int AmountOfCandies
        {
            get => _amountOfCandies;
            set
            {
                if (value != _amountOfCandies)
                {
                    _amountOfCandies = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
