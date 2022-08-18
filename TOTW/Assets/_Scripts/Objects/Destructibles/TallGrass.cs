using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGrass : DestructibleObject
{
    private bool isCut = false;
    protected override void OnBreak()
    {
        base.OnBreak();
        if (!isCut)
        {
            StartCoroutine(DestroyCo());
        }

    }
    private IEnumerator DestroyCo()
    {
        myAnimator.SetTrigger("Cut");
        myAudio.PlayOneShot(breakSfx);
        Destroy(myRb);
        isCut = true;        
        yield return null;
        
    }
}
