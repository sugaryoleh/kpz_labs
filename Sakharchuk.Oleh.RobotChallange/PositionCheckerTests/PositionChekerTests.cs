using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sakharchuk.Oleh.RobotChallange;
using Robot.Common;
using System.Collections.Generic;

namespace PositionCheckerTests
{
    [TestClass]
    public class PositionCheckerTests
    {
        [TestMethod]
        public void isPositionEnergyCollectableWhenRobotAtStationTest()
        {
            int r = 2;
            int x = 10, y = 10;
            Position myPos = new Position(x, y);
            Position stationPos = new Position(x, y);
            Assert.IsTrue(PositionChecker.isPositionEnergyCollectable(myPos, stationPos, r));
        }
        [TestMethod]
        public void isPositionEnergyCollectableWhenRobotInRadiusTest()
        {
            int r = 2;
            int x = 10, y = 10;
            Position myPos = new Position(x, y);
            Position stationPos = new Position(x-1, y-1);
            Assert.IsTrue(PositionChecker.isPositionEnergyCollectable(myPos, stationPos, r));
        }
        [TestMethod]
        public void isPositionEnergyCollectableWhenRobotOutOfRadiusTest()
        {
            int r = 2;
            int x = 10, y = 10;
            int x1 = 15, y1 = 15;
            Position myPos = new Position(x, y);
            Position stationPos = new Position(x1, y1);
            Assert.IsFalse(PositionChecker.isPositionEnergyCollectable(myPos, stationPos, r));
        }
    }
}
