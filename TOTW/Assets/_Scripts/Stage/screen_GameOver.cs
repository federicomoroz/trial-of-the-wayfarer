using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_GameOver : MonoBehaviour
{
    [SerializeField] private int    musicClipIndex = 2;
    [SerializeField] private float timeToGoodBye = 5f;
    [SerializeField] private Signal goodByeSignal;

    private void Start()
    {

        MusicManager.Instance.PlayMusicClip(musicClipIndex, true);
        MusicManager.Instance.MyAnimator.SetTrigger("FadeInLong");
        StartCoroutine(GameOverCO());
    
    }


    private IEnumerator GameOverCO()
    {
        yield return new WaitForSeconds(timeToGoodBye);
        GoodBye();
        yield return new WaitForSeconds(1.5f);
        ReturnToTitle();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            GoodBye();
            ReturnToTitle();
        }
    }


    public void GoodBye()
    {
        goodByeSignal?.Raise();
    }

    public void ReturnToTitle()
    {
        SceneController.Instance.SwitchToSceneHandler("TitleScreen");
    }




}
