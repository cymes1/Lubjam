using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionChamber : Chamber
{
    public GameObject expeditionDialog;

    public void OnStartExpeditionButton()
    {
        expeditionDialog.SetActive(true);
        Time.timeScale = 0;
    }
}
