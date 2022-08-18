using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointLight : MonoBehaviour
{
    private GameObject Player;
    
    void Start()
    {
        Player = GameObject.Find("Player");
        this.transform.parent = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
