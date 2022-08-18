using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDirection : MonoBehaviour
{
                      private PlayerMain mainScript;

    [SerializeField]  private int        currentDir = 1;
    [HideInInspector] public  int        CurrentDir { get { return currentDir; } set { currentDir = value; } }
    private void Start()
    {
        mainScript = GetComponentInParent<PlayerMain>();
    }
}
