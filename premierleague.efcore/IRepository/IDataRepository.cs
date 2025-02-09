using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using premierleague.core.Dto;
using premierleague.core.Entities;

namespace premierleague.efcore.IRepository
{
    public interface IDataRepository
    {
        public Task<List<Match>> GetAllData();

        public Task<List<GoalsBySeason>> GetGoalsBySeason();
    }
}
