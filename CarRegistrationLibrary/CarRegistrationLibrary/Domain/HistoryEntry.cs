using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegistrationLibrary.Domain
{
    public struct HistoryEntry
    {

        internal static HistoryEntry FromDbLine(string dbString)
        {
            var split = dbString.Trim().Split(',');
            return new HistoryEntry(split[0], split[1], long.Parse(split[2]));
        }

        public HistoryEntry(string vin, string ownerName, long mileage)
        {
            Vin = vin;
            OwnerName = ownerName;
            Mileage = mileage;
        }

        public string Vin { get; set; }
        public string OwnerName { get; set; }
        public long Mileage { get; set; }

        public string ToDbLine()
        {
            return $"{Vin},{OwnerName},{Mileage}";
        }
    }
}
