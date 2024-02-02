using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject playerUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             Pause();
        }
    }


    public void Resume()
    {
        pauseUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        pauseUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
    }
}
