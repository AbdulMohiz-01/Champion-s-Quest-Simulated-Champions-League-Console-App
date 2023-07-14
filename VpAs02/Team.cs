using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpAs02
{
    public class Team
    {
        public int Group { get; set; }
        public string Name { get; set; }
        public string Association { get; set; }
        public int GoalsTaken { get; set; }
        public int Points { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }


        public Team(string name, string association, int group)
        {
            Name = name;
            Association = association.ToUpper();
            Points = 0;
            GoalsTaken = 0;
            HomeGoals = 0;
            AwayGoals = 0;
            Group = group;
        }

        public void Clear()
        {
            GoalsTaken = 0;
            Points = 0;
            HomeGoals = 0;
            AwayGoals = 0;
        }

        public int TotalGoals()
        {
            return HomeGoals + AwayGoals;
        }
        public int GoalDifference()
        {
            return TotalGoals() - GoalsTaken;
        }
    }
}
