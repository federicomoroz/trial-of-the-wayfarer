using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
                     protected bool   inRange = false;
                     protected bool   isActive = true;
    [Header("Player direction required: 0=Right, 1=Down, 2=Left, 3=Up")]
    [SerializeField] protected int    directionRequired;                                       // Esta variable pide hacia dónde tiene que estar mirando el personaje para activar el interactuable.
    [Header("Signal")]
    [SerializeField] protected Signal playerInRange, playerOutRange;
                                                                                               // 0= Derecha, 1= Abajo, 2= Izquierda, 3= Arriba.

    private void Update()
    {
        if (isActive)
        {
            if (Input.GetButtonDown("Interact") && inRange)
            {
                Activate();
            }

        }
        
    }

    protected virtual void Activate()
    {

    }

    protected virtual void DeActivate()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            if (other.GetComponentInChildren<CurrentDirection>().CurrentDir == directionRequired)  
            {
                if (!inRange)
                {
                    inRange = true;
                    playerInRange?.Raise();
                    print("Player in interactible range.");

                }

            }
            else
            {
                if (inRange)
                {
                    inRange = false;
                    playerOutRange?.Raise();
                    DeActivate();

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            playerOutRange?.Raise();            
            DeActivate();
        }
    }
}
