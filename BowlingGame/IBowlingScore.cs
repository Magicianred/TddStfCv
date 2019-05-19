namespace BowlingGame
{
    public interface IBowlingScore 
    {
        bool IsValid { get; }
        string StringValue { get; }
        int Value { get; }
        IBowlingScore Add(IBowlingScore currentScore);
        IBowlingScore Add(int value);
        void Add(Roll roll);
    }
}