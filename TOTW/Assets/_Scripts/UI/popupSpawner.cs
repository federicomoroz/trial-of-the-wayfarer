using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupSpawner : MonoBehaviour
{
    [SerializeField]  private GameObject popup;
    [HideInInspector] public  GameObject Popup { get { return popup; } set { popup = value; } }
     
    public void makePopup(float hp) 
    {
        GameObject newPopup = Instantiate(popup, transform.position, transform.rotation);
        newPopup.GetComponent<DamagePopup>().SetValue(hp);
    }


}
