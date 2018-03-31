using RocketLeagueReplaysToDataSet.Data;
using RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RocketLeagueReplaysToDataSet.Utils
{
    public static class ReplayJsonToDataRowConverter
    {
        //at 30fps, 210 frame before goal means the last 7 seconds
        //it determines what will be kept as a good play vs a bad play
        public const int _nbFrameBeforeGoal = 210;

        public static List<MLDataRow> ConvertReplayJsonToDataRow(ReplayJson json)
        {
            List<MLDataRow> dataRows = new List<MLDataRow>();
            MLDataRow referenceRow = new MLDataRow();

            for (int frameNo = 0; frameNo < json.Content.Body.Frames.Length; frameNo++)
            {
                MLDataRow currentFrameRow = new MLDataRow()
                {
                    Number = frameNo,
                    Ball = new Ball() { ActorID = referenceRow.Ball.ActorID },
                    Player = new Player() { ActorID = referenceRow.Player.ActorID },
                    EnemyPlayer = new Player() { ActorID = referenceRow.EnemyPlayer.ActorID }
                };
                foreach (Replication replication in json.Content.Body.Frames[frameNo].Replications)
                {
                    if (replication.Value != null)
                    {
                        if (replication.Value.Spawned != null)
                        {
                            //something spawned! we may need to refresh actor IDs
                            Console.WriteLine(frameNo);
                            SetNewSpawnActorID(referenceRow, replication);
                            //set the actor IDs for every actor
                            currentFrameRow.Ball.ActorID = referenceRow.Ball.ActorID;
                            currentFrameRow.Player.ActorID = referenceRow.Player.ActorID;
                            currentFrameRow.EnemyPlayer.ActorID = referenceRow.EnemyPlayer.ActorID;
                        }

                        if (replication.Value.Updated != null)
                        {
                            foreach (Updated updated in replication.Value.Updated)
                            {
                                //a rigidbody was updated! something moved
                                if (updated?.Value?.RigidBodyState?.Location != null)
                                {
                                    //get the ID of the actor who is being updated
                                    int actorID = int.Parse(replication.ActorId.Value.ToString());

                                    int x = int.Parse(updated.Value.RigidBodyState.Location.X.ToString());
                                    int y = int.Parse(updated.Value.RigidBodyState.Location.Y.ToString());

                                    if (currentFrameRow.Ball.ActorID == actorID)
                                    {
                                        currentFrameRow.Ball.Location2D = new Point(x, y);
                                    }
                                    else if (currentFrameRow.Player.ActorID == actorID)
                                    {
                                        currentFrameRow.Player.Location2D = new Point(x, y);
                                    }
                                    else if (currentFrameRow.EnemyPlayer.ActorID == actorID)
                                    {
                                        currentFrameRow.EnemyPlayer.Location2D = new Point(x, y);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //I have a replication with no value??
                        throw new Exception("replication without value");
                    }
                }

                //if we have no position for an element on this frame, we'll assume he has the same position he had last frame
                if (currentFrameRow.Player.Location2D == Point.Empty)
                {
                    if (frameNo > 0)
                    {
                        currentFrameRow.Player.Location2D = dataRows[frameNo - 1].Player.Location2D;
                    }
                }
                if (currentFrameRow.EnemyPlayer.Location2D == Point.Empty)
                {
                    if (frameNo > 0)
                    {
                        currentFrameRow.EnemyPlayer.Location2D = dataRows[frameNo - 1].EnemyPlayer.Location2D;
                    }
                }
                if (currentFrameRow.Ball.Location2D == Point.Empty)
                {
                    if (frameNo > 0)
                    {
                        currentFrameRow.Ball.Location2D = dataRows[frameNo - 1].Ball.Location2D;
                    }
                }


                //we finish looking for replications in a frame, let's add the frame to our list of row
                dataRows.Add(currentFrameRow);
            }

            //This is what we do it all for!find which frames gave a goal!
            foreach (PurpleArray goal in json.Header.Body.Properties.Value.Goals.Value.Array)
            {
                //we will take every frame before a goal until the goal happens for a set number a frame. these are the frames that we consider good
                int minFrameForGoal = int.Parse(goal.Value.Frame.Value.Int.ToString()) -_nbFrameBeforeGoal;
                if (minFrameForGoal < 1)
                {
                    //this will make sure a goal scored in under the _nbFrameBeforeGoal doesn't crash
                    minFrameForGoal = 1;
                }

                if (goal.Value.PlayerTeam.Value.Int == 0)
                {
                    //these are the frames that scored a goal for the player's team! :D
                    //these are good patterns that lead to a goal! so we give it the highest possible score : 100
                    for (int frameNo = minFrameForGoal; frameNo < goal.Value.Frame.Value.Int; frameNo++)
                    {
                        foreach (MLDataRow row in dataRows)
                        {
                            if (row.Label == 50)
                            {
                                //I have to make sure it was an unchanged label! if the _nbFrameBeforeGoal goes to the previous play, I don' want to override that play's score
                                //so the score if 50 makes sure that the label hasn't been changed yet
                                row.Label = 100;
                            }
                        }
                    }
                }
                else if (goal.Value.PlayerTeam.Value.Int == 1)
                {
                    //these are the frames that scored a goal for the enemy team! :'(
                    //these are bad patterns that lead to a goal in the wrong net! so we give it the lowest possible score : 0
                    for (int frameNo = minFrameForGoal; frameNo < goal.Value.Frame.Value.Int; frameNo++)
                    {
                        foreach (MLDataRow row in dataRows)
                        {
                            if (row.Label == 50)
                            {
                                //Same thing as the positive outcome, I have the make sure I only label previously unlabeled rows
                                row.Label = 0;
                            }
                        }
                    }
                }
            }

            return dataRows;
        }

        /// <summary>
        /// makes sure I keep track of spawnable actors after goals, explosions or anything that causes a re-spawn
        /// </summary>
        /// <param name="row">the row will have the updated Actor ID in the appropriate field</param>
        /// <param name="replication">the replication of the spawn</param>
        private static void SetNewSpawnActorID(MLDataRow row, Replication replication)
        {
            if (replication.Value.Spawned.ClassName == ClassName.TaGameCarTa)
            {
                //Actually, I have to check for car boost spawning.... the actual player of the replay never spawns...
                //a car has spawned
                if (replication.Value.Spawned.Name.EndsWith("TA_0"))
                {
                    //it is the player's car
                    row.Player.ActorID = int.Parse(replication.ActorId.Value.ToString());
                }
                else if (replication.Value.Spawned.Name.EndsWith("TA_1"))
                {
                    //it is the opponent's car
                    row.EnemyPlayer.ActorID = int.Parse(replication.ActorId.Value.ToString());
                }
            }
            else if (replication.Value.Spawned.ClassName == ClassName.TaGameBallTa && replication.Value.Spawned.ObjectName == "Archetypes.Ball.Ball_Default")
            {
                //a ball has spawned
                row.Ball.ActorID = int.Parse(replication.ActorId.Value.ToString());
            }

            //there are a lot of spawnables that I don't care of, most spawnables won't do anything
        }
    }
}
