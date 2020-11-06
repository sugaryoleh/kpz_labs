using Robot.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sakharchuk.Oleh.RobotChallange
{
    public class PositionChecker
    {
        public static bool isAtStation(Map map, IList<Robot.Common.Robot> robots, int robotToMoveIndex)
        {

            foreach (EnergyStation st in map.Stations)
            {
                if (MovementHelper.getDistance(robots[robotToMoveIndex].Position, st.Position) < 4)
                    return true;
            }
            return false;
        }
        public static bool isClosestStationPositionEnergyCollectable(Position my, Map map, int radius)
        {
            Position station = MovementHelper.getPositionOfClosestStation(map, my);
            return isPositionEnergyCollectable(my, station, radius);
        }
        public static bool isPositionEnergyCollectable(Position my, Position stationPos, int radius)
        {
            if (Math.Abs(my.X - stationPos.X) <= radius && Math.Abs(my.Y - stationPos.Y) <= radius)
                return true;
            return false;
        }
        
        public static bool isCellFreeFromMate(Position pos, IList<Robot.Common.Robot> mates)
        {
            foreach (Robot.Common.Robot r in mates)
            {
                if (r.Position == pos)
                    return false;
            }
            return true;
        }
        public static int getEnemyAtCell(Position pos, IList<Robot.Common.Robot> allRobots, IList<Robot.Common.Robot> mates)
        {
            int cnt = 0;
            foreach (Robot.Common.Robot r in allRobots)
            {

                if (r.Position == pos && isCellFreeFromMate(pos, mates))
                    return cnt;
                cnt++;   
            }
            return -1;
        }
    }
}
