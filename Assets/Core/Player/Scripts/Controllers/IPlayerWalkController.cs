using System;

namespace Core.Player.Scripts.Controllers
{
    public interface IPlayerWalkController : IDisposable
    {
        void Walk();
        void Run();
    }
}