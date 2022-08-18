using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageHazard_Void : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private float coyoteJumpTime = 0.2f;
    [Header("Signal")]   
    private bool playerOnTop = false;

    private void Update()
    {
        if (playerOnTop)
        {
            coyoteJumpTime -= Time.deltaTime;
            if(coyoteJumpTime <= 0)
            {
                coyoteJumpTime = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.transform.parent == null)
        {
            playerOnTop = true;
            if(coyoteJumpTime <= 0)
            {
                MovePlayerToPoint(other.transform);

            }
        }
        else
        {
            playerOnTop = false;
            print("PlayerOffVoid");
            RestartTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerOnTop = false;
            RestartTimer();
        }
    }

    private void RestartTimer()
    {
        coyoteJumpTime = 0.2f;
    }

    private void MovePlayerToPoint(Transform other)
    {
        ActivateDamageCollider();
        other.transform.position = respawnPoint.transform.position;
    }

    private void ActivateDamageCollider()
    {
        respawnPoint.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
