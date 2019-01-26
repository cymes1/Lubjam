using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionChamber : Chamber
{
    public GameObject dialogmenu;

    public void OnStartExpeditionButton()
    {
        Debug.Log("Start expedition");
        dialogmenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Choose1Button()
    {
        //cos
        dialogmenu.SetActive(false);
    }

    public void Choose2Button()
    {
        //cos
        dialogmenu.SetActive(false);
    }

    public void ReturnButton()
    {
        Time.timeScale = 1;
        dialogmenu.SetActive(false);
    }
}
