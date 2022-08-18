using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSfx : MonoBehaviour
{
    private AudioSource myAudio;
    [SerializeField] private AudioClip footstepSfx;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayFootstepSfx()
    {
        myAudio.Stop();
        myAudio.PlayOneShot(footstepSfx);           
    }


}
