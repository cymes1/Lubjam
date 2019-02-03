using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaft : MonoBehaviour
{
    public GameObject canvas;
    public GameMaster gameMaster;
    public int price;

    public void Build()
    {
        if(gameMaster.Resource >= price)
        {
            gameMaster.Resource -= price;
            gameMaster.AntLimit += 10;
            GetComponent<MeshRenderer>().enabled = false;
            canvas.SetActive(false);
        }
    }
}
