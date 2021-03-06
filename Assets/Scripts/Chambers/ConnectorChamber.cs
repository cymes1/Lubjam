﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorChamber : SupplyChamber
{
    public int level;
    public int price;
    public GameObject leftSpawnPoint;
    public GameObject rightSpawnPoint;
    public GameObject unlockButton;
    public GameObject connectorChamberPrefab;
    public Transform connectorChamberSpawnPoint;

    private bool isUnlocked;
    private int leftCount;
    private int rightCount;

    void Start()
    {
        gameMaster.AntLimit += supplyAmount;
    }

    public void Unlock()
    {
        if(gameMaster.Resource >= price)
        {
            gameMaster.Resource -= price;
            Instantiate(connectorChamberPrefab, connectorChamberSpawnPoint.position, Quaternion.identity);

            
            isUnlocked = true;
            leftSpawnPoint.SetActive(true);
            rightSpawnPoint.SetActive(true);
            Destroy(unlockButton);

        }
    }

    public void OnBuild(int dir)
    {
        if(dir < 0)
        {
            leftCount++;
            if(leftCount >= leftSpawnPoint.GetComponent<BuildPoint>().chambersLimit)
                Destroy(leftSpawnPoint);
        } else
        {
            rightCount++;
            if(rightCount >= rightSpawnPoint.GetComponent<BuildPoint>().chambersLimit)
                Destroy(rightSpawnPoint);
        }
    }
}
