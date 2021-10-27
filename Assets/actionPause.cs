using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionPause : MonoBehaviour
{
    public static bool pause_check=false;

    [SerializeField] GameObject pauseMenu;

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pause_check = false;
    }
    
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pause_check = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause_check == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
