using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    public class AcceptanceTests
    {
        [TestCase("1,1", "2")]
        [TestCase("1", "-1")]

        [TestCase("5,5,1,2", "14")]
        [TestCase("5,5,1", "-1")]
        [TestCase("5,5", "-1")]

        [TestCase("10,1,2", "16")]
        [TestCase("10,1", "-1")]
        [TestCase("10", "-1")]

        [TestCase("1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1", "20")]
        [TestCase("1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,1", "29")]
        [TestCase("10,10,10,10,10,10,10,10,10,10,10,10", "300")]
        public void AsAPlayer_IWantToKnow_MyScore(string inputStr, string expectedTotalScore)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.Main(new[] {inputStr});

                string consoleOut = sw.ToString();
                string[] lines = consoleOut.Split(new []{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(2, lines.Length);
                Assert.AreEqual(inputStr, lines[0]);
                Assert.AreEqual(expectedTotalScore, lines[1]);
            }
        }
    }
}
