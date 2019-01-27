using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private int food = 1000;
    private int resource = 1000;
    private int workerCount;
    private int warriorCount;
    private int knightCount;
    private int antLimit;
    public Image deathScreen;

    private void Start()
    {
        food = 1000;    resource = 1000;
        deathScreen.enabled = false;
    }

    private void Update()
    {
        if(food<=0 && AntCount<=0)
        {
            deathScreen.enabled = true;
        }
    }

    public int Food
    {
        get { return food;  }
        set { food = value;
        Debug.Log("food: " + food); }
    }
    public int Resource
    {
        get { return resource;  }
        set { resource = value;
        Debug.Log("resource: " + resource); }
    }
    public int WorkerCount
    {
        get { return workerCount;  }
        set { workerCount = value;
        Debug.Log("workerCount: " + workerCount); }
    }
    public int WarriorCount
    {
        get { return warriorCount;  }
        set { warriorCount = value; 
        Debug.Log("warriorCount: " + warriorCount); }
    }
    public int KnightCount
    {
        get { return knightCount;  }
        set { knightCount = value; 
        Debug.Log("knightCount: " + knightCount); }
    }
    public int AntLimit
    {
        get { return antLimit;  }
        set { antLimit = value; 
        Debug.Log("antLimit: " + antLimit); }
    }

    public int AntCount
    {
        get { return workerCount + warriorCount + knightCount; }
    }
}
