using System.Collections.Generic;
using Robot.Common;


namespace Sakharchuk.Oleh.RobotChallange
{
    public class MovementHelper
    {
        public static int getDistance(Position a, Position b)
        {
            return (int)((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        public static List<KeyValuePair<EnergyStation, int>> getDistancesToAllStations(Map map, Position my)
        { 
            
            List<KeyValuePair<EnergyStation, int>> list = new List<KeyValuePair<EnergyStation, int>>();
            foreach (Robot.Common.EnergyStation st in map.Stations)
            {
                list.Add(new KeyValuePair<EnergyStation, int>(st, getDistance(my, st.Position)));
            }
            list.Sort(delegate (KeyValuePair<EnergyStation, int> l, KeyValuePair<EnergyStation, int> r)
            {
                return l.Value.CompareTo(r.Value);
            });
            return list;
        }

        public static Position getPositionOfClosestStation(Map map, Position my)
        {
            int minDistance = map.MaxPozition.X * map.MaxPozition.Y;
            int temp;
            EnergyStation stat = null;
            foreach (EnergyStation station in map.Stations)
            {
                temp = getDistance(my, station.Position);
                if (temp < minDistance && station.Energy > 0)
                {
                    minDistance = temp;
                    stat = station;
                }
            }
            return stat.Position;
        }
       
        public static HashSet<Position> getPositionsNearStation(Position stationPos)
        {
            HashSet<Position> positions = new HashSet<Position>();
            
            for (int x = stationPos.X - 2; x < stationPos.X + 2 ; x++)
            {
                for (int y = stationPos.Y - 2; y < stationPos.Y + 2; y++)
                {
                    positions.Add(new Position(x, y));
                }
            }
            return positions;
        }
        public static HashSet<Position> getRealPositionsNearStation(Map map, Position myPos)
        {

            HashSet<Position> realPositions = new HashSet<Position>();
            HashSet<Position> positions = getPositionsNearStation(myPos);
            foreach (Position pos in positions)
            {
                if (pos.X < 0 || pos.X > map.MaxPozition.X || pos.Y < 0 || pos.Y > map.MaxPozition.Y)
                {
                    continue;
                }
                else
                {
                    realPositions.Add(pos);
                }
            }
            return realPositions;
        }
        public static HashSet<Position> getAvailablePositionsNearStation(HashSet<Position> positions, IList<Robot.Common.Robot> robots)
        {
            HashSet<Position> availablePositions = new HashSet<Position>();
            foreach (Position pos in positions)
            {
                if (PositionChecker.isCellFreeFromMate(pos, robots))
                    availablePositions.Add(pos);
            }
            return availablePositions;
        }
        public static Position getPositionForStep(Map map, IList<Robot.Common.Robot> robots, int robotToMoveIndex)
        {
            Position my = robots[robotToMoveIndex].Position;
            Position stationPos = getPositionOfClosestStation(map, my);
            HashSet<Position> positions = getRealPositionsNearStation(map, stationPos);
            HashSet<Position> avPositions = getAvailablePositionsNearStation(positions, robots);
            if (avPositions.Count == 0)
            { 
                return null; 
            }
            int min = getDistance(map.MinPozition, map.MaxPozition);
            int temp;
            Position tempPos = null;
            foreach(Position pos in positions)
            {
                temp = getDistance(my, pos);
                if (temp < min)
                {
                    min = temp;
                    tempPos = pos;
                }
            }
            return tempPos;
        }
        public static int getEnergyCostToMove(Position my, Position dest)
        {
            int dist = getDistance(my, dest);
            int energyToMove = 0;
            for(int i =0; i < dist; i++)
            {
                energyToMove += dist * dist;
            }
            return energyToMove;
        } 
    }
}

