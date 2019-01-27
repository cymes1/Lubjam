using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void credits()
    {
        SceneManager.LoadScene(2);
    }

    public void retMainMenu()
    {
        Debug.Log("Exit eloelo");
        SceneManager.LoadScene(0);
    }

   public void exit()
    {
        Application.Quit();
    }
}
