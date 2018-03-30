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
                }
            }
            
        }
    }
}
