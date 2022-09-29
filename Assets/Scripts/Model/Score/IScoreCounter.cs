namespace Model.Score
{
    public interface IScoreCounter
    {
        int Score { get; }
        void Add();
    }
}