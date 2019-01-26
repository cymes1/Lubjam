using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    private int fidingtime_number = 0;
    private int timetoend_number = 0;
    private int feed_number = 0;
    private int resource_number = 0;
    private int ants_number = 0;

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
        fidingtime.text = "Fiding time: " + fidingtime_number.ToString();
        timetoend.text = "Time to end expedition: " + timetoend_number.ToString();
        feed.text = "Feed: " + feed_number.ToString();
        resources.text = "Resources: " + resource_number.ToString();
        ants.text = "Ants: " + ants_number.ToString();
    }
}
