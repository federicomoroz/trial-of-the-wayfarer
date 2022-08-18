using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
                      private Animator    myAnimator;
    [HideInInspector] public  Animator    MyAnimator { get { return myAnimator; } set { myAnimator = value; } }



    private void Update()
    {

    }
    private void Start()
    {
        myAnimator = GetComponent<Animator>();  
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DestroyPowerup();
        }
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);

    }



}
