using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitch : MonoBehaviour
{
                     private Animator     myAnimator;
                     private bool         isPressed;
                     private AudioSource  myAudio;
                     private Sign         mySign;
                    

    [Header("Stored Status Value")]
    [SerializeField] private BoolValue    storedPressed;

    [Header("Delay for Activate")]
    [SerializeField] private float        delayPress = 0.5f;

    [Header("Barriers")]
    [SerializeField] private GameObject[] myBarriers;

    [Header("Audio Fx")]
    [SerializeField] private AudioClip    activateSfx;


    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAudio    = GetComponent<AudioSource>();
        mySign     = GetComponent<Sign>();
        InitializeSwitch();
        EnableSign();     
        
    }

    private void InitializeSwitch()
    {
        isPressed = storedPressed.runtimeValue;

        if (isPressed)
        {
            myAnimator.SetBool("Pressed", true);
        }
        else
        {
            myAnimator.SetBool("Pressed", false);
        }
        UpdateBarriers();
    }

    private void ActivateSwitch()
    {
        isPressed = true;
        storedPressed.runtimeValue = isPressed;       
        myAnimator.SetBool("Pressed", isPressed);
        myAudio.Stop();
        myAudio.PlayOneShot(activateSfx);
        UpdateBarriers();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            StartCoroutine(ActivateSwitchCo());
        }
    }


    private IEnumerator ActivateSwitchCo()
    {
        yield return new WaitForSeconds(delayPress);
        ActivateSwitch();
        yield return new WaitForSeconds(delayPress*2);
        EnableSign();
    }

    private void EnableSign()
    {
        mySign.enabled = isPressed;
    }

    private void UpdateBarriers()
    {

        for (int i = 0; i < myBarriers.Length; i++)
        {
            myBarriers[i].gameObject.SetActive(!isPressed);
        }
    }

}
