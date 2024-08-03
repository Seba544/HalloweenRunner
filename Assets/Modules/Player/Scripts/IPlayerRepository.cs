namespace Modules.Player.Scripts
{
    public interface IPlayerRepository
    {
        public IPlayer GetPlayer();
        void Create(float playerRunSpeed, float playerWalkSpeed);
    }
}
