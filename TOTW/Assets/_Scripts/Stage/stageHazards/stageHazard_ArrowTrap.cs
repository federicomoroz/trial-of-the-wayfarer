using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum ShootDirection { Right, Down, Left, Up}
public class stageHazard_ArrowTrap : MonoBehaviour
{
    [SerializeField] private ShootDirection shootDir;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float      shootDelay = 0.3f;   
    private bool canShoot = true;

                   
       

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && canShoot && arrow != null)
        {
            canShoot = false;
            StartCoroutine(ShootCo(shootDir));
           
        }
    }

    private IEnumerator ShootCo(ShootDirection direction)
    {
        yield return new WaitForSeconds(shootDelay);
        arrow?.GetComponent<stageHazard_Arrow>().Shoot(direction);
    }


}
