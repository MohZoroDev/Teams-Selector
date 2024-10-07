using System.Collections.Generic;

namespace FootBall.FixedInformation
{
	public class NorthAmerica
    {
        public static string continentName { get; set; } = "North America";
        public static string tierString { get; } = "All Tiers";
        private static string leagueNames = "MLS";

		public static Dictionary<string, string> countries { get; } = new Dictionary<string, string>()
        {
            {"MLS", "USA" },
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