using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeHealth : MonoBehaviour
{
                     private Foe   mainScript;
    [SerializeField] private float beingHurtTime = 0.3f;
    [SerializeField] private float dyingTime     = 0.46f;

    void Start()
    {
        mainScript = GetComponent<Foe>();      
        StartHealth();
    }

    public void StartHealth()
    {
        print("Enemy HP refilled");
        mainScript.StatsManager.HpCurrent = mainScript.StatsManager.HpMax.initialValue;
        mainScript.MyAnimator.SetBool("isAlive", true);
    }

    

    public IEnumerator GetHurt(float health, Rigidbody2D myRb, Transform myTransform, Transform otherTransform)     
    {
        //La corrutina GetHurt se ocupa de los sucesos de ser lastimado: 1) Activar la función TakeHp para restar vida 2) Activar el Knockback
        TakeHp(health);
        mainScript.HealthBarOn();
        mainScript.MyFx.HurtVoice();
        print($"Foe received {health}hp of damage.");
        StartCoroutine(mainScript.CollisionsManager.SetKnockbackCo(mainScript.MyRb, this.transform, otherTransform));
        yield return new WaitForSeconds(beingHurtTime);
    }
    private void TakeHp(float health)
    {

        mainScript.StatsManager.HpCurrent -= health;
        print($"Foe lost {health}hp. {mainScript.StatsManager.HpCurrent}hp remaining.");
        mainScript.PopupSpawner.GetComponent<popupSpawner>().makePopup(health);
        if (mainScript.StatsManager.HpCurrent < 0)
        {
            mainScript.StatsManager.HpCurrent = 0;
        }
    }

    private void AddHp(float health)
    {
        mainScript.StatsManager.HpCurrent += health;
        print($"Foe gained {health}hp. {mainScript.StatsManager.HpCurrent}hp remaining");
        if (mainScript.StatsManager.HpCurrent > mainScript.StatsManager.HpMax.initialValue)
        {
            mainScript.StatsManager.HpCurrent = mainScript.StatsManager.HpMax.initialValue;
        }
    }

    public void OnDeath()
    {
        print("Enemy died.");
        StopAllCoroutines();
        StartCoroutine(DeathCo());        
        
    }

    private IEnumerator DeathCo()
    {
        print("Enemy died.");
        mainScript.StatsManager.ChangeState(FoeState.dead);
        mainScript.MovementManager.enabled  = false;              
        //mainScript.AttackController.enabled = false;
        mainScript.MyAnimator.SetTrigger("hasDied");
        mainScript.MyAnimator.SetBool("isAlive", false);
        mainScript.MyFx.DieVoice();
        yield return new WaitForSeconds(dyingTime);
        mainScript.MyFx.OnDeathExplosion();
        gameObject.SetActive(false);
       
    }

}
