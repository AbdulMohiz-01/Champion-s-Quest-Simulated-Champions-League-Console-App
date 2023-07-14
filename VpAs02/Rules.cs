using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpAs02
{
    public class Rules
    {
        public static void FindKnockoutWinner()
        {
            Stats.knockoutStageWinner = new List<Team>();
            // Finding max goals
            for (int i = 0; i < Stats.TOTAL_GROUPS; i++)
            {
                if (Stats.knockoutGroup[i,0].TotalGoals() > Stats.knockoutGroup[i, 1].TotalGoals())
                {
                    Stats.knockoutStageWinner.Add(Stats.knockoutGroup[i, 0]);
                }
                else if(Stats.knockoutGroup[i, 0].TotalGoals() < Stats.knockoutGroup[i, 1].TotalGoals())
                {
                    Stats.knockoutStageWinner.Add(Stats.knockoutGroup[i, 1]);
                }
                else
                {
                    if (Stats.knockoutGroup[i, 0].AwayGoals > Stats.knockoutGroup[i, 1].AwayGoals)
                    {
                        Stats.knockoutStageWinner.Add(Stats.knockoutGroup[i, 0]);
                    }
                    else if (Stats.knockoutGroup[i, 0].AwayGoals < Stats.knockoutGroup[i, 1].AwayGoals)
                    {
                        Stats.knockoutStageWinner.Add(Stats.knockoutGroup[i, 1]);
                    }
                    else
                    {
                        int rand = Utils.RandomNumber();
                        if (rand % 2 == 0)
                        {
                            // Winner
                            Stats.knockoutStageWinner.Add(Stats.knockoutGroup[i, 0]);
                        }
                        else
                        {
                            // Winner
                            Stats.knockoutStageWinner.Add(Stats.knockoutGroup[i, 1]);
                        }
                    }


                }
            }
        }
        public static void FindWinnerAndRunner(int groupNumber)
        {
            Team[] group = Utils.Sort(groupNumber);

            

            // higher number of points obtained in the group matches played among the teams in question;

            if (group[0].Points > group[1].Points && group[1].Points > group[2].Points)
            {
                // Winner
                Stats.groupStageWinner.Add(group[0]);
                //Runner up
                Stats.groupStageRunnerup.Add(group[1]);
                return;

            }

            // 9 9 8 8
            // // 9 8 8 

            List<int> sameStats = Utils.TeamsWithCommonStats(group);

            if (sameStats[0] > 1)
            {
                (Team winner, Team runner)= Utils.FilterTeams(group[0..sameStats[0]]);
                if(winner != null && runner != null)
                {
                Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  winner: {winner.Name}, Runner: {runner.Name}");
                    Stats.groupStageWinner.Add(winner);
                    //Runner up
                    Stats.groupStageRunnerup.Add(runner);
                    return;
                }
            }
            else
            {
                // sameStats[1] is appears more than 1
                if (sameStats[1] > 1)
                {
                    Team winner = group[0];
                    (Team runner, _) = Utils.FilterTeams(group[1..sameStats[1]]);
                    if (runner != null)
                    {
                        Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  winner: {winner.Name}, Runner: {runner.Name}");
                        Stats.groupStageWinner.Add(winner);
                        //Runner up
                        Stats.groupStageRunnerup.Add(runner);
                        return;
                    }
                }

            }

            
            int rand = Utils.RandomNumber();
            if(rand%2 == 0)
            {
              // Winner
              Stats.groupStageWinner.Add(group[0]);
              //Runner up
              Stats.groupStageRunnerup.Add(group[1]);
            }
           else
           {
              // Winner
              Stats.groupStageWinner.Add(group[1]);
              //Runner up
              Stats.groupStageRunnerup.Add(group[0]);
           }
            





        }
    }
}
