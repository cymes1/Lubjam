using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorChamber : Chamber
{
    public int level;
    public int price;
    public GameObject leftSpawnPoint;
    public GameObject rightSpawnPoint;
    public GameObject connectorChamberPrefab;
    public Transform connectorChamberSpawnPoint;

    private bool isUnlocked;

    public void Unlock()
    {
        //if(gameMaster.Resource >= price)
        //{
            isUnlocked = true;
            leftSpawnPoint.SetActive(true);
            rightSpawnPoint.SetActive(true);

            Instantiate(connectorChamberPrefab, connectorChamberSpawnPoint.position, Quaternion.identity);
        //}
    }
}
