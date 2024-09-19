using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused;

    void Start()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else if (!isPaused) {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        if (!isPaused) {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void ResumeGame() {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void QuitGame() {
        Save.SaveGame();
        Application.Quit();
    }
}