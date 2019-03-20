using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseLogic : MonoBehaviour
{
    public Transform pauseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if (pauseMenu.gameObject.activeInHierarchy == false)
        {
            AudioListener.volume = 0;
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            AudioListener.volume = 1;
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
