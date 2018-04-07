using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplaysToDataSet.Data
{
    public class Ball
    {
        public Location Location = Location.Empty;
        public Location Velocity = Location.Empty;
        public int ActorID;
    }
}
