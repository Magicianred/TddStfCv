using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    class BowlingRollsTests
    {
        [Test]
        public void GivenAnArrayOfRolls_TheLenght_IsAsExpected()
        {
            var inputRolls = new[] {new Roll(0)};
            var rolls = new BowlingRolls(inputRolls);

            Assert.AreEqual(1, rolls.Count);
        }

        [Test]
        public void IfITake_ARoll_IHave_OneRollLess()
        {
            var inputRolls = new[] {new Roll(0)};
            var rolls = new BowlingRolls(inputRolls);

            int count = rolls.Count;
            rolls.Dequeue();
            Assert.AreEqual(count - 1, rolls.Count);
        }

        [TestCase(1, 1)]
        [TestCase(2, 3)]
        public void ItReturns_TheSumOfRequestedRolls(int howMany, int expectedTotal)
        {
            var inputRolls = Enumerable.Range(1, howMany)
                .Select(value => new Roll(value))
                .ToArray();

            var rolls = new BowlingRolls(inputRolls);
            
            Assert.AreEqual(expectedTotal, rolls.TakeRolls(howMany).Value);
        }
    }
}
