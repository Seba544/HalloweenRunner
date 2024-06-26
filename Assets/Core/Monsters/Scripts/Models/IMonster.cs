using System.ComponentModel;

namespace Models
{
    public interface IMonster : INotifyPropertyChanged
    {
        public string MonsterId { get; }
        public float CurrentSpeed { get; }
        void Move();
        void Stop();
    }
}