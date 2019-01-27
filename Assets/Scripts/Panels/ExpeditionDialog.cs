using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionDialog : MonoBehaviour
{
    public GameObject expeditionPrefab;
    public Transform expeditionSpawnPoint;
    public GameMaster gameMaster;

    public void OnButton1()
    {
        Expedition expedition = Instantiate(expeditionPrefab, expeditionSpawnPoint.position, expeditionSpawnPoint.rotation).GetComponent<Expedition>();
        expedition.Init(Expedition.LootType.Food, 1, 10, gameMaster);
        Hide();
    }

    public void OnButton2()
    {
        Expedition expedition = Instantiate(expeditionPrefab, expeditionSpawnPoint.position, expeditionSpawnPoint.rotation).GetComponent<Expedition>();
        expedition.Init(Expedition.LootType.Resource, 1, 10, gameMaster);
        Hide();
    }

    public void OnExitButton()
    {
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
