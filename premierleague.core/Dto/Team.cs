using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using premierleague.core.Entities;

namespace premierleague.core.Dto
{
    public class Team
    {
        public string Name { get; set; }
        public int TotalPoints {  get; set; }
        public float AveragePointsPerSeason { get; set; }
        public int MostGoalsForPerMatch {  get; set; }
        public int MostGoalsAgainstPerMatch { get; set; } //need to be populated
        public int TotalMatches { get; set; }
        public int HomeWins { get; set; }
        public int AwayWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayLosses { get; set; }
        public int HomeDraws { get; set; }
        public int AwayDraws { get; set; }
        public int BiggestWinMargin { get; set; }
        public Match BiggestHomeWin {  get; set; }
        public Match BiggestAwayWin { get; set; }
        public int MostAwayWinsPerSeason { get; set; }
        public int MostHomeWinsPerSeason { get; set; }
    }
}
