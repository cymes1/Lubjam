using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceRespawner : MonoBehaviour
{
    public GameObject worker,
                      warrior,
                      knight,
                      gameMaster;
    
    public int antWarriorLimit = 6;
    public float startTimeToResp = 0f;
    public float finishTimeToResp = 1f;

    private int antWarriorCount=0;
    private bool startTimer = false;
    private int workerCount;
    private int warriorCount;
    private int knightCount;

    public int GetAntWorriorCount()
    {
        return antWarriorCount;
    }

    public void SetAntWorriorCount(int newAntWorriorCount)
    {
        antWarriorCount = newAntWorriorCount;
    }

    private void Start()
    {
        antWarriorCount = 0;
        startTimer = false;
        
    }

    private void Update()
    {
        workerCount = gameMaster.GetComponent<GameMaster>().WorkerCount;
        warriorCount = gameMaster.GetComponent<GameMaster>().WarriorCount;
        knightCount = gameMaster.GetComponent<GameMaster>().KnightCount;
        //Debug.Log(workerCount + " " + warriorCount + " " + knightCount);
        if (startTimer)
        {
            startTimeToResp += Time.deltaTime;
            if (startTimeToResp >= finishTimeToResp)
            {
                startTimeToResp = 0;
                startTimer = false;
            }
        }
    }

    public void WorkerRespawn()
    {
        if (antWarriorCount < antWarriorLimit && !startTimer && workerCount >= 1)
        {
            startTimer = true;
            Instantiate(worker, new Vector3(0, 0, 0), Quaternion.identity);
            antWarriorCount++;
         }
    }

    public void WarriorRespawn()
    {
        if (antWarriorCount < antWarriorLimit && !startTimer && warriorCount >= 1)
        {
            startTimer = true;
            Instantiate(warrior, new Vector3(0, 0, 0), Quaternion.identity);
            antWarriorCount++;
        }
    }

    public void KnightRespawn()
    {
        if (antWarriorCount < antWarriorLimit && !startTimer && knightCount >= 1)
        {
            startTimer = true;
            Instantiate(knight, new Vector3(0, 0, 0), Quaternion.identity);
            antWarriorCount++;
        }
    }
}
