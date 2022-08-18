using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeAttack : MonoBehaviour
{
                      private Foe   mainScript;
    [SerializeField]  private float attackFreq = 1f;
                      private bool  canAttack  = true;
    [HideInInspector] public  bool  CanAttack { get { return canAttack; } set { canAttack = value; } }

    void Start()
    {
        mainScript = GetComponent<Foe>();
    }

    public void SetAttackCo()
    {
        StartCoroutine(AttackCo());
    }
    private IEnumerator AttackCo()
    {
       // mainScript.MyRb.velocity = Vector3.zero;
        mainScript.StatsManager.ChangeState(FoeState.attack);
        CanAttack = false;
        yield return new WaitForSeconds(attackFreq);
        mainScript.MyAnimator.SetTrigger("doAttack"); 
        yield return new WaitForSeconds(attackFreq);
        canAttack = true;   
        mainScript.StatsManager.ChangeState(FoeState.idle);
        
    }
}
