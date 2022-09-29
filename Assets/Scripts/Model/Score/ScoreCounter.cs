namespace Model.Score
{
    public class ScoreCounter : IScoreCounter
    {
        public int Score { get; private set; }
        
        public void Add()
        {
            Score++;
        }
    }
}