using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using FootBall;
using FootBall.FixedInformation;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Net.Http;
using System;
using UnityEngine.Networking;
using System.Collections;


public class DataManger : MonoBehaviour
{
	public static void GetTiersData(string continentName, string[] tiersStrings, string[][] allTiersLeagues, List<List<League>> allLeagues, List<League> leagues, int n = 0)
	{
		foreach (string leagueName in allTiersLeagues[n])
		{
			string path = Path.Combine(continentName, Continent.GetCountryByLeague(leagueName), tiersStrings[n], leagueName, leagueName);
			League league = new League(leagueName);

			List<Club> clubs = Club.GetClubsData(GetTextFile(path).text);
			league.Clubs = clubs;

			allLeagues[n].Add(league);
			leagues.Add(league);

		}
		if (n < tiersStrings.Length - 1) GetTiersData(continentName, tiersStrings, allTiersLeagues, allLeagues, leagues, ++n);
	}
	public static void GetSingleTierData(string continentName, string tierString, string[] allLeaguesNames, List<League> leagues)
	{
		foreach (string leagueName in allLeaguesNames)
		{
			string path = Path.Combine(continentName, Continent.GetCountryByLeague(leagueName), tierString, leagueName, leagueName);
			League league = new League(leagueName);

			List<Club> clubs = Club.GetClubsData(GetTextFile(path).text);
			league.Clubs = clubs;

			leagues.Add(league);
		}
	}

	private static TextAsset GetTextFile(string path) => Resources.Load<TextAsset>(path);
}