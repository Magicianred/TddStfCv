using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class BowlingRolls
    {
        private readonly Queue<Roll> _rollsQueue;

        public BowlingRolls(Roll[] inputRolls)
        {
            _rollsQueue = new Queue<Roll>(inputRolls);
        }

        public int Count => _rollsQueue.Count;

        public Roll Dequeue() => _rollsQueue.Dequeue();

        public IBowlingScore TakeRolls(int howMany) => new BowlingScore(_rollsQueue
            .Take(howMany)
            .Sum(roll => roll.Value));
    }
}