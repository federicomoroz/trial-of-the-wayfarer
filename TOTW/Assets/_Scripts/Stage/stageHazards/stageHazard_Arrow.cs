using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageHazard_Arrow : stageHazard
{
                     private Rigidbody2D    myRb;
    [SerializeField] private float          shootForce       = 350f;
    [SerializeField] private float          lifeTime         = 2f;
                     private float          currentLifeTime;
                     private bool           isShoot          = false;
                     private AudioSource    myAudio;
    [SerializeField] private AudioClip      shootSfx;
    [SerializeField] private GameObject     hitVfx;

    private void Start()
    {
        myRb            = GetComponent<Rigidbody2D>();
        myAudio         = GetComponent<AudioSource>();
        currentLifeTime = lifeTime;
  
    }

    private void Update()
    {
        if (isShoot)
        {
            currentLifeTime -= Time.deltaTime;
            if (currentLifeTime <= 0)
            {
                DestroyArrow();
            }
        }
    }

    public void Shoot(ShootDirection direction)
    {
        isShoot = true;
        myAudio.PlayOneShot(shootSfx);
        Vector2 shootDir;
        switch (direction)
        {
            case ShootDirection.Right:
                shootDir = Vector2.right;
                break;
            case ShootDirection.Down:
                shootDir = Vector2.down;
                break;
            case ShootDirection.Left:
                shootDir = Vector2.left;
                break;
            case ShootDirection.Up:
                shootDir = Vector2.up;
                break;
            default:
                shootDir = Vector2.right;
                break;
        } 
        myRb.AddForce(shootDir * shootForce * Time.deltaTime, ForceMode2D.Impulse);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ArrowHit();
        }
    }

    private void ArrowHit()
    {
        Instantiate(hitVfx, transform.position, transform.rotation);
        hitVfx.transform.parent = null;
        DestroyArrow();
       

    }

    private void DestroyArrow()
    {
        Destroy(gameObject);
    }


}
