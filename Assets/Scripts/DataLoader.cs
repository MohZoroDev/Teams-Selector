using UnityEngine;
using FootBall.FixedInformation;
using System.IO;

public class DataLoader : MonoBehaviour
{
    private void Start()
    {
        //var res = Resources.Load<TextAsset>("Europe\\Romania\\3rd Tier\\SUPERLIGA\\SUPERLIGA");

        //Debug.Log(res.name);
        //return;
		DataManger.GetTiersData(Europe.continentName, Europe.tiersStrings, Europe.allTiersleaguesNamesArrays, Europe.allLeaguesLists, Europe.allLeagues);
        DataManger.GetSingleTierData(Asia.continentName, Asia.tierString, Asia.allLeaguesNames, Asia.allLeagues);
        DataManger.GetSingleTierData(Australia.continentName, Australia.tierString, Australia.allLeaguesNames, Australia.allLeagues);
        DataManger.GetSingleTierData(NorthAmerica.continentName, NorthAmerica.tierString, NorthAmerica.allLeaguesNames, NorthAmerica.allLeagues);
        DataManger.GetSingleTierData(SouthAmerica.continentName, SouthAmerica.tierString, SouthAmerica.allLeaguesNames, SouthAmerica.allLeagues);
        DataManger.GetSingleTierData(RestofWorld.continentName, RestofWorld.tierString, RestofWorld.allLeaguesNames, RestofWorld.allLeagues);

        Continent.allLeagues = Continent.GetAllLeagues();
        Continent.thirdTierLeagues = Continent.GetThirdTierLeagues();
    }
}
