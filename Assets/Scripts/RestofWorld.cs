using System.Collections.Generic;

namespace FootBall.FixedInformation
{

	public class RestofWorld
    {
        public static string continentName { get; set; } = "Rest of World";
        public static string tierString { get; } = "All Tiers";
        private static string leagueNames = "Rest of World";

        public static Dictionary<string, string> countries { get; } = new Dictionary<string, string>()
        {
            {"Rest of World", "World" }
        };

		public static string[] allLeaguesNames => leagueNames.Split(',');
        public static List<League> allLeagues { get; set; } = new List<League>();

        public static League GetLeague(string leagueString)
        {
            foreach (League league in allLeagues)
            {
                if (league.Name == leagueString) return league;
            }

            return null;
        }
    }
}