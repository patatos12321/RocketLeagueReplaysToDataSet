using RocketLeagueReplaysToDataSet.Data;
using RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RocketLeagueReplaysToDataSet.Utils
{
    public static class ReplayJsonToDataRowConverter
    {
        //I just want to take the 7 seconds before a goal as "leading to a goal" 
        public const double _TimeBeforeGoal = 7;
        //I made a null actor id.... the ID 0 is used in the replay so I wanted to make sure I wasn't going to interfere with anything
        public const int nullActorID = 999999999;

        public static List<MLDataRow> ConvertReplayJsonToDataRow(ReplayJson json)
        {
            List<MLDataRow> dataRows = new List<MLDataRow>();
            MLDataRow referenceRow = new MLDataRow();

            referenceRow.Ball.ActorID = nullActorID;
            referenceRow.Player.ActorID = nullActorID;
            referenceRow.EnemyPlayer.ActorID = nullActorID;

            //I need to find in which team I was
            long playerTeamNumber = 0;
            foreach (PlayerStat player in json.Properties.PlayerStats)
            {
                if (player.Name == "patatos12321")
                {
                    //My name is hardcoded.... but I could find a more intelligent way to do it
                    //TODO: find a better way to find the player's team, I could probably find info on the person who saved the replay
                    //      and find his player
                    playerTeamNumber = player.Team;
                }
            }

            for (int frameNo = 0; frameNo < json.Frames.Length; frameNo++)
            {
                MLDataRow currentFrameRow = new MLDataRow()
                {
                    Number = frameNo,
                    Time = json.Frames[frameNo].Time,
                    Ball = new Ball() { ActorID = referenceRow.Ball.ActorID },
                    Player = new Player() { ActorID = referenceRow.Player.ActorID },
                    EnemyPlayer = new Player() { ActorID = referenceRow.EnemyPlayer.ActorID }
                };

                foreach (long deletedID in json.Frames[frameNo].DeletedActorIds)
                {
                    //These are the actors who get deleted, the ball and players during a goal, also players who get demo'd
                    //I blank their ID just to make sure I don't put false position for them... for now, I won't give them
                    //any "blank" position.... I think the best way is to just let them at the position they were when they disapeared
                    if (referenceRow.Ball.ActorID == int.Parse(deletedID.ToString()))
                    {
                        referenceRow.Ball.ActorID = nullActorID;
                        currentFrameRow.Ball.ActorID = nullActorID;
                    }
                    else if(referenceRow.Player.ActorID == int.Parse(deletedID.ToString()))
                    {
                        referenceRow.Player.ActorID = nullActorID;
                        currentFrameRow.Player.ActorID = nullActorID;
                    }
                    else if (referenceRow.EnemyPlayer.ActorID == int.Parse(deletedID.ToString()))
                    {
                        referenceRow.EnemyPlayer.ActorID = nullActorID;
                        currentFrameRow.EnemyPlayer.ActorID = nullActorID;
                    }
                }

                foreach (ActorUpdate update in json.Frames[frameNo].ActorUpdates)
                {
                    Point actorLocation = new Point();

                    if (update?.TaGameRbActorTaReplicatedRbState?.Position != null)
                    {
                        actorLocation = new Point(int.Parse(update.TaGameRbActorTaReplicatedRbState.Position.X.ToString()), int.Parse(update.TaGameRbActorTaReplicatedRbState.Position.Y.ToString()));
                    }

                    if (update.ClassName == "TAGame.Ball_TA")
                    {
                        //The ball gets updated, we'll put its ID and location up to date
                        currentFrameRow.Ball.ActorID = int.Parse(update.Id.ToString());
                        referenceRow.Ball.ActorID = int.Parse(update.Id.ToString());
                    }
                    else if (update.ClassName == "TAGame.Car_TA")
                    {
                        //A car was update
                        if (update.TaGameCarTaTeamPaint != null)
                        {
                            //if I get the team paint, I can get in which team the player was
                            if (update.TaGameCarTaTeamPaint.TeamNumber == playerTeamNumber)
                            {
                                currentFrameRow.Player.ActorID = int.Parse(update.Id.ToString());
                                referenceRow.Player.ActorID = int.Parse(update.Id.ToString());
                            }
                            else
                            {
                                currentFrameRow.EnemyPlayer.ActorID = int.Parse(update.Id.ToString());
                                referenceRow.EnemyPlayer.ActorID = int.Parse(update.Id.ToString());
                            }
                        }
                    }

                    if (update.Id == currentFrameRow.Ball.ActorID)
                    {
                        currentFrameRow.Ball.Location2D = actorLocation;
                        if (update.TaGameRbActorTaReplicatedRbState.LinearVelocity != null)
                        {
                            currentFrameRow.Ball.Velocity2D = new Point(int.Parse(update.TaGameRbActorTaReplicatedRbState.LinearVelocity.X.ToString()), int.Parse(update.TaGameRbActorTaReplicatedRbState.LinearVelocity.Y.ToString()));
                        }   
                    }
                    else if (update.Id == currentFrameRow.Player.ActorID)
                    {
                        currentFrameRow.Player.Location2D = actorLocation;
                    }
                    else if (update.Id == currentFrameRow.EnemyPlayer.ActorID)
                    {
                        currentFrameRow.EnemyPlayer.Location2D = actorLocation;
                    }


                }

                //if we have no position for an element on this frame, we'll assume the object has the same position he had last frame
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
            foreach (Goal goal in json.Properties.Goals)
            {
                //we will take every frame before a goal until the goal happens for a set number a frame. these are the frames that we consider good
                double minTimeForGoal = goal.Time - _TimeBeforeGoal;
                if (minTimeForGoal < 1)
                {
                    //this will make sure a goal scored in under the _TimeBeforeGoal doesn't crash
                    minTimeForGoal = 1;
                }
                
                if (goal.PlayerTeam == 0)
                {
                    foreach (MLDataRow row in dataRows)
                    {
                        if (row.Time >= minTimeForGoal && row.Time <= goal.Time)
                        {
                            //these are the frames that scored a goal for the player's team! :D
                            //these are good patterns that lead to a goal! so we give it the highest possible score : 100
                            if (row.Label == 50)
                            {
                                //I have to make sure it was an unchanged label! if the _nbFrameBeforeGoal goes to the previous play, I don' want to override that play's score
                                //so the score if 50 makes sure that the label hasn't been changed yet
                                row.Label = 100;
                            }
                        }
                    }
                }
                else if (goal.PlayerTeam == 1)
                {
                    foreach (MLDataRow row in dataRows)
                    {
                        if (row.Time >= minTimeForGoal && row.Time <= goal.Time)
                        {
                            //these are the frames that scored a goal for the enemy team! :'(
                            //these are bad patterns that lead to a goal in the wrong net! so we give it the lowest possible score : 0
                            if (row.Label == 50)
                            {
                                //Same thing as the positive outcome, I have the make sure I only label previously unlabeled rows
                                row.Label = 0;
                            }
                        }
                    }
                }
            }

            int nbUselessRow = 0;

            foreach (MLDataRow row in dataRows)
            {
                if (row.Ball.Velocity2D == Point.Empty)
                {
                    //If the ball had absolutely no velocity, I'm going to assume that there wasn't anything meaningful going on
                    //This will cut out pre-faceoff and post-goal time where the ball is not moving (after being deleted for exemple)
                    row.Useful = false;
                    nbUselessRow++;
                }
            }



            return dataRows;
        }
    }
}
