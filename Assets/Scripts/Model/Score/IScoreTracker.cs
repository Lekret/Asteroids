namespace Model.Score
{
    public interface IScoreTracker
    {
        int Score { get; }
        void RegisterHazard(IDestroyable hazard);
    }
}