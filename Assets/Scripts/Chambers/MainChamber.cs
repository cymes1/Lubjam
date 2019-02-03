using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChamber : SupplyChamber
{
    public int workerPrice;
    public int warriorPrice;
    public int knightPrice;

    void Start()
    {
        gameMaster.AntLimit += supplyAmount;
    }

    public void OnWorkerButton()
    {
        if(gameMaster.AntCount >= gameMaster.AntLimit)
        {
            Debug.Log("You must construct additional pylons");
            return;
        }
        if(gameMaster.Food < workerPrice)
        {
            Debug.Log("Not enough minerals");
            return;
        }

        gameMaster.Food -= workerPrice;
        gameMaster.WorkerCount++;
    }

    public void OnWarriorButton()
    {
        if(gameMaster.AntCount >= gameMaster.AntLimit)
        {
            Debug.Log("You must construct additional pylons");
            return;
        }
        if(gameMaster.Food < warriorPrice)
        {
            Debug.Log("Not enough minerals");
            return;
        }

        gameMaster.Food -= warriorPrice;
        gameMaster.WarriorCount++;
    }

    public void OnKnightButton()
    {
        if(gameMaster.AntCount >= gameMaster.AntLimit)
        {
            Debug.Log("You must construct additional pylons");
            return;
        }
        if(gameMaster.Food < knightPrice)
        {
            Debug.Log("Not enough minerals");
            return;
        }
        
        gameMaster.Food -= knightPrice;
        gameMaster.KnightCount++;
    }
}
