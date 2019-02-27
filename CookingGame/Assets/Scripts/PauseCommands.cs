using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCommands : MonoBehaviour
{
    public GameObject pauseMenu;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        AudioListener.volume = 1;
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
