using AlgorithmSpace.Models.ELOAlg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Logic
{
    public class EloCalculator
    {
        private const double KFactor = 32; // 调整系数

        // 计算预期胜率
        private static double GetExpectedScore(double playerAElo, double playerBElo)
        {
            return 1.0 / (1.0 + Math.Pow(10, (playerBElo - playerAElo) / 400.0));
        }

        // 计算新的ELO分数
        public static void UpdateRatings(Player playerA, Player playerB, bool playerAWon)
        {
            double expectedScoreA = GetExpectedScore(playerA.Elo, playerB.Elo);
            double expectedScoreB = GetExpectedScore(playerB.Elo, playerA.Elo);

            double actualScoreA = playerAWon ? 1.0 : 0.0;
            double actualScoreB = playerAWon ? 0.0 : 1.0;

            double newEloA = playerA.Elo + KFactor * (actualScoreA - expectedScoreA);
            double newEloB = playerB.Elo + KFactor * (actualScoreB - expectedScoreB);

            playerA.Elo = newEloA;
            playerB.Elo = newEloB;
        }
    }

}
