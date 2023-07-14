using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VpAs02
{
    public class Stats
    {
        public const int TOTAL_TEAMS = 32;
        public const int TOTAL_GROUPS = 8;
        public static int teamsInGroup = 4;
        public const int MAX_GOALS = 10;
        public const int MIN_GOALS = 0;
        public const int WIN_POINTS = 3;
        public const int DRAW_POINTS = 1;
        public static Team[,] groups = new Team[TOTAL_GROUPS, teamsInGroup];
        public static List<string>? currentTeams = new List<string> { "Juventus", "ITA", "Bayern", "DEU", "Club Brugge", "BEL" , "Rapid", "OST", "Barcelona", "SPA", "Bremen", "DEU", "Udinese", "ITA", "Panathinaikos", "GRI", "Milan", "ITA", "PSV", "HOL", "Schalke", "DEU", "Fenerbahçe", "TÜR", "Liverpool", "ENG", "Chelsea", "ENG", "Betis", "SPA", "Anderlecht", "BEL", "Arsenal", "ENG", "Ajax", "HOL", "Thun", "SCH", "Sparta", "TSC", "Villarreal", "SPA", "Benfica", "POR", "Lille", "FRA", "Man. United", "ENG", "Lyon", "FRA", "Real Madrid", "SPA", "Rosenborg", "NOR", "Olympiacos", "GRI", "Internazionale", "ITA", "Rangers", "SCO", "Artmedia", "SLO", "Porto", "POR" };
        public static List<History> matchHistory = new();
        public static List<Team> groupStageWinner = new List<Team> { };
        public static List<Team> groupStageRunnerup = new List<Team> { };
        public static Team[,] knockoutGroup;
        public static List<Team> knockoutStageWinner;

        static Stats() { }
        
        
    }
}
