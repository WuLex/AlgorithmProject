using AlgorithmSpace.Models.ELOAlg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmSpace.Logic
{

    /// <summary>
    /// 这只是一个简单的示例，实际的匹配算法可能包含更多的逻辑，比如排队系统、匹配时间的考虑、以及对战结果的更复杂处理等。
    ///ELO算法的具体参数可以根据游戏的需求进行调整。例如，K因子控制了每场比赛ELO变动的幅度，可以根据游戏的节奏和竞争水平来调整。
    /// </summary>
    public class Matchmaking
    {
        private const double InitialElo = 1000; // 初始ELO等级
        private const double KFactor = 32; // K因子，控制ELO变动的幅度

        private List<Player> players = new List<Player>();

        public void AddPlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            player.Elo = InitialElo; // 新玩家的初始ELO等级
            players.Add(player);
        }

        public void MatchPlayers(Player player1, Player player2, bool player1Wins)
        {
            double expectedScore1 = 1 / (1 + Math.Pow(10, (player2.Elo - player1.Elo) / 400));
            double expectedScore2 = 1 / (1 + Math.Pow(10, (player1.Elo - player2.Elo) / 400));

            double actualScore1 = player1Wins ? 1 : 0;
            double actualScore2 = player1Wins ? 0 : 1;

            player1.Elo = player1.Elo + KFactor * (actualScore1 - expectedScore1);
            player2.Elo = player2.Elo + KFactor * (actualScore2 - expectedScore2);
        }
    }
}
