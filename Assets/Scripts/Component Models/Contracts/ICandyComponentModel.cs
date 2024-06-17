using System;

namespace Component_Models.Contracts
{
    public interface ICandyComponentModel : IDisposable
    {
        void CollectCandy();
        string GetCandyId();
        event Action<float,float,float> RelocateToSpawnPoint;
    }
}
