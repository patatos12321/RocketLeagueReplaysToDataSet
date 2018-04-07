using RocketLeagueReplaysToDataSet.Data;
using RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses;
using System.Collections.Generic;
using System.IO;

namespace RocketLeagueReplaysToDataSet.Utils
{
    public static class FullConverter
    {
        public static void Launch(bool dataSetForReplay)
        {
            foreach (string replayPath in Directory.GetFiles(Properties.Settings.Default.ReplayFolder))
            {
                if (replayPath.EndsWith(".replay"))
                {
                    ReplayJson replayJson = RocketLeagueReplayToJsonConverter.ConvertReplayToJson(replayPath, true);
                    List<MLDataRow> dataRows = ReplayJsonToDataRowConverter.ConvertReplayJsonToDataRow(replayJson);

                    WriteDataSet(dataRows, dataSetForReplay, Path.GetFileNameWithoutExtension(replayPath));
                }
            }
        }

        /// <summary>
        /// Writes the data set in the folder specified in the settings file
        /// </summary>
        /// <param name="dataRows">The list of dataRow to include in the dataset</param>
        public static void WriteDataSet(IEnumerable<MLDataRow> dataRows, bool dataSetForReplay, string fileName)
        {
            string fileToWrite;
            List<string> dataSet = new List<string>();

            if (dataSetForReplay)
            {
                fileToWrite = Path.Combine(Properties.Settings.Default.DataSetFolder, fileName) + ".rlu";
                dataSet.Add(MLDataRow.DataRowFormatForReplay);
            }
            else
            {
                fileToWrite = Path.Combine(Properties.Settings.Default.DataSetFolder, fileName) + ".csv";
                dataSet.Add(MLDataRow.DataRowFormat);
            }
            
            foreach (MLDataRow row in dataRows)
            {
                if (dataSetForReplay)
                {
                    //For a replay, I want to take every row's display with additional information
                    dataSet.Add(row.DisplayDataRowForReplay());
                }
                else if (row.Useful)
                {
                    //for a ML dataset, I will only take the essential informations and useful frames
                    dataSet.Add(row.DisplayDataRow());
                }
            }

            
            File.WriteAllLines(fileToWrite, dataSet);
        }

    }
}
