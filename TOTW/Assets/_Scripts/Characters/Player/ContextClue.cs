using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    private SpriteRenderer mySprite;
    private bool contextActive = false;



    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeContext()
    {
        contextActive = !contextActive;
        if (contextActive == true)
        {
            print("contextClue on");
            mySprite.gameObject.SetActive(true);
        }
        else
        {
            print("ContextClue off");
            mySprite.gameObject.SetActive(false);
        }

    }
}
