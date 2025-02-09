using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using premierleague.core.Dto;
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
    }
}
