using System;

namespace Core.Player.Scripts.Controllers
{
    public interface IPlayerWalkController : IDisposable
    {
        void ReduceSpeed();
        void ResumeSpeed();
    }
}