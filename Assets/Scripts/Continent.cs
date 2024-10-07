using System.Collections.Generic;

namespace FootBall.FixedInformation
{
	public class Continent
    {
        public static string[] allContinents { get; } =
        {
            "Asia",
            "Australia",
            "Europe",
            "North America",
            "South America",
            "Rest of World"
        };

        #region Europe Info
        private static string[] europeCountries { get; } =
        {
            "Austria",
            "Belgium",
            "Denmark",
            "England",
            "France",
            "Germany",
            "Italy",
            "Ireland",
            "Netherlands",
            "Norway",
            "Portugal",
            "Poland",
            "Romania",
            "Spain",
            "Sweden",
            "Turkey"
        };
        private static string[] austariaLeaguesNames { get; } = { "Ö. Bundesliga" };
        private static string[] belgiumLeaguesNames { get; } = { "1A Pro League" };
        private static string[] denmarkLeaguesNames { get; } = { "3F Superliga" };
        private static string[] englandLeaguesNames { get; } = { "Premier League", "EFL Championship", "EFL League One", "EFL League Two" };
        private static string[] franceLeaguesNames { get; } = { "Ligue 1 Uber Eats", "Ligue 2 BKT" };
        private static string[] germanyLeaguesNames { get; } = { "Bundesliga", "3. Liga" };
        private static string[] italyLeaguesNames { get; } = { "Serie A TIM", "Serie BKT" };
        private static string[] irelandLeaguesNames { get; } = { "SSE Airtricity PD" };
        private static string[] netherlandsLeaguesNames { get; } = { "Eredivisie" };
        private static string[] norwayLeaguesNames { get; } = { "Eliteserien" };
        private static string[] portugalLeaguesNames { get; } = { "Liga Portugal" };
        private static string[] polandLeaguesNames { get; } = { "PKO Ekstraklasa" };
        private static string[] romaniaLeaguesNames { get; } = { "SUPERLIGA" };
        private static string[] spainLeaguesNames { get; } = { "LaLiga Santander", "LaLiga SmartBank" };
        private static string[] swedenLeaguesNames { get; } = { "Allsvenskan" };
        private static string[] switzerlandLeaguesNames { get; } = { "CSSL" };
        private static string[] turkeyLeaguesNames { get; } = { "Süper Lig" };
        #endregion
        #region Asia Info
        private static string[] asiaCountries { get; } = { "China", "India", "South Korea", "Saudi Arabia" };
        private static string[] chinaLeaguesNames { get; } = { "CSL" };
        private static string[] indiaLeaguesNames { get; } = { "Hero ISL" };
        private static string[] southKoreaLeaguesNames { get; } = { "K League 1" };
        private static string[] saudiArabiaLeaguesNames { get; } = { "ROSHN Saudi League" };
        #endregion
        #region Australia Info
        private static string[] australiaCountries { get; } = { "New Zealand" };
        private static string[] newZelandLeaguesNames { get; } = { "A-League" };
        #endregion
        #region North America Info
        private static string[] northAmericaCountries { get; } = { "United States" };
        private static string[] unitedStatesLeaguesNames { get; } = { "MLS" };
        #endregion
        #region South America Info
        private static string[] southAmericaCountries { get; } = { "Argentina", "Brazil", };
        private static string[] argentinaLeaguesNames { get; } = { "LPF" };
        private static string[] brazilLeaguesNames { get; } = { "Libertadores", "Sudamericana" };
        #endregion
        #region Rest of World Info
        private static string[] restOfWorldCountries { get; } = { "Rest of World" };
        private static string[] restOfWorldLeagues { get; } = { "Rest of World" };
        #endregion

        public static string selectedContinent { get; set; }
        public static string selectedCountry { get; set; }
        public static string selectedLeague { get; set; }
        public static List<League> thirdTierLeagues { get; set; }
        public static List<League> allLeagues { get; set; }
		private static Dictionary<string, string> countries { get; } = new Dictionary<string, string>()
			{
				{"SSE Airtricity PD","Rep. Ireland" },
				{"1A Pro League", "Belgium"},
				{"3. Liga", "Germany"},
				{"3F Superliga", "Denmark"},
				{"Allsvenskan", "Sweden" },
				{"Bundesliga 2", "Germany" },
				{"Bundesliga", "Germany" },
				{"Cinch Prem", "Scotland" },
				{"Premier League", "England" },
				{"EFL Championship", "England" },
				{"EFL League One", "England" },
				{"EFL League Two", "England" },
				{"PKO Ekstraklasa", "Poland" },
				{"LaLiga SmartBank", "Spain" },
				{"Süper Lig", "Turkey" },
				{"Eliteserien", "Norway" }, 
				{"Eredivisie", "Holland" },
				{"LaLiga Santander", "Spain" },
				{"Liga Portugal", "Portugal" },
				{"Ligue 1 Uber Eats", "France" },
				{"Ligue 2 BKT", "France" },
				{"Ö. Bundesliga", "Austria" },
				{"Serie A TIM", "Italy" },
				{"Serie BKT", "Italy" },
				{"SUPERLIGA", "Romania" },
				{"CSL", "China" },
				{"ROSHN Saudi League", "Saudi" },
				{"K League 1", "Korea" },
				{"Hero ISL", "India" },
				{"A-League", "Australia" },
				{"MLS", "USA" },
				{"Libertadores", "CONMEBOL" },
				{"Sudamericana", "CONMEBOL" },
				{"LPF", "Argentina" },
				{"Rest of World", "World" }
			};

		public static string[] GetContinentCountries()
        {
            switch (selectedContinent)
            {
                case "Asia":
                    return asiaCountries;
                case "Australia":
                    return australiaCountries;
                case "Europe":
                    return europeCountries;
                case "North America":
                    return northAmericaCountries;
                case "South America":
                    return southAmericaCountries;
                case "Rest of World":
                    return restOfWorldCountries;
            }

            return null;
        }

        public static string[] GetCountryLeagues()
        {
            #region Europe Leagues
            switch (selectedCountry)
            {
                case "Austria":
                    return austariaLeaguesNames;
                case "Belgium":
                    return belgiumLeaguesNames;
                case "Denmark":
                    return denmarkLeaguesNames;
                case "England":
                    return englandLeaguesNames;
                case "France":
                    return franceLeaguesNames;
                case "Germany":
                    return germanyLeaguesNames;
                case "Italy":
                    return italyLeaguesNames;
                case "Ireland":
                    return irelandLeaguesNames;
                case "Netherlands":
                    return netherlandsLeaguesNames;
                case "Norway":
                    return norwayLeaguesNames;
                case "Portugal":
                    return portugalLeaguesNames;
                case "Poland":
                    return polandLeaguesNames;
                case "Romania":
                    return romaniaLeaguesNames;
                case "Spain":
                    return spainLeaguesNames;
                case "Sweden":
                    return swedenLeaguesNames;
                case "CSSL":
                    return switzerlandLeaguesNames;
                case "Turkey":
                    return turkeyLeaguesNames;
            }
            #endregion
            #region Asia Leagues
            switch (selectedCountry)
            {
                case "China":
                    return chinaLeaguesNames;
                case "India":
                    return indiaLeaguesNames;
                case "South Korea":
                    return southKoreaLeaguesNames;
                case "Saudi Arabia":
                    return saudiArabiaLeaguesNames;
            }
            #endregion
            #region Australia Leagues
            switch (selectedCountry)
            {
                case "New Zealand":
                    return newZelandLeaguesNames;
            }
            #endregion
            #region NorthAmerica Leagues
            switch (selectedCountry)
            {
                case "United States":
                    return unitedStatesLeaguesNames;
            }
            #endregion          
            #region SouthAmerica Leagues
            switch (selectedCountry)
            {
                case "Brazil":
                    return brazilLeaguesNames;
                case "Argentina":
                    return argentinaLeaguesNames;
            }
            #endregion          
            #region RestofWorld Leagues
            switch (selectedCountry)
            {
                case "Rest of World":
                    return restOfWorldLeagues;
            }
            #endregion
            return null;
        }        
        public static string GetCountryByLeague(string leagueName)
        {
            return countries[leagueName];
        }
        public static List<League> GetAllLeagues()
        {
            List<League> leagues = new List<League>();

            foreach (League league in Europe.allLeagues) { leagues.Add(league); }

            foreach (League league in Asia.allLeagues) { leagues.Add(league); }
           
            foreach (League league in Australia.allLeagues) { leagues.Add(league); }

            foreach (League league in NorthAmerica.allLeagues) { leagues.Add(league); }

            foreach (League league in SouthAmerica.allLeagues) { leagues.Add(league); }

            foreach (League league in RestofWorld.allLeagues) { leagues.Add(league); }

            return leagues;
        }
        public static List<League> GetThirdTierLeagues()
        {
            List<League> leagues = new List<League>();

            foreach (League league in Europe.thirdTierLeagues) { leagues.Add(league); }

            foreach (League league in Asia.allLeagues) { leagues.Add(league); }
           
            foreach (League league in Australia.allLeagues) { leagues.Add(league); }

            foreach (League league in NorthAmerica.allLeagues) { leagues.Add(league); }

            foreach (League league in SouthAmerica.allLeagues) { leagues.Add(league); }

            foreach (League league in RestofWorld.allLeagues) { leagues.Add(league); }

            return leagues;
        }
    }
}