using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    
    [SerializeField] private GameObject pausePanel;    
                     private bool       isPaused = false;


    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ChangePause();
        }

    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneController.Instance.SwitchToSceneHandler("TitleScreen");
    }
}
