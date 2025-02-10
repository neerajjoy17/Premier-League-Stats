using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using premierleague.core.Dto;
using premierleague.core.Entities;
using premierleague.efcore.IRepository;

namespace premierleague.efcore.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DataRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<core.Entities.Match>> GetAllData()
        {
            return await _dbContext.matches.ToListAsync();
        }

        public async Task<List<GoalsBySeason>> GetGoalsBySeason()
        {

            var result = await _dbContext.matches.GroupBy(p => p.season).Select(x => new GoalsBySeason {
                season = x.FirstOrDefault().season,
                homegoals = x.Sum(t => t.homegoals),
                awaygoals = x.Sum(t => t.awaygoals)
            }).ToListAsync();

            return result;
        }

        public async Task<List<Team>> GetTeamStats()
        {
            List<Team> Stats = new List<Team>();
            var TeamList = await _dbContext.matches.Select(p => p.home).Distinct().ToListAsync();
            var HomeRecord = await _dbContext.matches.GroupBy(p => new {p.home})
                .Select(x => new 
                {
                    Name = x.Key.home,
                    Homematches = x.ToList()
                })
                .ToListAsync();
            var AwayRecord = await _dbContext.matches.GroupBy(p => new { p.away })
                .Select(x => new
                {
                    Name = x.Key.away,
                    AwayMatches = x.ToList()
                })
                .ToListAsync();
            foreach (var team in TeamList)
            {
                var Homewins = HomeRecord.Where(p => p.Name == team).FirstOrDefault()?.Homematches.Where(p => p.homegoals > p.awaygoals);
                var HomeDraws = HomeRecord.Where(p => p.Name == team).FirstOrDefault()?.Homematches.Where(p => p.homegoals == p.awaygoals);
                var HomeLosses = HomeRecord.Where(p => p.Name == team).FirstOrDefault()?.Homematches.Where(p => p.homegoals < p.awaygoals);
                var Awaywins = AwayRecord.Where(p => p.Name == team).FirstOrDefault()?.AwayMatches.Where(p => p.homegoals < p.awaygoals);
                var AwayDraws = AwayRecord.Where(p => p.Name == team).FirstOrDefault()?.AwayMatches.Where(p => p.homegoals == p.awaygoals);
                var AwayLosses = AwayRecord.Where(p => p.Name == team).FirstOrDefault()?.AwayMatches.Where(p => p.homegoals > p.awaygoals);

                var TotalMatches = Homewins.Count() + Awaywins.Count() + HomeDraws.Count() + AwayDraws.Count() + HomeLosses.Count() + AwayLosses.Count();
                var MostHomeWinsPerSeason = Homewins?.GroupBy(p => p.season).OrderByDescending(p => p.Count());
                var MostAwayWinsPerSeason = Awaywins?.GroupBy(p => p.season).OrderByDescending(p => p.Count());
                var MostHomeLossesPerSeason = HomeLosses?.GroupBy(p => p.season).OrderByDescending(p => p.Count());
                var MostAwayLossesPerSeason = AwayLosses?.GroupBy(p => p.season).OrderByDescending(p => p.Count());
                var BiggestHomeWin = Homewins?.OrderByDescending(p => (p.homegoals - p.awaygoals)).FirstOrDefault();
                var BiggestAwayWin = Awaywins?.OrderByDescending(p => (p.awaygoals - p.homegoals)).FirstOrDefault();

                var AlltimePoints = (Homewins?.Count() * 3) + HomeDraws?.Count();
                var AveragePointsPerSeason = (float)AlltimePoints / MostHomeWinsPerSeason?.Count();
                var MostGoalsFor = BiggestHomeWin?.homegoals > BiggestAwayWin?.awaygoals ? 
                    BiggestHomeWin?.homegoals : BiggestAwayWin?.awaygoals;
                var BiggestMargin = (BiggestHomeWin?.homegoals - BiggestHomeWin?.awaygoals) > (BiggestAwayWin?.homegoals - BiggestHomeWin?.awaygoals) ?
                    (BiggestHomeWin?.homegoals - BiggestHomeWin?.awaygoals) : (BiggestAwayWin?.homegoals - BiggestHomeWin?.awaygoals);

                Stats.Add(new Team()
                {
                    Name = team,
                    TotalPoints = AlltimePoints != null ? (int)AlltimePoints : 0,
                    TotalMatches = TotalMatches,
                    HomeWins = Homewins.Count(),
                    AwayWins = Awaywins.Count(),
                    HomeDraws = HomeDraws.Count(),
                    AwayDraws = AwayDraws.Count(),
                    HomeLosses = HomeLosses.Count(),
                    AwayLosses = AwayLosses.Count(),
                    MostAwayWinsPerSeason = MostAwayWinsPerSeason.First().Count(),
                    MostHomeWinsPerSeason = MostHomeWinsPerSeason.First().Count(),
                    MostGoalsForPerMatch = MostGoalsFor != null ? (int)MostGoalsFor : 0,
                    BiggestWinMargin = BiggestMargin != null ? (int)BiggestMargin : 0,
                    BiggestHomeWin = BiggestHomeWin,
                    BiggestAwayWin = BiggestAwayWin,
                    AveragePointsPerSeason = AveragePointsPerSeason != null ? (float)AveragePointsPerSeason : 0,
                });
            }
            return Stats;
        }
    }
}
