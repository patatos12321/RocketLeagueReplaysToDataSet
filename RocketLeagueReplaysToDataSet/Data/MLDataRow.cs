using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplaysToDataSet.Data
{
    public class MLDataRow
    {
        public const string DataRowFormat = "BallX,BallY,BallZ,BallVelocityX,BallVelocityY,PlayerX,PlayerY,PlayerZ,EnemyPlayerX,EnemyPlayerY,EnemyPlayerZ,Label";
        public const string DataRowFormatForReplay = "BallX,BallY,BallZ,BallVelocityX,BallVelocityY,BallVelocityZ,PlayerX,PlayerY,PlayerZ,PlayerRotationX,PlayerRotationY,PlayerRotationZ,EnemyPlayerX,EnemyPlayerY,EnemyPlayerZ,EnemyPlayerRotationX,EnemyPlayerRotationY,EnemyPlayerRotatioZ,Label";

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
        /// BallX,BallY,BallZ,BallVelocityX,BallVelocityY,BallVelocityZ,PlayerX,PlayerY,PlayerZ,EnemyPlayerX,EnemyPlayerY,EnemyPlayerZ,Label</returns>
        public string DisplayDataRow()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Ball.Location.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Location.Y.ToString());
            sb.Append(",");
            sb.Append(Ball.Location.Z.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity.Y.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity.Z.ToString());
            sb.Append(",");
            sb.Append(Player.Location.X.ToString());
            sb.Append(",");
            sb.Append(Player.Location.Y.ToString());
            sb.Append(",");
            sb.Append(Player.Location.Z.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location.X.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location.Y.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location.Z.ToString());
            sb.Append(",");
            sb.Append(Label);

            return sb.ToString();
        }
        /// <summary>
        /// This gets the datarow visual representation as a row of the dataset for a replay
        /// </summary>
        /// <returns>The row displayed in this format
        /// BallX,BallY,BallZ,BallVelocityX,BallVelocityY,BallVelocityZ,PlayerX,PlayerY,PlayerZ,PlayerRotationX,PlayerRotationY,PlayerRotationZ,EnemyPlayerX,EnemyPlayerY,EnemyPlayerZ,EnemyPlayerRotationX,EnemyPlayerRotationY,EnemyPlayerRotatioZ,Label</returns>
        public string DisplayDataRowForReplay()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Ball.Location.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Location.Y.ToString());
            sb.Append(",");
            sb.Append(Ball.Location.Z.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity.X.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity.Y.ToString());
            sb.Append(",");
            sb.Append(Ball.Velocity.Z.ToString());
            sb.Append(",");
            sb.Append(Player.Location.X.ToString());
            sb.Append(",");
            sb.Append(Player.Location.Y.ToString());
            sb.Append(",");
            sb.Append(Player.Location.Z.ToString());
            sb.Append(",");
            sb.Append(Player.RotationX);
            sb.Append(",");
            sb.Append(Player.RotationY);
            sb.Append(",");
            sb.Append(Player.RotationZ);
            sb.Append(",");
            sb.Append(EnemyPlayer.Location.X.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location.Y.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.Location.Z.ToString());
            sb.Append(",");
            sb.Append(EnemyPlayer.RotationX);
            sb.Append(",");
            sb.Append(EnemyPlayer.RotationY);
            sb.Append(",");
            sb.Append(EnemyPlayer.RotationZ);
            sb.Append(",");
            sb.Append(Label);

            return sb.ToString();
        }
    }
}