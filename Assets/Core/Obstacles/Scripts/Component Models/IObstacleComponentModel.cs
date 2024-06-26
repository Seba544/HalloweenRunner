using System;

namespace Component_Models.Contracts
{
    public interface IObstacleComponentModel : IDisposable
    {
        string GetObstacleId();
        event Action<float,float,float> RelocateToSpawnPoint;
        void CollidesWithPlayer(bool isASolidObstacle);
    }
}