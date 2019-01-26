using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    public bool ispausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ispausa == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            ispausa = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispausa == true)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            ispausa = false;
        }
    }

    public void enterpausa()
    {
        if(ispausa)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            ispausa = false;
        }
        else if(!ispausa)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            ispausa = true;
        } 
    }

    public void resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void retmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void end()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
