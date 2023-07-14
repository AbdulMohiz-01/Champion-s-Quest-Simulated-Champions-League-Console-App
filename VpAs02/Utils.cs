using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpAs02
{
    public class Utils
    {
        public static void GenerateTeams(int flag)
        {
            if (flag == 0) { 
            int selector = 0;
            for(int i = 0; i < Stats.TOTAL_GROUPS; i++)
            {
                for (int j = 0; j < Stats.teamsInGroup; j++)
                {
                    if (selector > Stats.currentTeams.Count)
                    {
                        break;
                    }
                    Stats.groups[i, j] = new Team(Stats.currentTeams[selector++], Stats.currentTeams[selector++], i);
                }
            }
            Stats.currentTeams = new List<string>();
            }
            // knockout group making
            else
            {
                for(int i = 0; i <= Stats.TOTAL_GROUPS - 1; i++)
                {
                    Stats.knockoutGroup[i, 0] = Stats.groupStageRunnerup[i];
                    Stats.knockoutGroup[i, 0].Clear();
                    Stats.knockoutGroup[i, 1] = Stats.groupStageWinner[i];
                    Stats.knockoutGroup[i, 1].Clear();
                }
                ClearData();
            }

            


        }


        public static void PlayMatch(Team firstTeam, Team secondTeam)
        {
            int firstTeamScore = RandomNumber();
            int secondTeamScore = RandomNumber();

            firstTeam.HomeGoals += firstTeamScore;
            secondTeam.AwayGoals += secondTeamScore;

            // incrementing goal differnce
            firstTeam.GoalsTaken += secondTeamScore;
            secondTeam.GoalsTaken += firstTeamScore;

            if(firstTeamScore > secondTeamScore)
            {
                firstTeam.Points += Stats.WIN_POINTS;
                Console.WriteLine($"\n{firstTeam.Name} vs {secondTeam.Name} \nGoals {firstTeamScore}:{secondTeamScore} \n{firstTeam.Name} won by {firstTeamScore - secondTeamScore} goals");
                Console.WriteLine($"{firstTeam.Name} GD: {firstTeam.TotalGoals() - firstTeam.GoalsTaken} :: {secondTeam.Name} GD: {secondTeam.TotalGoals() - secondTeam.GoalsTaken}");
            }
            else if (firstTeamScore < secondTeamScore)
            {
                secondTeam.Points += Stats.WIN_POINTS;
                Console.WriteLine($"\n{firstTeam.Name} vs {secondTeam.Name} \nGoals {firstTeamScore}:{secondTeamScore} \n{secondTeam.Name} won by {secondTeamScore - firstTeamScore} goals");
                Console.WriteLine($"{firstTeam.Name} GD: {firstTeam.TotalGoals() - firstTeam.GoalsTaken} :: {secondTeam.Name} GD: {secondTeam.TotalGoals() - secondTeam.GoalsTaken}");
            }
            else
            {
                firstTeam.Points += Stats.DRAW_POINTS;
                secondTeam.Points += Stats.DRAW_POINTS;
                Console.WriteLine($"\n{firstTeam.Name} vs {secondTeam.Name} | DRAW");
                Console.WriteLine($"{firstTeam.Name} GD: {firstTeam.TotalGoals() - firstTeam.GoalsTaken} :: {secondTeam.Name} GD: {secondTeam.TotalGoals() - secondTeam.GoalsTaken}");
            }

            Stats.matchHistory.Add(new History(firstTeam.Group, firstTeam, firstTeamScore, secondTeam, secondTeamScore));

        }
        public static Team[] Sort(int groupNumber)
        {
            Team[] singleGroup = new Team[Stats.teamsInGroup];
            for(int i = 0; i < Stats.teamsInGroup; i++)
            {
                singleGroup[i] = Stats.groups[groupNumber, i];
            }

             for (int j = 0; j <= singleGroup.Length - 2; j++) {
                for (int i = 0; i <= singleGroup.Length - 2; i++) {

                   if (singleGroup[i].Points < singleGroup[i + 1].Points) {
                        (singleGroup[i], singleGroup[i + 1]) = (singleGroup[i + 1], singleGroup[i]);
                   }

                }
             }
            return singleGroup;
            //for (int i = 0; i < Stats.TEAMS_IN_GROUP; i++)
            //{
            //    Stats.groups[groupNumber, i] = singleGroup[i];
            //}


        }
        // 9 9 9 9 
        public static (Team, Team) FilterTeams(Team[] subGroup)
        {
            int goalDifference;
            Team winner = null;
            Team runner = null;
            bool check = false;
            Team highestAwayGoals;
            int winnerGD = 0;
            int runnerGD = 0;
            // 9 9 8 1
            if(subGroup.Length == 2) {
                (goalDifference, highestAwayGoals) = FindHistory(subGroup[0], subGroup[1]);

                // 6 10 
                // 10 - 6 => +4
                if (goalDifference > 0)
                {
                    // team 1 has larger goal diff
                    winner = subGroup[0];
                    runner = subGroup[1];
                    check = true;
                }
                else if (goalDifference < 0)
                {
                    // team 2 has larger goal diff
                    winner = subGroup[1];
                    runner = subGroup[0];
                    check = true;

                }
                else
                {
                    // 9 9 9 9 

                    // calculate the higest away goals between team.
                    if (subGroup[0] == highestAwayGoals)
                    {
                        winner = subGroup[0];
                        runner = subGroup[1];
                        check = true;

                    }
                    else
                    {
                        winner = subGroup[1];
                        runner = subGroup[0];
                        check = true;

                    }
                }

            }
            else {
                // 9 9 9 9 

                for (int i = 0; i < subGroup.Length; i++)
                {
                    for (int j = i + 1; j < subGroup.Length; j++)
                    {
                       (goalDifference, highestAwayGoals) = FindHistory(subGroup[i], subGroup[j]);
                        if (goalDifference > 0)
                        {
                            // team 1 has larger goal diff

                            //now checking if the goal diff is smaller than winner and larger than runner
                            if(goalDifference < winnerGD && goalDifference > runnerGD)
                            {
                                runner = subGroup[i];
                                runnerGD = goalDifference;
                                check = true;
                            }
                            if(goalDifference > winnerGD && goalDifference > runnerGD)
                            {
                                winner = subGroup[i];
                                winnerGD = goalDifference;
                                check = true;
                            }
                        }
                        else if(goalDifference < 0)
                        {
                            goalDifference = -(goalDifference);
                            // team 2 has larger goal diff
                            //now checking if the goal diff is smaller than winner and larger than runner
                            if (goalDifference < winnerGD && goalDifference > runnerGD)
                            {
                                runner = subGroup[j];
                                runnerGD = goalDifference;
                                check = true;
                            }
                            if (goalDifference > winnerGD && goalDifference > runnerGD)
                            {
                                winner = subGroup[j];
                                winnerGD = goalDifference;
                                check = true;
                            }
                        }
                        else
                        {
                            // calculate the higest away goals between team.
                            if (subGroup[0] == highestAwayGoals)
                            {
                                winner = subGroup[0];
                                runner = subGroup[1];
                                check = true;
                            }
                            else
                            {
                                winner = subGroup[1];
                                runner = subGroup[0];
                                check = true;
                            }
                        }
                    }
                }
            }

            return check ? (winner, runner) : (null, null);

        }
        //public static (Team, Team) FindHighestGoals(Team t1, Team t2)
        //{
        //    Team winner = null;
        //    Team runner = null;
        //    int winnerHighestGD = 0;
        //    int runnerHighestGD = 0;
        //    for()
        //}
        public static (int, Team) FindHistory(Team t1, Team t2)
        {
            int goalDifference = 0;
            Team temp = null;
            int hg1 = 0; // higest goals in away match
            int hg2 = 0;
            for (int i = 0; i < Stats.matchHistory.Count; i++)
            {
                // t1 == t2 || t2 == t1 
                if ((Stats.matchHistory[i].FirstTeam == t1 && Stats.matchHistory[i].SecondTeam == t2) || (Stats.matchHistory[i].FirstTeam == t2 && Stats.matchHistory[i].SecondTeam == t1))
                {
                    goalDifference += Stats.matchHistory[i].FindGoalDifference();
                }
                if (Stats.matchHistory[i].FirstTeam == t1 && Stats.matchHistory[i].SecondTeam == t2)
                {
                    hg2 += Stats.matchHistory[i].SecondTeamGoals;
                }
                if (Stats.matchHistory[i].FirstTeam == t2 && Stats.matchHistory[i].SecondTeam == t1)
                {
                    hg1 += Stats.matchHistory[i].FirstTeamGoals;
                }
            }
            if (hg1 > hg2)
            {
                temp = t1;
            }
            else if (hg1 < hg2)
            {
                temp = t2;
            }
            else
            {
                // do nothing
            }
            return (goalDifference, temp);

        }
        public static List<int> TeamsWithCommonStats(Team[] group)
        {
            List<int> repitition = new List<int>();
            int count = default;

            for (int i = 0; i < group.Length;)
            {
                for (int j = i; j < group.Length; j++)
                {
                    if (group[i].Points == group[j].Points)
                    {
                        count++;
                    }
                }
                repitition.Add(count);
                i += count;
                count = 0;
            }
            return repitition;

        }
       public static int RandomNumber()
        {
            Random random = new();
            return random.Next(Stats.MIN_GOALS, Stats.MAX_GOALS + 1);
        }
        public static void DisplayCurrentTeams()
        {
            Console.WriteLine("Group stage complete ");
            Console.WriteLine("*************");
            Console.WriteLine("group stage resutls ");
            for (int i = 0; i < Stats.TOTAL_GROUPS; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"winner of group {i + 1} = {Stats.groupStageWinner[i].Name} points = {Stats.groupStageWinner[i].Points}");
                Console.WriteLine($"runner up of group {i + 1} = {Stats.groupStageRunnerup[i].Name} points = {Stats.groupStageRunnerup[i].Points}");
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine("*************");
        }
        public static void DisplayTeams(Team[,] array)
        {
            for (int i = 0; i < Stats.TOTAL_GROUPS; i++)
            {
                Console.WriteLine("________________________________________");
                Console.WriteLine($"\n++++++++Group {i + 1}+++++++++++++");
                for (int j = 0; j < Stats.teamsInGroup; j++)
                {                    
                    Console.WriteLine($"Team Name: {array[i,j].Name}");
                    Console.WriteLine($"Team Points: {array[i, j].Points}");
                }
                Console.WriteLine("\n");
            }
        }

        public static void DisplayList(List<Team> list)
        {
            int index = 1;
            foreach (Team i in list)
            {
                Console.WriteLine("Group: " + index++ +" Winner");
                Console.WriteLine($"{i.Name}");
            }
        }

        public static void shiftPlusOne(List<Team> group)
        {
            // 1 2 3 4 5 
            // 5 1 2 3 4
            for (int i = 0; i < group.Count; i++)
            {
                (group[i], group[group.Count - 1]) = (group[group.Count - 1], group[i]);
            }
            
        }
        public static void DrawKnockOut()
        {
            //  Clubs from the same association must not be drawn against each other.
            // w x w
            // r x r
            // w => r


            for (int i = 0; i < 8; i++)
            {
                if (Stats.groupStageRunnerup[i].Association == Stats.groupStageWinner[i].Association)
                {
                    shiftPlusOne(Stats.groupStageWinner);
                    DrawKnockOut();
                }
            }
            Stats.knockoutGroup = new Team[Stats.TOTAL_GROUPS, Stats.teamsInGroup];
        }
        public static void ClearData()
        {
            Stats.matchHistory = new List<History>();
        }

        public static void DisplayHistroy()
        {
            for (int i = 0; i < Stats.matchHistory.Count; i++)
            {
                Stats.matchHistory[i].DisplayData();
            }
        }
    }

}
