using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    private void Update()
    {
        {if(Input.GetButtonDown("Cancel"))
            BackToMenu();
        }
    }
    public void BackToMenu()
    {
        SceneController.Instance.SwitchToSceneHandler("TitleScreen");
    }

}
