using System;
using System.Collections.Generic;
using Robot.Common;


namespace Sakharchuk.Oleh.RobotChallange
{
    public class SakharchukAlgorithm : IRobotAlgorithm
    {
        protected static int robotCnt = 10;
        protected static int round = 0;
        protected static int collectableRadius = 2;
        public static List<Robot.Common.Robot> myRobots = null;
        public string Author
        {
            get { return "Sakharchuk Oleh"; }
        }
        public string Description
        {
            get { return "bla bla"; }
        }
        
        static void incRound(IList<Robot.Common.Robot> robots, int index)
        {
            if (index == 0)
            {
                round++;
            }
        }
        static void init(IList<Robot.Common.Robot> robots)
        {
            if (myRobots == null)
            {
                myRobots = new List<Robot.Common.Robot>();
                foreach (Robot.Common.Robot robot in robots)
                {
                    if (robot.OwnerName == "Sakharchuk Oleh")
                    {
                        myRobots.Add(robot);
                    }
                }
            }
        }
        
        void addMyRobot(IList<Robot.Common.Robot> robots, int index)
        {
            bool b = true;
            Robot.Common.Robot rb = null;
            foreach (Robot.Common.Robot robot in robots){
                if(robot == robots[index]) {
                    b = false;
                    rb = robot; 
                }
            }
            if (!b)
                myRobots.Add(rb);
        }

        public static RobotCommand MyCreateNewRobotCommand()
        {
            robotCnt += 1;
            return new CreateNewRobotCommand();
        }

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            init(robots);
            addMyRobot(robots, robotToMoveIndex);
            Position myPos = robots[robotToMoveIndex].Position;
            if (robots[robotToMoveIndex].Energy > 1200 && robotCnt < 100)
                return MyCreateNewRobotCommand();
            if(AtackStrateger.getRobotIndexToAtack(robots, robotToMoveIndex) != -1)
            {
                return new MoveCommand() { NewPosition = new Position(robots[robotToMoveIndex].Position.X, robots[robotToMoveIndex].Position.Y) };
            }
            if (PositionChecker.isClosestStationPositionEnergyCollectable(robots[robotToMoveIndex].Position, map, collectableRadius))
                return new CollectEnergyCommand();
            else
            {
                Position toMove = MovementHelper.getPositionForStep(map, robots, robotToMoveIndex);
                if (toMove != null)
                    return new MoveCommand() { NewPosition = toMove };
                return null;
            }
        }
    }
}