using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
                      private Rigidbody2D myRb;
    [HideInInspector] public  Rigidbody2D MyRb       { get { return myRb;       } set { myRb = value;       } }

                      private Animator    myAnimator;
    [HideInInspector] public  Animator    MyAnimator { get { return myAnimator; } set { myAnimator = value; } }

    [SerializeField]  private GameObject  popupSpawner;
    [HideInInspector] public GameObject   PopupSpawner { get { return popupSpawner; } set { popupSpawner = value; } }


}
