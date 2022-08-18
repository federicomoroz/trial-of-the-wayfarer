using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
                     public static MusicManager Instance;
    [SerializeField] private       AudioClip[]  trackList;
    [SerializeField] private       AudioSource  myAudio;
                     private       Animator     myAnimator;
    [HideInInspector] public       Animator     MyAnimator { get { return myAnimator; } set { myAnimator = value; } }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        myAudio    = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();   

    }

    public void PlayMusicClip(int index, bool isLoop)
    {
        if (myAudio.isPlaying) 
        {
            StopMusic();
        }

        if (isLoop)
        {
            myAudio.loop = true;
        }
        else
        {
            myAudio.loop = false;
        }
        //myAnimator.SetTrigger("FadeIn");
        myAudio.clip = trackList[index];
      
        myAudio.Play();
    }

    public void FadeOutMusic()
    {
        myAnimator.SetTrigger("FadeOut");
    }

    public void StopMusic()
    {
        myAudio.Stop();
    }
    


  
}
