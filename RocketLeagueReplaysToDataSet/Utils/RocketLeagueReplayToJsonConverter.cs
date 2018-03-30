using RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace RocketLeagueReplaysToDataSet.Utils
{
    public static class RocketLeagueReplayToJsonConverter
    {
        /// <summary>
        /// Convert a rocket league replay to Json and get the resulting Json
        /// </summary>
        /// <param name="replayPath">Path to the rocket league replay</param>
        /// <param name="writeFile">if true, writes a file containing the resulting Json</param>
        /// <returns></returns>
        public static ReplayJson ConvertReplayToJson(string replayPath, bool writeFile)
        {
            string replayJson = string.Empty;

            using (Process process = new Process())
            {
                int timeout = 999999999;

                //Start rattletrap and convert target replay
                process.StartInfo.FileName = Properties.Settings.Default.RattletrapPath;
                process.StartInfo.Arguments = "-i \"" + replayPath + "\" > output.json";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                StringBuilder output = new StringBuilder();
                StringBuilder error = new StringBuilder();

                using (AutoResetEvent outputWaitHandle = new AutoResetEvent(false))
                using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
                {
                    process.OutputDataReceived += (sender2, e2) => {
                        if (e2.Data == null)
                        {
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            output.AppendLine(e2.Data);
                        }
                    };
                    process.ErrorDataReceived += (sender2, e2) =>
                    {
                        if (e2.Data == null)
                        {
                            errorWaitHandle.Set();
                        }
                        else
                        {
                            error.AppendLine(e2.Data);
                        }
                    };

                    process.Start();

                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    if (process.WaitForExit(timeout) &&
                        outputWaitHandle.WaitOne(timeout) &&
                        errorWaitHandle.WaitOne(timeout))
                    {
                        replayJson = output.ToString();
                        if (writeFile)
                        {
                            //Write a file with the json of the replay next to the replay file
                            File.WriteAllText(Path.Combine(Path.GetDirectoryName(replayPath),Path.GetFileNameWithoutExtension(replayPath)) + ".json", output.ToString());
                        }
                    }
                    else
                    {
                        // Timed out.
                        throw new TimeoutException("Json conversion took too long");
                    }
                }
            }

            return ReplayJson.FromJson(replayJson);
        }
    }
}
