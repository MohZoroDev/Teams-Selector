using System.Collections.Generic;
using Newtonsoft.Json;

namespace FootBall.FixedInformation
{
	public class Asia
    {
        public static string continentName { get; set; } = "Asia";
        public static string tierString { get; set; } = "All Tiers";
        private static string leagueNames { get; set; } = "ROSHN Saudi League,K League 1,Hero ISL,CSL";

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

        public class ContinentDataContainer
        {
            public string continentName;
            public string tierString;
            public string leagueNames;
            public string[] allLeaguesNames;
        }

        public static string SerilizeData()
        {
            ContinentDataContainer data = new ContinentDataContainer
            {
                continentName = Asia.continentName,
                tierString = Asia.tierString,
                leagueNames = Asia.leagueNames,
                allLeaguesNames = Asia.leagueNames.Split(',')
            };

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}