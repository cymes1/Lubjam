using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpeditionDialog : MonoBehaviour
{
    public GameObject expeditionPrefab;
    public Transform expeditionSpawnPoint;
    public GameMaster gameMaster;
    public Slider slider;
    public Text numberSliderText;

    public int antAmount=1;


    public int changeAmount = 0;

    public float Variable { get; set; }


    public void Start()
    {
        numberSliderText.text = "Ants amount: " + antAmount.ToString();
        slider.maxValue = gameMaster.AntLimit;
        slider.minValue = 1;
    }

    public void Update()
    {
        Debug.Log(Variable);
        numberSliderText.text = "Ants amount: " + antAmount.ToString();
        slider.maxValue = gameMaster.AntLimit;
    }

    public void OnButton1()
    {
        Expedition expedition = Instantiate(expeditionPrefab, expeditionSpawnPoint.position, expeditionSpawnPoint.rotation).GetComponent<Expedition>();
        expedition.Init(Expedition.LootType.Food, antAmount, 10, gameMaster);
        Hide();
    }

    public void OnButton2()
    {
        Expedition expedition = Instantiate(expeditionPrefab, expeditionSpawnPoint.position, expeditionSpawnPoint.rotation).GetComponent<Expedition>();
        expedition.Init(Expedition.LootType.Resource, antAmount, 10, gameMaster);
        Hide();
    }

    public void Slider_Change(int change)
    {
        antAmount = change;
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
