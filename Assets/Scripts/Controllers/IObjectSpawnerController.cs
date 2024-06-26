using System;
using System.ComponentModel;

namespace Controllers
{
    public interface IObjectSpawnerController : INotifyPropertyChanged,IDisposable
    {
        void RelocateObjectSpawnPosition(string objectId,float posX,float posY,float posZ);
        public bool IsGameOver { get; }
    }
}