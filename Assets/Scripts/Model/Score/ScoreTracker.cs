namespace Model.Score
{
    public class ScoreTracker : IScoreTracker
    {
        public int Score { get; private set; }

        public void RegisterHazard(IDestroyable hazard)
        {
            void OnHazardDestroyed()
            {
                Score++;
                hazard.Destroyed -= OnHazardDestroyed;
            }
            hazard.Destroyed += OnHazardDestroyed;
        }
    }
}