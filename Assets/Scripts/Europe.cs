using System.Collections.Generic;

namespace FootBall.FixedInformation
{
	public class Europe
    {
        public static string continentName { get; set; } = "Europe";
        public static string[] tiersStrings { get; } = { "1st Tier", "2nd Tier", "3rd Tier" };

        #region AllLeaguesNames
        private static string leaguesNames = "SSE Airtricity PD," +                // Ireland Premier Division
                                        "1A Pro League," +                    // Belgium Pro League
                                        "3. Liga," +                          // Germany 3. Liga
                                        "3F Superliga," +                     // Denmark Superliga
                                        "Allsvenskan," +                      // Sweden Allsvenskan
                                        "Bundesliga 2," +                     // Germany 2. Bundesliga
                                        "Bundesliga," +                       // Germany Bundesliga
                                        "Cinch Prem," +                       // Scotland Premier League
                                        "EFL Championship," +                 // England Championship
                                        "EFL League One," +                    // England League One
                                        "PKO Ekstraklasa," +                   // Poland Ekstraklasa
                                        "LaLiga SmartBank," +                  // Spain Segunda Division
                                        "Süper Lig," +                        // Turkey Super Lig
                                        "EFL League Two," +                    // England League Two
                                        "Eliteserien," +                      // Norway Eliteserien
                                        "Eredivisie," +                       // Netherlands Eredivisie
                                        "LaLiga Santander," +                  // Spain La Liga
                                        "Liga Portugal," +                    // Portugal Primeira Liga
                                        "Ligue 1 Uber Eats," +                 // France Ligue 1
                                        "Ligue 2 BKT," +                      // France Ligue 2
                                        "Ö. Bundesliga," +                    // Austria Bundesliga
                                        "Premier League," +                    // Scotland Premiership
                                        "Serie A TIM," +                       // Italy Serie A
                                        "Serie BKT," +                         // Italy Serie B
                                        "SUPERLIGA";                           // Romania Primera Division
        #endregion
        #region LeaguesTiersNames
        #region FirstTier
        private static string firstTierLeaguesNamesPrivate = "Bundesliga," +                  // Germany //
                                                      "LaLiga Santander," +            // Spain //
                                                      "Ligue 1 Uber Eats," +           // France //
                                                      "Premier League," +              // England //
                                                      "Serie A TIM";                   // Italy //
        #endregion
        #region SecondTier
        private static string secondTierLeaguesNamesPrivate = "EFL Championship," +         // England//
                                                       "Eredivisie," +               // Netherlands //
                                                       "LaLiga SmartBank," +         // Spain //
                                                       "Liga Portugal," +            // Portugal
                                                       "Serie BKT," +                // Italy //
                                                       "Süper Lig";                  // Turkey //
        #endregion
        #region ThirdTier
        private static string thirdTierLeaguesNamesPrivate = "1A Pro League," +               // Belgium//
                                                      "3. Liga," +                     // Germany //
                                                      "3F Superliga," +                // Denmark //
                                                      "Allsvenskan," +                 // Sweden //
                                                      "Bundesliga 2," +                // Germany //
                                                      "Cinch Prem," +                  // England //
                                                      "EFL League One," +              // England //
                                                      "EFL League Two," +              // England //
                                                      "Eliteserien," +                 // Norway //
                                                      "Ligue 2 BKT," +                 // France //
                                                      "PKO Ekstraklasa," +             // Poland //
                                                      "SSE Airtricity PD," +           // Ireland //
													  "Ö. Bundesliga," +               // Austria //
													  "SUPERLIGA";                     // Romania //
        #endregion
        #endregion

        public static List<League> allLeagues { get; set; } = new List<League>();
        public static List<League> firstTierLeagues { get; set; } = new List<League>();
        public static List<League> secondTierLeagues { get; set; } = new List<League>();
        public static List<League> thirdTierLeagues { get; set; } = new List<League>();

        public static List<List<League>> allLeaguesLists { get; } = new List<List<League>>()
        {
            firstTierLeagues,
            secondTierLeagues,
            thirdTierLeagues
        };

        public static string[] allLeaguesNames => leaguesNames.Split(',');
        public static string[] firstTierLeaguesNames => firstTierLeaguesNamesPrivate.Split(',');
        public static string[] secondTierLeaguesNames => secondTierLeaguesNamesPrivate.Split(',');
        public static string[] thirdTierLeaguesNames => thirdTierLeaguesNamesPrivate.Split(',');

        public static string[][] allTiersleaguesNamesArrays { get; } =
        {
            firstTierLeaguesNames,
            secondTierLeaguesNames,
            thirdTierLeaguesNames
        };

        public static string GetLeagueTier(string leagueString)
        {
            int i = 0;
            foreach (string[] strArray in allTiersleaguesNamesArrays)
            {
                foreach (string str in strArray)
                {
                    if (str == leagueString) return tiersStrings[i];
                }
                i++;
            }

            return null;
        }

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