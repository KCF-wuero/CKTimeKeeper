using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKTimeKeeper
{
    public class Data
    {
        [Name("Identifier")]
        [Index(0)]
        public DateOnly date { get; set; }
        [Index(1)]
        public TimeOnly startTime { get; set; }
        [Index(2)]
        public TimeOnly endTime { get; set; }
        [Index(3)]
        public string workedOn { get; set; } = "";
        [Index(4)]
        public string WTinMin { get; set; } = "";
    }
}
