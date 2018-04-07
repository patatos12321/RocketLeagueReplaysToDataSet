using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeagueReplaysToDataSet.Data
{
    public class Location
    {
        public int X;
        public int Y;
        public int Z;

        public static Location Empty
        {
            get { return new Location(0, 0, 0); }
        }

        public Location()
        {
        }

        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            Location location = obj as Location;
            if (location == null)
            {
                return false;
            }

            if (location.X == X && location.Y == Y && location.Z == Z)
            {
                return true;
            }

            return base.Equals(obj);
        }
    }
}
