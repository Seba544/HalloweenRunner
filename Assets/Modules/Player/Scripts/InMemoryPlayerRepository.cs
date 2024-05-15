namespace Modules.Player.Scripts
{
    public class InMemoryPlayerRepository : IPlayerRepository
    {
        private IPlayer _player;

        public InMemoryPlayerRepository()
        {
            _player = new Player();
        }
        public IPlayer GetPlayer()
        {
            return _player;
        }

        public void SetPlayer(IPlayer player)
        {
            _player = player;
        }
    }
}
