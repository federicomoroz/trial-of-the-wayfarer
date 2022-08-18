using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeFx : MonoBehaviour
{
    private PlayerMain mainsScript;
    [SerializeField] private GameObject deathExplosion;    
    [SerializeField] private AudioClip  hurtVoice;
    [SerializeField] private AudioClip  dieVoice;
    private AudioSource myAudio;


    private void Start()
    {
      myAudio = GetComponent<AudioSource>();
    }
    public void OnDeathExplosion()
    {
        Instantiate(deathExplosion, transform.position, transform.rotation);
        deathExplosion.transform.parent = null;
    }

    public void HurtVoice()
    {
      myAudio.PlayOneShot(hurtVoice, 2.5f);
    }

    public void DieVoice()
    {
        myAudio.PlayOneShot(dieVoice);
    }

}
