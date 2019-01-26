using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyChamber : Chamber
{
    public int supplyAmount;

    void Start()
    {
        gameMaster.AntLimit += supplyAmount;
    }
}
