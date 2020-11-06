using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sakharchuk.Oleh.RobotChallange;
using Robot.Common;
using System.Collections.Generic;

namespace DistanceHelperTests
{
    [TestClass]
    public class MovementHelperTests
    {
        [TestMethod]
        public void getDistanceTest()
        {
               
           int x1 = 0, y1 = 0, x2 = 10, y2 = 10; 
           Position pos1 = new Position(x1, y1);
           Position pos2 = new Position(x2, y2);
           int distance = ((x1-x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
           Assert.AreEqual(MovementHelper.getDistance(pos1, pos2), distance);
        }
        [TestMethod]
        public void getPositionsNearStationTest()
        {
            int dist = 2;
            int x = 5, y = 5;
            Position pos = new Position(x, y);
            HashSet<Position> positionsAround = new HashSet<Position>();
            for (int i = x-dist; i < x+dist; i++)
            {
                for(int j = y - dist; j < y + dist; j++)
                {
                    positionsAround.Add(new Position(i, j));
                }
            }
            HashSet<Position> positionsAround2 = MovementHelper.getPositionsNearStation(pos);
            var  iterator = positionsAround.GetEnumerator();
            var iterator2 = positionsAround2.GetEnumerator();
            for (int i = 0;  i < positionsAround.Count; i++)
            {
                iterator.MoveNext();
                iterator2.MoveNext();
                Assert.AreEqual(iterator.Current.X, iterator2.Current.X);
                Assert.AreEqual(iterator.Current.Y, iterator2.Current.Y); 
            }
        }
        [TestMethod]
        public void getEnergyToMoveTest()
        {

            int x1 = 0, y1 = 0, x2 = 10, y2 = 10;
            Position pos1 = new Position(x1, y1);
            Position pos2 = new Position(x2, y2);
            int cost = 0;
            int distance = MovementHelper.getDistance(pos1, pos2);
            for (int i =0; i < distance; i++)
            {
                cost += distance*distance;
            }
            
            Assert.AreEqual(MovementHelper.getEnergyCostToMove(pos1, pos2), cost);
        }
    }
}
