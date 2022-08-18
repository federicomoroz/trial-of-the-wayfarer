using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeChaser : Foe
{
    [Header("Areas radiuses")]
    [SerializeField]  private float       chaseRadius;
    [HideInInspector] public  float       ChaseRadius  { get { return chaseRadius;  } set { chaseRadius = value;  } }

    [SerializeField]  private float       attackRadius;
    [HideInInspector] public  float       AttackRadius { get { return attackRadius; } set { attackRadius = value; } }

    [SerializeField]  private bool        isActive = false;
    [HideInInspector] public  bool        IsActive { get { return isActive; } set { isActive = value; } }

                 
    void FixedUpdate()
    {
        if (StatsManager.CurrentState != FoeState.stagger || StatsManager.CurrentState != FoeState.dead)
        {
            CheckDistance();
        }
    }

    private void CheckDistance()
    {
        //Si el objetivo dentro del radio de persecución y fuera del de ataque, lo persigue, sino vuelve a su posición inicial. Si está dentro del de ataque, ataca.
        if((Vector3.Distance(StatsManager.Target.position, this.transform.position) <= ChaseRadius) &&            
            StatsManager.Target.GetComponent<PlayerMain>().StatsManager.CurrentState != PlayerState.interact)
        {
            if (Vector3.Distance(StatsManager.Target.position, this.transform.position) > AttackRadius)
            {            
                ChaseTarget();
            }
            else
            {
                MyAnimator.SetBool("isMoving", false);
                if (AttackController.CanAttack)
                {
                    AttackController.SetAttackCo();           
                }
            }
        }
        else
        {           
            MovementManager.BackToHome();           
        }       
    }
    private void ChaseTarget()
    {
        if (StatsManager.CurrentState == FoeState.idle || StatsManager.CurrentState == FoeState.walk)
        {
            MovementManager.WalkTo(MyRb, this.transform, StatsManager.Target.transform, StatsManager.MoveSpeed);
        }
    }


}
