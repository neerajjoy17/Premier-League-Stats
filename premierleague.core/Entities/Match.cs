using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierleague.core.Entities
{
    public class Match
    {
        public int id {  get; set; }
        public int season { get; set; }
        public int week { get; set; }
        public DateOnly date { get; set; }
        public string home { get; set; }
        public int homegoals { get; set; }
        public int awaygoals { get; set; }
        public string away { get; set; }
        public string result { get; set; }

    }
}
