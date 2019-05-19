using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class Program
    {
        public static void Main(string[] strings)
        {
            string inputStr = strings[0];
            Roll[] input = ReadInput(inputStr);
            IBowlingScore totalScore = ComputeScore(input);
            WriteOutput(inputStr, totalScore);
        }

        private static IBowlingScore ComputeScore(Roll[] inputRolls)
        {
            var rollsQueue = new BowlingRolls(inputRolls);
            IBowlingScore totalScore = new BowlingScore();
            int frameNumber = 0;

            while (rollsQueue.Count > 0 && frameNumber < 10 && totalScore.IsValid)
            {
                IBowlingScore currentScore = new BowlingScore(rollsQueue.Dequeue());

                if (currentScore.Value == 10)
                {
                    IBowlingScore bonusValue = GetBonusValue(rollsQueue, 2);
                    currentScore = currentScore.Add(bonusValue);
                }
                else
                {
                    if (rollsQueue.Count > 0)
                    {
                        currentScore.Add(rollsQueue.Dequeue());

                        if (currentScore.Value == 10)
                        {
                            IBowlingScore bonusValue = GetBonusValue(rollsQueue, 1);
                            currentScore = currentScore.Add(bonusValue);
                        }
                    }
                }

                frameNumber++;
                totalScore = totalScore.Add(currentScore);
            }

            return totalScore;
        }

        private static IBowlingScore GetBonusValue(BowlingRolls rolls, int howMany)
        {
            if (rolls.Count >= howMany)
            {
                return rolls.TakeRolls(howMany);
            }

            return new InvalidScore();
        }

        private static void WriteOutput(string inputStr, IBowlingScore totalScore)
        {
            Console.WriteLine(inputStr);
            Console.Write(totalScore.StringValue);
        }

        private static Roll[] ReadInput(string inputStr)
        {
            return inputStr.Split(',')
                .Select(Int32.Parse)
                .Select(rollValue => new Roll(rollValue))
                .ToArray();
        }
    }
}