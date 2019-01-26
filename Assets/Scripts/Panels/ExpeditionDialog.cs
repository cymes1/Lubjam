using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpeditionDialog : MonoBehaviour
{
    public void OnButton1()
    {
        Debug.Log("OnButton1");
    }

    public void OnButton2()
    {
        Debug.Log("OnButton2");
    }

    public void OnExitButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
