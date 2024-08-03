namespace Core.Levels.Scripts
{
    public interface IRaceController
    {
        void SetRaceDifficultyToMedium();
        void SetRaceDifficultyToHard();
        void EndRace();
        void StartRace();
    }
}