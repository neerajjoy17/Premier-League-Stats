using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace premierleague.core.Dto
{
    public class GoalsBySeason
    {
        private int _homegoals;
        private int _awaygoals;
        private int _totalgoals;
        public int season {  get; set; }
        public int homegoals { get { return _homegoals; } set {
                _homegoals = value;
                _totalgoals = _homegoals + _awaygoals;
            } }
        public int awaygoals {
                get { return _awaygoals; }
                set {
                    _awaygoals = value;
                    _totalgoals = _homegoals + _awaygoals;
                }
            }
        public int totalgoals
        {
            get { return _totalgoals; }
            private set { _totalgoals = value; }
        }

    }
}
