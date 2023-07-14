using System.Collections;

namespace VpAs02
{
    public class App
    {
        static void Main(string[] args)
        {
            App app1 = new App();
            app1.Init();

            

           

            // Generate Teams

            // Make Groups

            // Play Matches

            // Display Winner of each group

            // Play quater Final ...
            
        }

        void Init()
        {
            Utils.GenerateTeams(0);
            Matches.GroupStage();
            Stats.teamsInGroup /= 2;
            Utils.DrawKnockOut();
            Utils.GenerateTeams(1);
            Console.WriteLine("**************************** Qualified Teams from Group Stage *****************************");
            Utils.DisplayTeams(Stats.knockoutGroup);

            Matches.FirstKnockoutRound();
            Utils.DisplayTeams(Stats.knockoutGroup);
            Console.WriteLine("**************************** Qualified Teams from Knock Out Stage *****************************");
            Utils.DisplayList(Stats.knockoutStageWinner);

        }

        //void GenerateTeams()
        //{
        //    // GROUP 1
        //    groups[0, 0] = new Team("Juventus", "ITA");
        //    groups[0, 1] = new Team("Bayern", "DEU");
        //    groups[0, 2] = new Team("Club Brugge", "BEL");
        //    groups[0, 3] = new Team("Rapid", "OST");
        //    // GROUP 2
        //    groups[1, 0] = new Team("Barcelona", "SPA");
        //    groups[1, 1] = new Team("Bremen", "DEU");
        //    groups[1, 2] = new Team("Udinese", "ITA");
        //    groups[1, 3] = new Team("Panathinaikos", "GRI");
        //    // GROUP 3
        //    groups[2, 0] = new Team("Milan", "ITA");
        //    groups[2, 1] = new Team("PSV", "HOL");
        //    groups[2, 2] = new Team("Schalke", "DEU");
        //    groups[2, 3] = new Team("Fenerbahçe", "TÜR");
        //    // GROUP 4
        //    groups[3, 0] = new Team("Liverpool", "ENG");
        //    groups[3, 1] = new Team("Chelsea", "ENG");
        //    groups[3, 2] = new Team("Betis", "SPA");
        //    groups[3, 3] = new Team("Anderlecht", "BEL");
        //    // GROUP 5
        //    groups[4, 0] = new Team("Arsenal", "ENG");
        //    groups[4, 1] = new Team("Ajax", "HOL");
        //    groups[4, 2] = new Team("Thun", "SCH");
        //    groups[4, 3] = new Team("Sparta", "TSC");
        //    // GROUP 6
        //    groups[5, 0] = new Team("Villarreal", "SPA");
        //    groups[5, 1] = new Team("Benfica", "POR");
        //    groups[5, 2] = new Team("Lille", "FRA");
        //    groups[5, 3] = new Team("Man. United", "ENG");
        //    // GROUP 7
        //    groups[6, 0] = new Team("Lyon", "FRA");
        //    groups[6, 1] = new Team("Real Madrid", "SPA");
        //    groups[6, 2] = new Team("Rosenborg", "NOR");
        //    groups[6, 3] = new Team("Olympiacos", "GRI");
        //    // GROUP 8
        //    groups[7, 0] = new Team("Internazionale", "ITA");
        //    groups[7, 1] = new Team("Rangers", "SCO");
        //    groups[7, 2] = new Team("Artmedia", "SLO");
        //    groups[7, 3] = new Team("Porto", "POR");

        //}

//         for(int i = 0; i< 8; i++)
//            {
//                for(int j = 0; j< 4; j++)
//                {
//                    Console.WriteLine(count++ + " "+Stats.groups[i, j].Name + " " + Stats.groups[i, j].Association);
                    
//                }
//}
    }
}