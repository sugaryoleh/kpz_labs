using Robot.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sakharchuk.Oleh.RobotChallange
{
    public class AtackStrateger
    {
        public static LinkedList<int> getEnemyRobotsAround(IList<Robot.Common.Robot> robots, int index, int radius)
        {
            LinkedList<int> enemiesAroundIndexes = new LinkedList<int>();
            for(int i = robots[index].Position.X - radius; i < robots[index].Position.X + radius; i++)
            {
                for (int j = robots[index].Position.Y - radius; j < robots[index].Position.Y + radius; j++)
                {
                    int pos = PositionChecker.getEnemyAtCell(new Position(i, j), robots, SakharchukAlgorithm.myRobots);
                    if (pos != -1)
                        enemiesAroundIndexes.AddLast(pos);
                }
            }
            return enemiesAroundIndexes;
        }
        public static int getEnergyWinOfAtack(Robot.Common.Robot myRobot, Robot.Common.Robot enemy)
        {
            int enemyEnergeToGet = (int)(enemy.Energy * 0.3);
            int energyToLose = MovementHelper.getEnergyCostToMove(myRobot.Position, enemy.Position)-30;
            return enemyEnergeToGet - energyToLose;
        }
        public static int getRobotIndexToAtack(IList<Robot.Common.Robot> robots, int index)
        {
            LinkedList<int> enemiesToAtack = getEnemyRobotsAround(robots, index, 10);
            int maxWin = -1;
            int enemyToAtackIndex = -1;
            foreach (int enIndex in enemiesToAtack)
            {
                int tempWin = getEnergyWinOfAtack(robots[index], robots[enIndex]);
                if (tempWin > maxWin && tempWin > 150)
                {
                    maxWin = tempWin;
                    enemyToAtackIndex = enIndex;
                }
            }
            return enemyToAtackIndex;
        }
        
    }
}
