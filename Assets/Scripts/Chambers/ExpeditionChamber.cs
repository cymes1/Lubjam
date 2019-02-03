using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionChamber : Chamber
{
    public GameObject expeditionPrefab;
    public Transform expeditionSpawnPoint;

    public void OnStartExpeditionButton()
    {
        if (gameMaster.WorkerCount > 0)
        {
            Expedition expedition = Instantiate(expeditionPrefab, expeditionSpawnPoint.position, expeditionSpawnPoint.rotation).GetComponent<Expedition>();
            expedition.Init(Random.Range(0, 2) == 1 ? Expedition.LootType.Food : Expedition.LootType.Resource, 1, 10, gameMaster);
            gameMaster.WorkerCount--;
        }
    }
}
