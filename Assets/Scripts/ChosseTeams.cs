using UnityEngine;
using System.Collections.Generic;
using FootBall;

public class ChosseTeams : MonoBehaviour
{
    public Texture unknownTeamTexture;

    [Header("Team")]
    public Transform firstTeam;
    public Transform secondTeam;

    private Club lastFirstTeam;
    private Club lastSecondTeam;

    private Club firstClub;
    private Club secondClub;

    private League league1;
    private League league2;

    private OptionsManger optionsManger;

    int roll = -1;
    float timer = 0;
    float delayTimer = 0;
    float maxDelayTime = 0.075f;

    private void Start()
    {
        optionsManger = GetComponent<OptionsManger>();
    }

    public void Update()
    {
        if (roll == 0)
        {
            if (delayTimer >= maxDelayTime)
            {
                firstClub.SetTeamATT(firstTeam, Random.Range(50, 99));
                secondClub.SetTeamATT(secondTeam, Random.Range(50, 99));
                delayTimer = 0;
            }

            delayTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= 1.5)
            {
                roll++;
                timer = 0;
                delayTimer = 0;

                firstClub.SetTeamATT(firstTeam, firstClub.Attack);
                secondClub.SetTeamATT(secondTeam, secondClub.Attack);
            }
        }
        else if (roll == 1)
        {
            if (delayTimer >= maxDelayTime)
            {
                firstClub.SetTeamMID(firstTeam, Random.Range(50, 99));
                secondClub.SetTeamMID(secondTeam, Random.Range(50, 99));
                delayTimer = 0;
            }

            delayTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= 1.5)
            {
                roll++;
                timer = 0;
                delayTimer = 0;

                firstClub.SetTeamMID(firstTeam, firstClub.Mid);
                secondClub.SetTeamMID(secondTeam, secondClub.Mid);
            }
        }
        else if (roll == 2)
        {
            if (delayTimer >= maxDelayTime)
            {
                firstClub.SetTeamDEF(firstTeam, Random.Range(50, 99));
                secondClub.SetTeamDEF(secondTeam, Random.Range(50, 99));
                delayTimer = 0;
            }

            delayTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= 1.5)
            {
                roll++;
                timer = 0;
                delayTimer = 0;

                firstClub.SetTeamDEF(firstTeam, firstClub.Defense);
                secondClub.SetTeamDEF(secondTeam, secondClub.Defense);
            }
        }
        else if (roll == 3)
        {
            if (delayTimer >= maxDelayTime)
            {
                firstClub.SetTeamOVR(firstTeam, Random.Range(50, 99));
                secondClub.SetTeamOVR(secondTeam, Random.Range(50, 99));
                delayTimer = 0;
            }

            delayTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= 1.5)
            {
                roll++;
                timer = 0;
                delayTimer = 0;

                firstClub.SetTeamOVR(firstTeam, firstClub.OverAll);
                secondClub.SetTeamOVR(secondTeam, secondClub.OverAll);


            }
        }
        else if (roll == 4)
		{
            if (delayTimer >= maxDelayTime)
            {
                Texture randomTexture1 = Resources.Load<Texture>(league1[Random.Range(0, league1.Clubs.Count)].TeamLogoPath);
                firstClub.SetTeamLogo(firstTeam, unknownTeamTexture, randomTexture1);

                Texture randomTexture2 = Resources.Load<Texture>(league2[Random.Range(0, league2.Clubs.Count)].TeamLogoPath);
                secondClub.SetTeamLogo(secondTeam, unknownTeamTexture, randomTexture2);

                delayTimer = 0;
            }

            delayTimer += Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= 1.5)
            {
                roll = -1;
                timer = 0;
                delayTimer = 0;

                Texture firstClubTexture = Resources.Load<Texture>(firstClub.TeamLogoPath);
                firstClub.SetTeamLogo(firstTeam, unknownTeamTexture, firstClubTexture);
                firstClub.SetTeamLeague(firstTeam);

                Texture secondClubTexture = Resources.Load<Texture>(secondClub.TeamLogoPath);
                secondClub.SetTeamLogo(secondTeam, unknownTeamTexture, secondClubTexture);
                secondClub.SetTeamLeague(secondTeam);

                optionsManger.optionsButton.gameObject.SetActive(true);
            }

        }
    }

    public void Roll()
    {
        if (roll != -1) return;

        if (firstClub is not null)
        {
            firstClub.ResetInfo(firstTeam, unknownTeamTexture);
            secondClub.ResetInfo(secondTeam, unknownTeamTexture);
        }

        List<League> leagues = optionsManger.GetLeagues();

        optionsManger.SetPlayersLeagues(ref league1, ref league2, leagues);

        firstClub = optionsManger.GetClub(league1, lastFirstTeam);
        secondClub = optionsManger.GetClub(league2, lastSecondTeam, firstClub, leagues);

        if (optionsManger.togglePlayAnimation.isOn)
        {
			roll = 0;
            optionsManger.optionsButton.gameObject.SetActive(false);
		}
        else
		{
            firstClub.GiveTeamsInfo(firstTeam, unknownTeamTexture);
            secondClub.GiveTeamsInfo(secondTeam, unknownTeamTexture);
        }

        lastFirstTeam = firstClub;
        lastSecondTeam = secondClub;
    }
}