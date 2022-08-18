using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryKey : MonoBehaviour
{
                     private Animator myAnimator;

    [SerializeField] private GameObject pickedUpVfx;
    [Header("Signal")]
    [SerializeField] private Signal   gotPickedUp;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject vfx = Instantiate(pickedUpVfx, transform.position, transform.rotation);
            vfx.transform.parent = null;
            gotPickedUp?.Raise();
            Destroy(gameObject);
        }
    }


}
