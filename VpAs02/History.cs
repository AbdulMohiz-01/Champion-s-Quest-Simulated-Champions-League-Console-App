using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpAs02
{
    public class History
    {
       public int Group { get; set; }
       public Team FirstTeam { get; set; }
       public int FirstTeamGoals { get; set; }
       public Team SecondTeam { get; set; }
       public int SecondTeamGoals { get; set; }

        public History(int group, Team firstTeam, int firstTeamGoals, Team secondTeam, int secondTeamGoals)
        {
            FirstTeam = firstTeam;
            FirstTeamGoals = firstTeamGoals;
            SecondTeam = secondTeam;
            SecondTeamGoals = secondTeamGoals;
            if(FirstTeam.Group == SecondTeam.Group) Group = group;
        }

        // if goal diff is +ve then team 1 will win, Team 2 otherwise.
        public int FindGoalDifference()
        {
            return FirstTeamGoals - SecondTeamGoals;
        }

        public void DisplayData()
        {
            Console.WriteLine($"Group: {Group}");
            Console.WriteLine($"{FirstTeam.Name} vs {SecondTeam.Name}");
            Console.WriteLine($"Goals {FirstTeamGoals}:{SecondTeamGoals}");
        }
    }
}
