using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSwingBehaviour : MonoBehaviour
{
                      private float                 lifeTimeCurrent;
    [SerializeField]  private float                 lifeTime         = 0.5f;
                      private float                 lifeTimeCollider = 0.3f;                   // Este parámetro representa la proproción del lifeTime en la que el collider va a estar activo. En este caso, el collider va a estar activo durante el 30% del LifeTime.
    [SerializeField]  private float                 damagePower      = 10;
    [HideInInspector] public  float                 DamagePower { get { return damagePower; } set { damagePower = value; } }      
                      private PolygonCollider2D     myCollider;
                      private bool                  onceHit          = false;                  // Este bool se asegura que el swing sólo colisione 1 vez
    [SerializeField]  private Signal                foeHitSignal;
    [SerializeField]  private ParticleSystem        hitVfx;
    [SerializeField]  private AudioClip[]           swingSfx;
    [SerializeField]  private AudioClip             hitSfx;
                      private AudioSource           myAudio;
    
    void Start()
    {
        TimerReset();
        myAudio    = GetComponent<AudioSource>();
        myCollider = GetComponent<PolygonCollider2D>();
        myAudio.PlayOneShot(swingSfx[Random.Range(0, swingSfx.Length)]);
       
    }        

    void Update()
    {        
        Timer();       
    }

    private void Timer()
    {
        lifeTimeCurrent -= Time.deltaTime;
        float lifeTimeWithoutCollider = 1 - lifeTimeCollider;                            // Esta variable obtiene el % de tiempo de lifeTime en donde no va a haber collider.
        if (lifeTimeCurrent <= lifeTime * lifeTimeWithoutCollider)                                                                    
        {
            Destroy(myCollider);
            if (lifeTimeCurrent <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void TimerReset()
    {
        lifeTimeCurrent = lifeTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(onceHit == false)
        {
            if (other.CompareTag("Foe") || other.CompareTag("breakableObject") )
            {
                onceHit = true;
                if (other.CompareTag("Foe"))
                {
                    // Al colisionar el swing con un enemigo, manda la señal, crea una variable con la posición del punto de colisión, mueve el efecto de impacto a esa posición y le da play.
                    print("contact with foe");
                    foeHitSignal.Raise();
                    var collisionPoint = other.ClosestPoint(transform.position);
                    print("collisionPoint" + collisionPoint);
                    hitVfx.transform.SetPositionAndRotation(collisionPoint, this.transform.rotation);
                    hitVfx.Play();
                    myAudio.PlayOneShot(hitSfx);
                   
                }

                Destroy(myCollider);                                                          //Al impactar con un enemigo u objecto destruíble, se destruye el collider del swing para evitar múltiples golpes.       
        }

        }
    }

}
