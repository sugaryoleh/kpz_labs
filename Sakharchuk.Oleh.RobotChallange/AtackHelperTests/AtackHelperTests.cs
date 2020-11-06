using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sakharchuk.Oleh.RobotChallange;
using Robot.Common;
using System.Collections.Generic;

namespace AtackHelperTests
{
    [TestClass]
    public class AtackHelperTests
    {
        [TestMethod]
        public void getWinOfAttackTest()
        {
            Robot.Common.Robot myRobot = new Robot.Common.Robot();
            Robot.Common.Robot enemyRobot = new Robot.Common.Robot();
            int atackCost = 30;
            myRobot.Energy = 100;
            myRobot.Position = new Position(1, 1);
            enemyRobot.Energy = 100;
            enemyRobot.Position = new Position(5, 5);
            int enemyEnergeToGet = (int)(enemyRobot.Energy * 0.3);
            int energyToLose = MovementHelper.getEnergyCostToMove(myRobot.Position, enemyRobot.Position) - atackCost;
            int energyWin = enemyEnergeToGet - energyToLose;
            Assert.AreEqual(AtackStrateger.getEnergyWinOfAtack(myRobot, enemyRobot), energyWin);
        }
    }
}
