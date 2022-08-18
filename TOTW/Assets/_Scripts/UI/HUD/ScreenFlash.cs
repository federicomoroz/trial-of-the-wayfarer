using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlash : MonoBehaviour
{

                     private Animator myAnimator;
    [SerializeField] private bool     canFlash = true;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void RedFlash()
    {
        if (canFlash == true)
        {
            myAnimator.SetTrigger("redFlash");         
        }
     
    }

    public void SwordHitFlash()
    {
        if (canFlash == true)
        {
            myAnimator.SetTrigger("swordHitFlash");
        }
       
    }


    
}
