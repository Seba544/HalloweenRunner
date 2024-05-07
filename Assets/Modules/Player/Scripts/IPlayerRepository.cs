namespace Modules.Player.Scripts
{
    public interface IPlayerRepository
    {
        public IPlayer GetPlayer();
        public void SetPlayer(IPlayer player);
    }
}
