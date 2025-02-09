using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using premierleague.core.Dto;
using premierleague.core.Entities;
using premierleague.efcore.IRepository;
using premierleague.service.IService;

namespace premierleague.service.Service
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public async Task<List<Match>> GetAllData()
        {
            return await _dataRepository.GetAllData();
        }

        public async Task<List<GoalsBySeason>> GetGoalsBySeason()
        {
            return await _dataRepository.GetGoalsBySeason();
        }
    }
}
