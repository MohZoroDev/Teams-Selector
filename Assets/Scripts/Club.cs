using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

namespace FootBall
{
    [Serializable]
    public class Club
    {
        public string TeamLogoPath { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string League { get; set; }
        public byte Attack { get; set; }
        public byte Mid { get; set; }
        public byte Defense { get; set; }
        public byte OverAll { get; set; }
        public float Rating { get; set; }


        public Club(string continent, string country,string name, string league, byte attack, byte mid, byte defense, byte overall, float rating)
        {
            Continent = continent;
            Country = country;
            Name = name;
            League = league;
            Attack = attack;
            Mid = mid;
            Defense = defense;
            OverAll = overall;
            Rating = rating;
        }
        public Club(Club club)
        {
            this.Continent = club.Continent;
            this.Country = club.Country;
            this.Name = club.Name;
            this.League = club.League;
            this.Attack = club.Attack;
            this.Mid = club.Mid;
            this.Defense = club.Defense;
            this.OverAll = club.OverAll;
            this.Rating = club.Rating;
            this.TeamLogoPath = club.TeamLogoPath;
        }

        public Club() { }
        public static bool operator ==(Club club1, Club club2) => club1.Equals(club2);
        public static bool operator !=(Club club1, Club club2) => !club1.Equals(club2);

        public override bool Equals(object obj)
        {
            Club club = obj as Club;
            if (club is null)
                throw new InvalidDataException("Value can't be null");
            return this.Name == club.Name && this.League == club.League;
        }
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Name.GetHashCode();
            hash = (hash * 7) + League.GetHashCode();
            return hash;
        }

        public static List<Club> GetClubsData(string jsonString)
        {
            return JsonConvert.DeserializeObject<List<Club>>(jsonString);
        }

        public void GiveTeamsInfo(Transform team, Texture unknownTeamTexture)
        {
            Transform teamPath = team.Find("Team");
            Texture texture = Resources.Load<Texture>(TeamLogoPath);
            teamPath.GetComponent<RawImage>().texture = texture == null ? unknownTeamTexture : texture;

            teamPath.Find("Background").Find("Name").GetComponent<TextMeshProUGUI>().text = this.Name;

            Transform statusPath = teamPath.Find("Status");
            statusPath.Find("Attack").GetComponent<TextMeshProUGUI>().text = "ATT : " + this.Attack.ToString();
            statusPath.Find("Mid").GetComponent<TextMeshProUGUI>().text = "MID : " + this.Mid.ToString();
            statusPath.Find("Defense").GetComponent<TextMeshProUGUI>().text = "DEF : " + this.Defense.ToString();
            statusPath.Find("OverAll").GetComponent<TextMeshProUGUI>().text = "OVR : " + this.OverAll.ToString();

            team.Find("League Background").Find("League Name").GetComponent<TextMeshProUGUI>().text = this.League;
        }

        public void ResetInfo(Transform team, Texture unknownTeamTexture)
		{
            Transform teamPath = team.Find("Team");
            teamPath.GetComponent<RawImage>().texture = unknownTeamTexture;

            teamPath.Find("Background").Find("Name").GetComponent<TextMeshProUGUI>().text = "????";

            Transform statusPath = teamPath.Find("Status");
            statusPath.Find("Attack").GetComponent<TextMeshProUGUI>().text = "ATT : " + "??";
            statusPath.Find("Mid").GetComponent<TextMeshProUGUI>().text = "MID : " + "??";
            statusPath.Find("Defense").GetComponent<TextMeshProUGUI>().text = "DEF : " + "??";
            statusPath.Find("OverAll").GetComponent<TextMeshProUGUI>().text = "OVR : " + "??";

            team.Find("League Background").Find("League Name").GetComponent<TextMeshProUGUI>().text = "????";
        }

        public void SetTeamATT(Transform team, int ATT)
		{
            Transform statusPath = team.Find("Team").Find("Status");
            statusPath.Find("Attack").GetComponent<TextMeshProUGUI>().text = "ATT : " + ATT.ToString();
        }
        public void SetTeamMID(Transform team, int MID)
        {
            Transform statusPath = team.Find("Team").Find("Status");
            statusPath.Find("Mid").GetComponent<TextMeshProUGUI>().text = "MID : " + MID.ToString();
        }
        public void SetTeamDEF(Transform team, int DEF)
        {
            Transform statusPath = team.Find("Team").Find("Status");
            statusPath.Find("Defense").GetComponent<TextMeshProUGUI>().text = "DEF : " + DEF.ToString();
        }
        public void SetTeamOVR(Transform team, int OVR)
        {
            Transform statusPath = team.Find("Team").Find("Status");
            statusPath.Find("OverAll").GetComponent<TextMeshProUGUI>().text = "OVR : " + OVR.ToString();
        }
        public void SetTeamLeague(Transform team)
        {
            team.Find("League Background").Find("League Name").GetComponent<TextMeshProUGUI>().text = this.League;
            team.Find("Team").Find("Background").Find("Name").GetComponent<TextMeshProUGUI>().text = this.Name;

        }
        public void SetTeamLogo(Transform team, Texture unknownTeamTexture, Texture texture)
		{
            Transform teamPath = team.Find("Team");
            teamPath.GetComponent<RawImage>().texture = texture == null ? unknownTeamTexture : texture;
        }
    }  
}
