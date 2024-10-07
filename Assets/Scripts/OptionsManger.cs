using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using FootBall;
using FootBall.FixedInformation;
using TMPro;

public class OptionsManger : MonoBehaviour
{
    public TMP_InputField searchBox;
    public GameObject item;
    public Transform itemsContainer;
    public RectTransform checkMark;
    public RectTransform scrollBarContent;
    public Transform customInfo;
    public GameObject nextButton;
    public GameObject optionsPage;
    public GameObject teamRollPage;
    public GameObject searchPage;
    public Transform destroyContaniar;
    public GameObject toggleGroup;
    public Button optionsButton;

    [Header("Custom Options")]
    public Toggle highToggle;
    public Toggle mediumToggle;
    public Toggle lowToggle;
    public Toggle randomPowerToggle;
    bool gotAllData = false;

    [Header("Normal Options")]
    public Toggle tier1Toggle;
    public Toggle tier2Toggle;
    public Toggle tier3Toggle;
    public Toggle randomTiersToggle;

    [Header("Options")]
    public Toggle toggleBalanced;
    public Toggle toggleSameLeague;
    public Toggle toggleNewTeams;
    public Toggle togglePlayAnimation;
    public TextMeshProUGUI errorMessage;

    private int startYPostion;
    private int itemsCount;
    private int infoType;
    [HideInInspector] public bool customOn;

    private string[] dataArray = Continent.allContinents;
    private List<string> resultsList = new List<string>();

    public void GetInfoData()
    {
        resultsList = new List<string>(dataArray);
        ShowResults();
    }

    public void Search()
    {
        List<string> res = new List<string>();
        foreach (string str in dataArray)
        {
            if (str.ToLower().Contains(searchBox.text.ToLower()))
                res.Add(str);
        }

        resultsList = res;
        ShowResults();
    }

    public void ShowResults()
    {
        int tmp = itemsCount;

        checkMark.gameObject.SetActive(false);
        scrollBarContent.anchoredPosition = Vector2.zero;

        if (resultsList.Count > itemsCount)
        {
            for (int n = 0; n < resultsList.Count - tmp; n++)
            {
                GameObject x = Instantiate(item, item.transform.parent.Find("Items Container"));
                x.gameObject.SetActive(true);
                x.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, startYPostion - (150 * itemsCount));
                itemsCount++;
            }
        }
        else if (resultsList.Count < itemsCount)
        {
            for (int n = 0; n < tmp - resultsList.Count; n++)
            {
                Destroy(itemsContainer.GetChild(itemsCount - 1).gameObject);
                itemsCount--;
            }
        }
        int i = 0;
        foreach (string str in resultsList)
        {
            itemsContainer.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = str;
            i++;
        }
        PutCheckMark();
    }

    public void PutCheckMark()
    {
        int i = 0;
        bool exit = false;

        foreach (string str in resultsList)
        {
            if (exit) break;

            switch (infoType)
            {
                case 0:
                    if (str == Continent.selectedContinent) exit = true;
                    else if (i == resultsList.Count - 1 && exit == false) return;
                    break;
                case 1:
                    if (str == Continent.selectedCountry) exit = true;
                    else if (i == resultsList.Count - 1 && exit == false) return;
                    break;
                case 2:
                    if (str == Continent.selectedLeague) exit = true;
                    else if (i == resultsList.Count - 1 && exit == false) return;
                    break;
            }
            if (exit == false) i++;
        }

        checkMark.gameObject.SetActive(true);
        checkMark.anchoredPosition = new Vector3(checkMark.anchoredPosition.x, startYPostion - (150 * i));
    }

    public void Select()
    {
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        string selectedButtonText = selectedButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;

        switch (infoType)
        {
            case 0:
                Continent.selectedContinent = selectedButtonText;
                break;
            case 1:
                Continent.selectedCountry = selectedButtonText;
                break;
            case 2:
                Continent.selectedLeague = selectedButtonText;
                break;
        }

        checkMark.gameObject.SetActive(true);
        nextButton.SetActive(true);
        checkMark.anchoredPosition = new Vector2(checkMark.anchoredPosition.x, selectedButton.GetComponent<RectTransform>().anchoredPosition.y);
    }

    public void OnDeselct()
    {
        if (searchBox.text == "")
        {
            searchBox.placeholder.GetComponent<TextMeshProUGUI>().text = "Search Here...";
            resultsList = new List<string>(dataArray);
            itemsCount = resultsList.Count;
        }
    }

    public void FitSize()
    {
        int height = dataArray.Length * 150;
        scrollBarContent.sizeDelta = new Vector2(0, height);

        startYPostion = (height / 2) - 70;
    }

    public void ClearItems()
    {
        itemsCount = 0;
        int length = itemsContainer.childCount;
        GameObject[] items = new GameObject[length];

        for (int i = 0; i < length; i++)
        {
            itemsContainer.GetChild(0).SetParent(destroyContaniar);
            items[i] = destroyContaniar.GetChild(i).gameObject;
            items[i].SetActive(false);
        }

        for (int i = 0; i < length; i++)
        {
            Destroy(items[i]);
        }
    }

    public void ChangeInfoType(int i)
    {
        infoType += i;

        switch (infoType)
        {
            case 0:
                dataArray = Continent.allContinents;
                break;
            case 1:
                dataArray = Continent.GetContinentCountries();
                break;
            case 2:
                dataArray = Continent.GetCountryLeagues();
                break;
        }

        ClearItems();
        FitSize();
        GetInfoData();

        nextButton.SetActive(checkMark.gameObject.activeSelf);
        if (infoType > 2)
        {
            ChangeCustomInfo();
            GoBack(2);
        }
        else if (infoType < 0)
        {
            ChangeCustomInfo("None", "None", "None");
            ForgetSelectedOptions();
            GoBack(0);

            nextButton.SetActive(false);
        }
    }

    public void ChangeCustomInfo()
    {
        customInfo.Find("Continent").Find("Selected Continent").GetComponent<TextMeshProUGUI>().text = ": " + Continent.selectedContinent;
        customInfo.Find("Country").Find("Selected Country").GetComponent<TextMeshProUGUI>().text = ": " + Continent.selectedCountry;
        customInfo.Find("League").Find("Selected League").GetComponent<TextMeshProUGUI>().text = ": " + Continent.selectedLeague;

        gotAllData = true;
    }

    public void ChangeCustomInfo(string continent, string country, string league)
    {
        customInfo.Find("Continent").Find("Selected Continent").GetComponent<TextMeshProUGUI>().text = ": " + continent;
        customInfo.Find("Country").Find("Selected Country").GetComponent<TextMeshProUGUI>().text = ": " + country;
        customInfo.Find("League").Find("Selected League").GetComponent<TextMeshProUGUI>().text = ": " + league;
    }

    public void ChangeButton()
    {
        if (infoType == 2) PutCheckMark();
        FitSize();
        GetInfoData();
    }

    public void GoBack(int n)
    {
        optionsPage.SetActive(true);
        searchPage.SetActive(false);

        searchBox.text = "";
        OnDeselct();
        infoType = n;
    }

    public void ForgetSelectedOptions()
    {
        Continent.selectedContinent = null;
        Continent.selectedCountry = null;
        Continent.selectedLeague = null;
    }

    public void Check()
    {
        customOn = customInfo.gameObject.activeSelf;
        toggleGroup.SetActive(!customOn);
        toggleSameLeague.transform.parent.gameObject.SetActive(!customOn);

        errorMessage.text = "";
    }

    public List<League> GetLeagues()
    {
        if (customOn) return new List<League> { League.GetChossenLeague() };

        if (tier1Toggle.isOn) return Europe.firstTierLeagues;
        else if (tier2Toggle.isOn) return Europe.secondTierLeagues;
        else if (tier3Toggle.isOn) return Continent.thirdTierLeagues;
        else if (randomTiersToggle.isOn) return Continent.allLeagues;

        return null;
	}

    public int GetPowerByTier()
    {
        if (tier1Toggle.isOn) return 1;
        else if (tier2Toggle.isOn) return 2;
        else if (tier3Toggle.isOn) return 3;
        else if (randomTiersToggle.isOn) return 0;

		return -1;
	}

    public void SetPlayersLeagues(ref League league1, ref League league2, List<League> list)
	{
        league1 = League.GetRandomLeague(list);
        league2 = League.GetRandomLeague(list);

        if (toggleSameLeague.isOn && !customOn) league2 = new League(league1);
    }
    public int GetSelectedPower()
	{
        if (randomPowerToggle.isOn) return 0;
        else if (highToggle.isOn) return 1;
        else if (mediumToggle.isOn) return 2;
        else if (lowToggle.isOn) return 3;

        return -1;
	}


    public Club GetClub(League league, Club lastClub)
	{
        List<Club> clubs;
        if (customOn) clubs = League.SeperateClubsByPower(league, GetSelectedPower());
        else clubs = League.SeperateClubsByPower(league, GetPowerByTier());

        if (lastClub is null == false && customOn && toggleNewTeams.isOn) clubs.Remove(lastClub);

        return clubs[Random.Range(0, clubs.Count)];
	}

    public Club GetClub(League league, Club lastClub, Club firstClub, List<League> leaguesList)
    {
        List<Club> clubs;

        if (customOn) clubs = CustomClubs(league, lastClub, firstClub);
        else clubs = NotCustomClubs(league, firstClub, leaguesList);

        return clubs[Random.Range(0, clubs.Count)];
    }

    private List<Club> CustomClubs(League league, Club lastClub, Club firstClub)
	{
        League leag = new League(league);

		if (leag.Name == firstClub.League) leag.Clubs.Remove(firstClub);

		if (toggleNewTeams.isOn) leag.Clubs.Remove(lastClub);

        leag.Clubs = League.SeperateClubsByPower(leag, GetSelectedPower());

        if (toggleBalanced.isOn)
		{
            List<Club> clubs = new List<Club>(leag.GetCLubs(firstClub, 1));

            if (clubs.Count == 0) leag.Clubs = leag.GetClosestClubs(firstClub.OverAll);
			else leag.Clubs = clubs;
		}
        return leag.Clubs;
	}

    private List<Club> NotCustomClubs(League league, Club firstClub, List<League> leaguesList)
	{
        League leag = new League(league);

        if (leag.Name == firstClub.League) leag.Clubs.Remove(firstClub);
		leag.Clubs = League.SeperateClubsByPower(leag, GetPowerByTier());

		if (toggleSameLeague.isOn)
		{
            if (toggleBalanced.isOn)
			{
				List<Club> clubs = leag.GetCLubs(firstClub, 1);

				if (clubs.Count == 0)
                {
                    
					leag.Clubs = leag.GetClosestClubs(firstClub.OverAll);
                    Debug.Log("1");
				}
				else
                {
					leag.Clubs = clubs;
                    Debug.Log("2");
				}
                
			}
		}
        else
		{
            if (toggleBalanced.isOn)
			{
                List<League> list = new List<League>(leaguesList);
                list.Remove(leag);

				List<Club> clubs = leag.GetCLubs(firstClub, 1);
                
				while (clubs.Count == 0 && list.Count > 0)
				{
                    leag = League.GetRandomLeague(list);
                    if (leag.Name == firstClub.League) leag.Clubs.Remove(firstClub);

					leag.Clubs = League.SeperateClubsByPower(leag, GetPowerByTier());
					clubs = leag.GetCLubs(firstClub, 1);
                    list.Remove(leag);
				}

                if (clubs.Count == 0) leag.Clubs = league.GetClosestClubs(firstClub.OverAll);
                else leag.Clubs = clubs;
			}
		}
        return leag.Clubs;
	}

    public void ValidateData()
	{
        if (customOn)
        {
            if (GetSelectedPower() == -1)
			{
                errorMessage.text = "Please choose a valid power";
                return;
            }

            if (gotAllData == false)
			{
                errorMessage.text = "Please choose a valid info";
                return;
			}

        }
        else
        {
            if (!tier1Toggle.isOn && !tier2Toggle.isOn && !tier3Toggle.isOn && !randomTiersToggle.isOn)
			{
                errorMessage.text = "Please choose a valid tier";
                return;
			}
            
        }

        errorMessage.text = "";
        teamRollPage.SetActive(true);
        optionsPage.SetActive(false);
    }
}
