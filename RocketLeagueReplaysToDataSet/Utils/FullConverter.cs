using RocketLeagueReplaysToDataSet.Data;
using RocketLeagueReplaysToDataSet.Data.RawReplayJsonClasses;
using System.Collections.Generic;
using System.IO;

namespace RocketLeagueReplaysToDataSet.Utils
{
    public static class FullConverter
    {
        public static void Launch()
        {
            foreach (string replayPath in Directory.GetFiles(Properties.Settings.Default.ReplayFolder))
            {
                if (replayPath.EndsWith(".replay"))
                {
                    ReplayJson replayJson = RocketLeagueReplayToJsonConverter.ConvertReplayToJson(replayPath, true);
                    List<MLDataRow> dataRows = ReplayJsonToDataRowConverter.ConvertReplayJsonToDataRow(replayJson);

                    WriteDataSet(dataRows);
                }
            }
        }

        /// <summary>
        /// Writes the data set in the folder specified in the settings file
        /// </summary>
        /// <param name="dataRows">The list of dataRow to include in the dataset</param>
        public static void WriteDataSet(IEnumerable<MLDataRow> dataRows)
        {
            List<string> dataSet = new List<string>();

            dataSet.Add(MLDataRow.DataRowFormat);

            foreach (MLDataRow row in dataRows)
            {
                if (row.Useful)
                {
                    dataSet.Add(row.DisplayDataRow());
                }
            }

            File.WriteAllLines(Properties.Settings.Default.DataSetFolder + "/dataset.csv", dataSet);
        }

    }
}
