using System;

namespace Component_Models.Contracts
{
    public interface ICandyController : IDisposable
    {
        void CollectCandy();
        string GetCandyId();
        event Action<float,float,float> RelocateToSpawnPoint;
    }
}
