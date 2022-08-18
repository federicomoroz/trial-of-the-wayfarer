using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class titleScreenMenu : MonoBehaviour
{
    [SerializeField]  private  Animator    myAnimator;    
    [SerializeField]  private  AudioSource myAudio;
    [SerializeField]  private  AudioClip   sfxConfirm;
    [SerializeField]  private  AudioClip   sfxCancel;
    [SerializeField]  private  bool        canPressExit = true;
                      private  bool        isIdle       = true;

    private void Start()
    {
        MusicManager.Instance.StopMusic();
    }


    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Joystick1Button1) || (Input.GetKeyDown(KeyCode.Escape)))
            {
                if (!isIdle)
                {
                    BackToIdle();
                }
                else
                {
                    if (canPressExit)
                    {
                        QuitButton();
                    }
                }
            }       
       
    }

    public void PlayButton()
    {
        StartCoroutine(PlayCO());
    }
    private IEnumerator PlayCO()
    {
        myAnimator.SetTrigger("goToPlay");
        canPressExit = false;
        myAudio.PlayOneShot(sfxConfirm);
        yield return new WaitForSeconds(4f);
        SceneController.Instance.SwitchToSceneHandler("Test");
    }

    public void ControlsButton()
    {
        myAnimator.SetTrigger("enterControls");
        canPressExit = false;
        isIdle = false;
        myAudio.PlayOneShot(sfxConfirm);

    }

    public void CreditsButton()
    {
        myAnimator.SetTrigger("enterCredits");
        canPressExit = false;
        isIdle = false;
        myAudio.PlayOneShot(sfxConfirm);
    }

    public void QuitButton()
    {
        StartCoroutine(QuitCo());
    }

    public void BackToIdle()
    {
        isIdle = true;
        myAnimator.SetTrigger("backIdle");
        myAudio.PlayOneShot(sfxCancel);
        canPressExit = true;
    }

    private IEnumerator QuitCo()
    {
        myAnimator.SetTrigger("exit");        
        myAudio.PlayOneShot(sfxConfirm);
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
