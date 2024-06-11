using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class Monster : IMonster
    {
        private readonly float _speed;
        private float _currentSpeed;

        public Monster(float speed)
        {
            _speed = speed;
        }
        public float CurrentSpeed
        {
            get => _currentSpeed;
            set
            {
                if (value != _currentSpeed)
                {
                    _currentSpeed = value;
                    OnPropertyChanged();
                }
            } 
        }

        public void Move()
        {
            CurrentSpeed = _speed;
        }

        public void Stop()
        {
            CurrentSpeed = 0f;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}