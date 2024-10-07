using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FootBall.FixedInformation;
using static UnityEngine.GraphicsBuffer;

namespace FootBall
{
    [Serializable]
    public class League
    {
        public string Name { get; set; }

        public List<Club> Clubs = new List<Club>();
        public Club this[int index] => Clubs[index];

        public League(string name)
		{
            this.Name = name;
		}
        public League(League league)
        {
            Name = league.Name;

            Clubs = new List<Club>(league.Clubs);
        }
        public League() { }

        public static League GetChossenLeague()
        {
            switch (Continent.selectedContinent)
            {
                case "Europe":
                    return Europe.GetLeague(Continent.selectedLeague);
                case "Asia":
                    return Asia.GetLeague(Continent.selectedLeague);
                case "Australia":
                    return Australia.GetLeague(Continent.selectedLeague);
                case "North America":
                    return NorthAmerica.GetLeague(Continent.selectedLeague);
                case "South America":
                    return SouthAmerica.GetLeague(Continent.selectedLeague);
                case "Rest of World":
                    return RestofWorld.GetLeague(Continent.selectedLeague);
            }
            return null;
        }
        public static League GetRandomLeague(List<League> leagueList)
		{
            int randomIndex = UnityEngine.Random.Range(0, leagueList.Count);

            return new League(leagueList[randomIndex]);
		}
        public static List<Club> SeperateClubsByPower(League league, int power)
        {
            if (power == 0) return new List<Club>(league.Clubs);

            List<Club> clubs = new List<Club>();

            int clubsCount = league.Clubs.Count;
            int clubsCountMod = clubsCount % 3;
            int startPoint = 0;
            int multiplier = 0;
            int plus = 0;

            if (power == 1)
            {
                startPoint = 0;
                multiplier = 1;
                plus = 0;
            }
            else if (power == 2)
            {
                startPoint = clubsCount / 3;
                multiplier = 2;
                plus = clubsCountMod == 2 ? 1 : 0;
            }
            else if (power == 3)
            {
                startPoint = clubsCount / 3 * 2;
                multiplier = 3;
                plus = clubsCountMod == 2 ? 1 : 0;
            }

            int limit = (clubsCount / 3 * multiplier) + plus;

            if (limit < 2) limit++;

            for (int i = startPoint; i < limit + plus; i++)
            {
                clubs.Add(new Club(league[i]));
            }

            return clubs;
        }

        public List<Club> GetCLubs(Club firstClub, int difference)
        {
            List<Club> clubs = new List<Club>();

            foreach (Club club in this.Clubs)
            {
                if (Math.Abs(club.OverAll - firstClub.OverAll) <= difference)
                {
                    if (club == firstClub) continue;
                    clubs.Add(new Club(club));
                }
            }
            return clubs;
        }
        public List<Club> GetClosestClubs(int ovr)
        {
            List<Club> clubs = new List<Club>();

			Club lowerBound = this.Clubs
						 .Where(item => item.OverAll <= ovr)
						 .OrderByDescending(item => item.OverAll)
						 .FirstOrDefault();

			Club upperBound = this.Clubs
						 .Where(item => item.OverAll > ovr)  
						 .OrderBy(item => item.OverAll)         
						 .FirstOrDefault();


            if (lowerBound is not null) clubs.Add(new Club(lowerBound));
            if (upperBound is not null) clubs.Add(new Club(upperBound));

            return clubs;
        }

		public static bool operator ==(League league1, League league2) => league1.Equals(league2);
		public static bool operator !=(League league1, League league2) => !league1.Equals(league2);

		public override bool Equals(object obj)
		{
			League league = obj as League;
			if (league is null)
				throw new InvalidDataException("Value can't be null");
            return this.Name == league.Name;
		}
		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + Name.GetHashCode();
			return hash;
		}
	}
}
