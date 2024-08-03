namespace Modules.Player.Scripts
{
    public class InMemoryPlayerRepository : IPlayerRepository
    {
        private IPlayer _player;
        public IPlayer GetPlayer()
        {
            return _player;
        }

        public void Create(float playerRunSpeed, float playerWalkSpeed)
        {
            _player = new Player(playerRunSpeed,playerWalkSpeed);
        }
    }
}
