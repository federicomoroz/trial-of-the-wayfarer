using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
                     protected   Animator       myAnimator;
                     protected   AudioSource    myAudio;        
                     protected   Rigidbody2D    myRb;
    [SerializeField] protected   AudioClip      breakSfx;
    [SerializeField] private     ParticleSystem collisionParticleSystem;    
    [SerializeField] private     bool           ableToDestroy = true;
    


    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRb       = GetComponent<Rigidbody2D>();
        myAudio    = GetComponent<AudioSource>();

    }


    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("playerProjectile") && ableToDestroy)
        {
            
            OnBreak();
        }
    }

    protected virtual void OnBreak()
    {

    }

    protected void PlayParticleSystem()
    {
        collisionParticleSystem.Play();
    }




}
