using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Powerup
{
    [SerializeField]  private FloatValue hp;
    [HideInInspector] public  FloatValue Hp  { get { return hp; } set { hp = value; } }    
    [SerializeField] private float lifeTime = 3f;


    


    private void OnEnable()
    {
        StartCoroutine(HealerCo());
    }
    private IEnumerator HealerCo()
    {
        yield return new WaitForSeconds(lifeTime);
        MyAnimator.SetTrigger("GoodBye");
        

       
    }

}
