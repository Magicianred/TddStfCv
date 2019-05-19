using System.CodeDom;

namespace BowlingGame
{
    public class BowlingScore : IBowlingScore
    {
        public BowlingScore()
        {
            Value = 0;
        }

        public BowlingScore(Roll roll)
        {
            Value = roll.Value;
        }

        public BowlingScore(int rollValue)
        {
            Value = rollValue;
        }

        public int Value { get; private set; }

        public IBowlingScore Add(int bonusValue)
        {
            Value += bonusValue;
            return new BowlingScore(Value);
        }

        public void Add(Roll bonusValue)
        {
            Add(bonusValue.Value);
        }

        public bool IsValid => true;
        public string StringValue => Value.ToString();

        public IBowlingScore Add(IBowlingScore bonusValue)
        {
            return bonusValue.Add(Value);
        }
    }
}