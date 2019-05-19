namespace BowlingGame
{
    class InvalidScore : IBowlingScore
    {
        public bool IsValid => false;
        public string StringValue => Value.ToString();
        public int Value => -1;
        public IBowlingScore Add(IBowlingScore currentScore) => new InvalidScore();
        public IBowlingScore Add(int value) => new InvalidScore();
        public void Add(Roll roll) { }
    }
}