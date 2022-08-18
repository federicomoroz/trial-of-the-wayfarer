using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : DestructibleObject
{
    private float timeToDestroy = 0.5f;
    protected override void OnBreak()
    {
        base.OnBreak();
        StartCoroutine(DestroyCo());

    }
    private IEnumerator DestroyCo()
    {
        myAnimator.SetBool("isHit", true);
        myAudio.PlayOneShot(breakSfx);
        Destroy(myRb);
        yield return new WaitForSeconds(timeToDestroy);
        myAnimator.SetBool("isHit", false);
        myAnimator.SetTrigger("Reset");
        gameObject.SetActive(false);
    }
}
