using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceRespawner : MonoBehaviour
{
    public GameObject worker,
                      warrior,
                      knight,
                      gameMaster;
    public GameMaster master;
    public Transform warriorSpawnPoint;
    
    public int antWarriorLimit = 6;
    public float startTimeToResp = 0f;
    public float finishTimeToResp = 1f;

    public int antWarriorCount=0;
    private bool startTimer = false;

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
        master = gameMaster.GetComponent<GameMaster>();
    }

    private void Update()
    {
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
        if (antWarriorCount < antWarriorLimit && !startTimer && master.WorkerCount >= 1)
        {
            startTimer = true;
            PlayerUnit unit = Instantiate(worker, warriorSpawnPoint.position + new Vector3(0, 2.5f, 0), warriorSpawnPoint.rotation).GetComponent<PlayerUnit>();
            unit.Init(this.master);
            antWarriorCount++;
         }
    }

    public void WarriorRespawn()
    {
        if (antWarriorCount < antWarriorLimit && !startTimer && master.WarriorCount >= 1)
        {
            startTimer = true;
            PlayerUnit unit = Instantiate(warrior, warriorSpawnPoint.position + new Vector3(0, 2.5f, 0), warriorSpawnPoint.rotation).GetComponent<PlayerUnit>();
            unit.Init(this, master);
            antWarriorCount++;
        }
    }

    public void KnightRespawn()
    {
        if (antWarriorCount < antWarriorLimit && !startTimer && master.KnightCount >= 1)
        {
            startTimer = true;
            PlayerUnit unit = Instantiate(knight, warriorSpawnPoint.position + new Vector3(0, 2.5f, 0), warriorSpawnPoint.rotation).GetComponent<PlayerUnit>();
            unit.Init(this, master);
            antWarriorCount++;
        }
    }
}
