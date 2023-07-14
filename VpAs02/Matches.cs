using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpAs02
{
    public class Matches
    {
        public static void GroupStage()
        {
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%  GROUP STAGE MATCHES  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            int i = 0;
            for (; i < Stats.TOTAL_GROUPS; i++)
            {
                Console.WriteLine($"\n\n--------- GROUP {i+1} ---------");

                Console.WriteLine("__________________________________");
                Console.WriteLine("\n1st Matchday");
                Utils.PlayMatch(Stats.groups[i, 1], Stats.groups[i, 2]);
                Console.WriteLine();
                Utils.PlayMatch(Stats.groups[i, 3], Stats.groups[i, 0]);

                Console.WriteLine("__________________________________");
                Console.WriteLine("\n2nd Matchday");
                Utils.PlayMatch(Stats.groups[i, 0], Stats.groups[i, 1]);
                Console.WriteLine();
                Utils.PlayMatch(Stats.groups[i, 2], Stats.groups[i, 3]);
                Console.WriteLine("__________________________________");

                Console.WriteLine("\n3rd Matchday");
                Utils.PlayMatch(Stats.groups[i, 3], Stats.groups[i, 0]);
                Console.WriteLine();
                Utils.PlayMatch(Stats.groups[i, 1], Stats.groups[i, 3]);
                Console.WriteLine("__________________________________");

                Console.WriteLine("\n4th Matchday");
                Utils.PlayMatch(Stats.groups[i, 0], Stats.groups[i, 2]);
                Console.WriteLine();
                Utils.PlayMatch(Stats.groups[i, 3], Stats.groups[i, 1]);
                Console.WriteLine("__________________________________");

                Console.WriteLine("\n5th Matchday");
                Utils.PlayMatch(Stats.groups[i, 2], Stats.groups[i, 1]);
                Console.WriteLine();
                Utils.PlayMatch(Stats.groups[i, 0], Stats.groups[i, 3]);
                Console.WriteLine("__________________________________");

                Console.WriteLine("\n6th Matchday");
                Utils.PlayMatch(Stats.groups[i, 1], Stats.groups[i, 0]);
                Console.WriteLine();
                Utils.PlayMatch(Stats.groups[i, 3], Stats.groups[i, 2]);
                Console.WriteLine("__________________________________");

                Rules.FindWinnerAndRunner(i);
            }
            Utils.DisplayTeams(Stats.groups);
            //Utils.DisplayHistroy();
            
        }
        public static void FirstKnockoutRound()
        {
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%  FIRST KNOCK-OUT ROUND  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            // home matches
            for (int i = 0; i < Stats.TOTAL_GROUPS; i++)
            {
               Utils.PlayMatch(Stats.knockoutGroup[i, 0], Stats.knockoutGroup[i, 1]);
            }
            // away matches
            for (int i = 0; i < Stats.TOTAL_GROUPS; i++)
            {
                Utils.PlayMatch(Stats.knockoutGroup[i, 1], Stats.knockoutGroup[i, 0]);
            }

            Rules.FindKnockoutWinner();
        }
    }

        
}

//1 2 3 4
//0 1 2 3
