using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : ScenePortal
{
    private Animator myAnimator;



    protected override void Start()
    {
        base.Start();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("isOpen", false);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isAble)
        {
            isAble = false;
            playerLastPosition.initialValue = playerPosition;
            myAnimator.SetBool("isOpen", true);
            if (portalSfx != null)
            {
                print("animator bool open");
                
                myAudio.PlayOneShot(portalSfx);
            }
            SceneController.Instance.SwitchToSceneHandler(sceneToLoad);
        }
    }
}
