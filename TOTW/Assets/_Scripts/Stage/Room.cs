using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;

    [Header("Room Name parameters")]
    [SerializeField] private bool          needText;
    [SerializeField] private string        placeName = "Place name";
                     private GameObject    text;
                     private Text          placeText;

    [Header("Room elements")]    
    [SerializeField] private GameObject[]  breakables;

   

    protected virtual void Start()
    {
        text = GameObject.FindGameObjectWithTag("RoomText");
        placeText = text.GetComponent<Text>();        
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)  // Preguntando si no es trigger, se elige el collider físico y no el de recibir daño.
        {
            print("Player entered room");
            virtualCam.SetActive(true);
            TurnEverythingOn();
            if (needText)
            {
                RoomText();
            }
      
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            print("Player left room");
            virtualCam.SetActive(false);
            TurnEverythingOff();
            
        }
    }

    protected void RoomText()
    {
        placeText.text = placeName;
        text.GetComponent<Animator>().SetTrigger("ShowText");
    }

    protected void TurnEverythingOn()
    {
        
        ChangeStatusList(breakables, true);

    
    }

    protected void TurnEverythingOff()
    {
        
        ChangeStatusList(breakables, false);

  
    }
    protected void ChangeStatusList(GameObject[] array, bool status)
    {
        for (int i = 0; i < array.Length; i++)
        {
            ChangeStatus(array[i], status);
        }        
    }    

    protected void ChangeStatus(GameObject component, bool status)
    {
        component.gameObject.SetActive(status);
    }

}
