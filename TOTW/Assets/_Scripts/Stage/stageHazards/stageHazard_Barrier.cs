using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageHazard_Barrier : MonoBehaviour
{     
    [Header("Stored Status Value")]
    [SerializeField] private BoolValue storedPressed;

    private void Start()
    {    
        if (storedPressed.runtimeValue)
        {
            this.gameObject.SetActive(!storedPressed.runtimeValue);
        }
    }

}
