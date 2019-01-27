using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public GameMaster gameMaster;
    private int timetoend_number = 0;
    private float elapsedTime;

    public Text feedingtime;
    public Text timetoend;
    public Text resources;
    public Text ants;

    public float fullFeedingTime;

    void Start()
    {
        elapsedTime = fullFeedingTime;
    }

    public float getelapsedtime()
    {
        return elapsedTime;
    }

    void Update()
    {
        elapsedTime -= Time.deltaTime;
        if(elapsedTime < 0)
            elapsedTime = 0;

        feedingtime.text = Mathf.Round(elapsedTime).ToString();
        timetoend.text = timetoend_number.ToString();
        resources.text =gameMaster.Resource.ToString();
        ants.text =gameMaster.AntCount + " / " + gameMaster.AntLimit;

        if(elapsedTime == 0)
            FeedAnts();
    }

    private void FeedAnts()
    {
        if(gameMaster.Food < gameMaster.AntCount)
        {
            int hungryAntCount = gameMaster.AntCount - gameMaster.Food;
            for(int i = 0; i < hungryAntCount; i++)
                KillRandomAnt();
            gameMaster.Food = 0;
        } else
        {
            gameMaster.Food -= gameMaster.AntCount;
        }

        elapsedTime = fullFeedingTime;
    }

    private void KillRandomAnt()
    {
        switch(Random.Range(0, 3))
        {
            case 0:
                gameMaster.WorkerCount--;
                break;

            case 1:
                gameMaster.WarriorCount--;
                break;

            default:
                gameMaster.KnightCount--;
                break;
        }
    }
}
