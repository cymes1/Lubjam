using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChamber : Chamber
{
    public int supplyAmount;
    public int workerPrice;
    public int warriorPrice;
    public int knightPrice;

    void Start()
    {
        gameMaster.AntLimit += supplyAmount;
    }

    public void OnWorkerButton()
    {
        if(gameMaster.Food >= workerPrice)
            gameMaster.WorkerCount++;
    }

    public void OnWarriorButton()
    {
        if(gameMaster.Food >= warriorPrice)
            gameMaster.WarriorCount++;
    }

    public void OnKnightButton()
    {
        if(gameMaster.Food >= knightPrice)
            gameMaster.KnightCount++;
    }
}
