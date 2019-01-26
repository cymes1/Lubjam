using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public GameMaster gameMaster;
    private int fidingtime_number = 0;
    private int timetoend_number = 0;

    public Text fidingtime;
    public Text timetoend;
    public Text feed;
    public Text resources;
    public Text ants;

    void Start()
    {
      
    }

    void Update()
    {
        fidingtime.text = "Feeding time: " + fidingtime_number.ToString();
        timetoend.text = "Time to end expedition: " + timetoend_number.ToString();
        feed.text = "Food: " + gameMaster.Food;
        resources.text = "Resources: " + gameMaster.Resource;
        ants.text = "Ants: " + gameMaster.AntCount + " / " + gameMaster.AntLimit;
    }
}
