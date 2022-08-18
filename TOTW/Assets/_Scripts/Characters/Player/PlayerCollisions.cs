using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : Collision
{
                     private PlayerMain mainScript;

    void Start()
    {
        mainScript = GetComponent<PlayerMain>();      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        #region Hurting collisions
        if (mainScript.StatsManager.CurrentState != PlayerState.hurt && mainScript.StatsManager.CurrentState != PlayerState.interact && mainScript.StatsManager.CurrentState != PlayerState.dead)                                                                              
        {
            if (other.gameObject.CompareTag("stageHazard") || other.gameObject.CompareTag("Foe") || other.gameObject.CompareTag("foeAttack"))
            {
                StartCoroutine(KnockbackCo(mainScript.MyRb, this.transform, other.transform));                                                      // Primero el knockback.
                int damage = 0;                                                                                                                     // Se genera la variable que va a guardar el daño a aplicar.
                switch (other.gameObject.tag)
                {
                    case ("stageHazard"):
                        print("Player touched a hazard.");
                        damage = other.gameObject.GetComponent<stageHazard>().DamagePower;
                        break;
                    case ("Foe"):                       
                        if(other.GetComponentInChildren<Foe>().StatsManager.CurrentState != FoeState.stagger && other.GetComponentInChildren<Foe>().StatsManager.CurrentState != FoeState.dead)
                        {
                            print("Player collided with a foe.");
                            damage = other.gameObject.GetComponent<Foe>().StatsManager.BaseAttack;
                        }
                        break;
                    case ("foeAttack"):
                        print("Player was attacked by a foe.");
                        damage = other.gameObject.GetComponentInParent<Foe>().StatsManager.BaseAttack;
                        break;
                }
                StartCoroutine(GetHurt(damage));                                                                                                    // Se aplica el daño.
            }
        }
        #endregion
       
        if(mainScript.StatsManager.CurrentState != PlayerState.dead)
        {
            if (other.CompareTag("Healer"))
            {
                mainScript.HealthManager.AddHp(other.gameObject.GetComponent<Healer>().Hp.initialValue);
                }

        }
    }


    private IEnumerator GetHurt(int damage)
    {
        mainScript.StatsManager.ChangeState(PlayerState.hurt);
        mainScript.MyAnimator.SetTrigger("gotHurt");    
        mainScript.HealthManager.TakeHp(damage);
        mainScript.FxController.HitFx();
        yield return new WaitForSeconds(0.2f);        
        mainScript.StatsManager.ChangeState(PlayerState.idle);
    }



}
