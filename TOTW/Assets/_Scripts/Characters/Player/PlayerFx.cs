using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
    private PlayerMain mainScript;

    [SerializeField] private AudioSource    myAudio;
    [SerializeField] private AudioClip[]    attack;  
    [SerializeField] private AudioClip[]    hurt;
    [SerializeField] private float          masterVolume = 0.85f;
    [SerializeField] private GameObject     hitFx;
    [SerializeField] private GameObject     healFx;
    [SerializeField] private Transform      spawnPoint;

    public void VoiceAttack(int index)
    {
        print("Voice attack");   
        myAudio.PlayOneShot(attack[index], masterVolume);
    }

    public void VoiceHurt()
    {
        myAudio.PlayOneShot(hurt[Random.Range(0, hurt.Length)], masterVolume);
    }

    public void HitFx()
    {
        Instantiate(hitFx, transform.position, transform.rotation);
        hitFx.transform.parent = null;
    }

    public void HealFx()
    {

        Instantiate(healFx, spawnPoint.transform.position, spawnPoint.transform.rotation, this.transform);
        
    }






}
