using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChanger_BlackScreen : MonoBehaviour
{

    private Animator myAnimator;
    
    
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void FadeToScreen()
    {
        myAnimator.SetTrigger("FadeIn");
    }

    public void FadeToBlack()
    {
        myAnimator.SetTrigger("FadeOut");
    }

}
