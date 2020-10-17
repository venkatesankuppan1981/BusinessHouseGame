using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessHomeGame;
using BusinessHomeGame.Service;

namespace BusinessHomeGameTest
{
    [TestClass]
    public class BusinessHouseGameTest
    {
        [TestMethod]
        public void TestPlayGame_Case1()
        {
            var cellInput = "J,H,L,H,E,L,H,L,H,J";
            var cells = cellInput.Trim().Split(',');
            var diceOutputsInput = "2,2,1, 4,4,2, 4,4,2, 2,2,1, 4,4,2, 4,4,2, 2,2,1";
            string[] diceOutputs = diceOutputsInput.Split(new string[] { ", " }, StringSplitOptions.None);
            int players = 3;

            PlayGame playGame = new PlayGame(cells, diceOutputs, players);
            playGame.Play();

            int expectedBankAmount = 5150;

            Assert.AreEqual(expectedBankAmount, playGame.BankAmount, "Expected Bank amount is not matching with Actual Bank amount");





        }
        [TestMethod]
        public void TestPlayGame_Case2()
        {
            var cellInput = "J,H,L,H,E,L,H,L,H,J";
            var cells = cellInput.Trim().Split(',');

            var diceOutputsInput = "2,2,1, 4,2,3, 4,1,3, 2,2,7, 4,7,2, 4,4,2, 2,2,2";
            string[] diceOutputs = diceOutputsInput.Split(new string[] { ", " }, StringSplitOptions.None);

            int players = 3;

            PlayGame playGame = new PlayGame(cells, diceOutputs, players);
            playGame.Play();

            int expectedBankAmount = 5750;

            Assert.AreEqual(expectedBankAmount, playGame.BankAmount, "Expected Bank amount is not matching with Actual Bank amount");
        }
    }
}
