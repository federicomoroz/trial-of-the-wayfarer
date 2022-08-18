using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    [SerializeField] private int          probability;


    public void CheckToSpawn()
    {
        print("checking if it will spawn");
        if(Random.Range(0,99) <= probability)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        print("item spawned");
        Instantiate(items[Random.Range(0, items.Length)], transform.position, transform.rotation, null);
                    
    }

    
}
