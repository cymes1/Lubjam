using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenterChamber : Chamber
{
    public void OnWorkerButton()
    {
        if(gameMaster.WorkerCount > 0)
            gameMaster.WorkerCount--;
    }

    public void OnWarriorButton()
    {
        if(gameMaster.WarriorCount > 0)
            gameMaster.WarriorCount--;
    }

    public void OnKnightButton()
    {
        if(gameMaster.KnightCount > 0)
            gameMaster.KnightCount--;
    }
}
