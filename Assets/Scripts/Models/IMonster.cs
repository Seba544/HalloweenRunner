using System.ComponentModel;

namespace Models
{
    public interface IMonster : INotifyPropertyChanged
    {
        public float CurrentSpeed { get; set; }
        void Move();
        void Stop();
    }
}