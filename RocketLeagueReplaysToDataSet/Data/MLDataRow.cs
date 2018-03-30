using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplaysToDataSet.Data
{
    public class MLDataRow
    {
        public int Number;
        public Player Player = new Player();
        public Player EnemyPlayer = new Player();
        public Ball Ball = new Ball();
        /// <summary>
        /// 50 means that the play leads to nothing
        /// 0 is a frame that lead to a goal on your goal
        /// 100 is a frame that lead to a goal on the enemy goal
        /// </summary>
        public int Label = 50;
    }
}
