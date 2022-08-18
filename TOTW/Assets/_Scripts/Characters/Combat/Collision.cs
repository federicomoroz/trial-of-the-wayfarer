using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Collision : MonoBehaviour
{
    //Esta clase es heredada por todos los personajes y les permite acceder al rebote al ocurrir una colisión de interés.

    [SerializeField]  private float                    knockbackThrust;
    [HideInInspector] public  float                    KnockbackThrust { get { return knockbackThrust; } set { knockbackThrust = value; } }

    [SerializeField]  private float                    knockbackTime;
    [HideInInspector] public  float                    KnockbackTime   { get { return knockbackTime;   } set { knockbackTime = value;   } }

    [SerializeField]  private CinemachineImpulseSource impulse;

    private void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
    }


    // La corrutina de knockback recibe como parámetro el rb del objeto que va a rebotar, su propio transform y el transform del objeto con el que colisionó
    public IEnumerator KnockbackCo(Rigidbody2D myRb, Transform myTransform, Transform otherTransform)
    {
        print("Main KnockbackCO works fine.");
        CamShake();
        Vector2 distanceDifference = myTransform.position - otherTransform.position;         
        distanceDifference         = distanceDifference.normalized * KnockbackThrust;
        myRb.AddForce(distanceDifference, ForceMode2D.Impulse);
        yield return new WaitForSeconds(KnockbackTime);
        myRb.velocity              = Vector2.zero;
    }

    private void CamShake()
    {
        print("CamShake is working.");
        impulse.GenerateImpulse(4f);                        // Nota: Parametrizar la fuerza del impulso para generar distintas intensidades de shake según haga falta.
    }

}
