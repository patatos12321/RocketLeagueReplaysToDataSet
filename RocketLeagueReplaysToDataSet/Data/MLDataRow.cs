using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplaysToDataSet.Data
{
    public class MLDataRow
    {
        public const string DataRowFormat = "BallX,BallY,BallVelocityX,BallVelocityY,PlayerX,PlayerY,EnemyPlayerX,EnemyPlayerY,Label";
        public const string DataRowFormatForReplay = "BallX,BallY,BallVelocityX,BallVelocityY,PlayerX,PlayerY,PlayerRotationX,PlayerRotationY,EnemyPlayerX,EnemyPlayerY,EnemyPlayerRotationX,EnemyPlayerRotationY,Label";

        public int Number;
        public double Time;
        public Player Player = new Player();
        public Player EnemyPlayer = new Player();
        public Ball Ball = new Ball();
        /// <summary>
        /// 50 means that the play leads to nothing
        /// 0 is a frame that lead to a goal on your goal
        /// 100 is a frame that lead to a goal on the enemy goal
        /// </summary>
        public int Label = 50;
        public bool Useful = true;

        /// <summary>
        /// This gets the datarow visual representation as a row of the dataset
        /// </summary>
        /// <returns>The row displayed in this format
        /// [BallX],[BallY],[BallVelocityX],[BallVelocityY],[PlayerX],[PlayerY],[EnemyPlayerX],[EnemyPlayerY],[Label]</returns>
        public string DisplayDataRow()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Ball.Location2D.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Location2D.Y.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity2D.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity2D.Y.ToString());
            sb.Append(",");
            sb.Append(Player.Location2D.X.ToString());
            sb.Append(",");
            sb.Append(Player.Location2D.Y.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location2D.X.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location2D.Y.ToString());
            sb.Append(",");
            sb.Append(Label);

            return sb.ToString();
        }
        /// <summary>
        /// This gets the datarow visual representation as a row of the dataset for a replay
        /// </summary>
        /// <returns>The row displayed in this format
        /// [BallX],[BallY],[BallVelocityX],[BallVelocityY],[PlayerX],[PlayerY],[PlayerRotationX],[PlayerRotationY],[EnemyPlayerX],[EnemyPlayerY],[EnemyPlayerRotationX],[EnemyPlayerRotationY],[Label]</returns>
        public string DisplayDataRowForReplay()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Ball.Location2D.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Location2D.Y.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity2D.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity2D.Y.ToString());
            sb.Append(",");
            sb.Append(Player.Location2D.X.ToString());
            sb.Append(",");
            sb.Append(Player.Location2D.Y.ToString());
            sb.Append(",");
            sb.Append(Player.Rotation2DX);
            sb.Append(",");
            sb.Append(Player.Rotation2DY);
            sb.Append(",");
            sb.Append(EnemyPlayer.Location2D.X.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location2D.Y.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Rotation2DX);
            sb.Append(",");
            sb.Append(EnemyPlayer.Rotation2DY);
            sb.Append(",");
            sb.Append(Label);

            return sb.ToString();
        }
    }
}