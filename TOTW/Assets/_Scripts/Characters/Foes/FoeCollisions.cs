using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCollisions : Collision
{
    private Foe mainScript;
    private void Start()
    {
        mainScript = GetComponent<Foe>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if( mainScript.StatsManager.CurrentState != FoeState.stagger && mainScript.StatsManager.CurrentState != FoeState.dead)
        {
            if (other.CompareTag("playerProjectile"))
                {
                /*Cuando un enemigo colisiona con un ataque del jugador (sólo melee ahora), activa el GetHurt tomando como referencia la posición
                del jugador (Target) para pasarle al Knockback, no del proyectil que le impactó. De esa forma se siente más genuino el rebote.
                En el caso de agregar proyectiles a distancia debo usar un switch para elegir el transform del proyectil*/
                float damage = other.GetComponent<PlayerAttackSwingBehaviour>().DamagePower;
                StartCoroutine(mainScript.HealthManager.GetHurt(damage, mainScript.MyRb, this.transform, mainScript.StatsManager.Target));
            }

            if (other.CompareTag("stageHazard") && mainScript.StatsManager.CurrentState != FoeState.attack)
            {
                float damage = mainScript.StatsManager.HpCurrent;
                StartCoroutine(mainScript.HealthManager.GetHurt(damage, mainScript.MyRb, this.transform, other.transform));
            }
       
        }
  

    }

    public IEnumerator SetKnockbackCo(Rigidbody2D myRb, Transform myTransform, Transform otherTransform)
    {
        print("Foe's SetKnockbackCo works fine");
        mainScript.StatsManager.ChangeState(FoeState.stagger);
        StartCoroutine(KnockbackCo(myRb, myTransform, otherTransform));
        yield return new WaitForSeconds(KnockbackTime);     
        mainScript.StatsManager.ChangeState(FoeState.idle);
        if (mainScript.StatsManager.HpCurrent <= 0)
        {
            mainScript.HealthManager.OnDeath();
            //Llamando a la función de muerte al final del Knockback hace que el enemigo se muera al terminar el rebote.

        }
    }
}



