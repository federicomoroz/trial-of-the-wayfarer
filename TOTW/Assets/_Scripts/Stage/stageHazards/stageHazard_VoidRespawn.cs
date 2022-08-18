using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageHazard_VoidRespawn : stageHazard
{
    private BoxCollider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
        DisableCollider();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DisableCollider();
        }
    }

    private void DisableCollider()
    {
        myCollider.enabled = false;
    }
}
