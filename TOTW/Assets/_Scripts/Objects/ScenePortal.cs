using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScenePortal : MonoBehaviour
{
                     protected AudioSource    myAudio;
                     protected SpriteRenderer mySr;
    [SerializeField] protected AudioClip      portalSfx;
    [SerializeField] protected string         sceneToLoad;
    [SerializeField] protected Vector2        playerPosition;
    [SerializeField] protected VectorValue    playerLastPosition;
                     protected bool           isAble = true;
        

    protected virtual void Start()
    {
        myAudio = GetComponent<AudioSource>();
        mySr    = GetComponentInChildren<SpriteRenderer>();
        mySr.enabled = true;
        isAble = true;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isAble)
        {
            isAble = false;
            playerLastPosition.initialValue = playerPosition;
            if (portalSfx != null) 
                { 
                    if(mySr != null) 
                    {
                        mySr.enabled = false;
                    }
                    myAudio.PlayOneShot(portalSfx); 
                }
            SceneController.Instance.SwitchToSceneHandler(sceneToLoad);
        }
    }

}
