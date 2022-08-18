using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
                     private PlayerMain  mainScript;
    [SerializeField] private GameObject  swing_vfx;
    [SerializeField] private Transform[] attackPoints;               //0 = Derecha, 0°. 1 = Abajo, 270°. 2 = Izquierda, 180°. 3 = Arriba, 90°.
    [SerializeField] private float       minStaminaToAttack = 33f;   //% de stamina mínima requerida para lanzar un ataque.
    void Start()
    {
        mainScript = GetComponent<PlayerMain>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Attack") && mainScript.StatsManager.CurrentState != PlayerState.attack && mainScript.StatsManager.CurrentState != PlayerState.hurt && mainScript.StatsManager.CurrentState != PlayerState.interact && mainScript.StatsManager.PlayerStamina.runtimeValue > minStaminaToAttack)
        {
            StartCoroutine(SwordAttackCO());
        }
    }

    private IEnumerator SwordAttackCO()
    {
        mainScript.MyAnimator.SetBool("isAttacking", true);
        mainScript.StatsManager.ChangeState(PlayerState.attack);        
        mainScript.MovementManager.CanMove                            = false;
        mainScript.MyRb.velocity                                      = Vector2.zero;
        GameObject swing                                              = Instantiate(swing_vfx, attackPoints[mainScript.CurrentDir.CurrentDir].position, attackPoints[mainScript.CurrentDir.CurrentDir].rotation);    //Se elige el índice de attackPoints a través del valor de CurrentDir                                                                                                                                                                                                                    //
        swing.GetComponent<PlayerAttackSwingBehaviour>().DamagePower *= (CalculateDamageRatio(mainScript.StatsManager.PlayerStamina.runtimeValue, mainScript.StatsManager.PlayerStamina.initialValue));              //Se multiplica el daño ejercido por el golpe dado por el % de stamina al momento de atacar.
        ChooseAttackVoice(mainScript.StatsManager.PlayerStamina.runtimeValue, mainScript.StatsManager.PlayerStamina.initialValue);
        yield return null;                                                                                                                                                                                           // Yield return null equivale a 1 frame, así el bool activa la animación únicamente en 1 frame.
        mainScript.StaminaManager.TakeStamina(100f);
        mainScript.MyAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(0.33f);
        mainScript.StatsManager.ChangeState(PlayerState.idle);
        mainScript.MovementManager.CanMove                            = true;

    }
    
    private float CalculateDamageRatio(float runtime, float initial)
    {
        float ratio = runtime / initial;
        return ratio;
    }

    private void ChooseAttackVoice(float current, float max)
    {
        print("ChooseAttackVoide works");

        if (current == max)
        {
            mainScript.FxController.VoiceAttack(3);
        }
        else if (current >= (max * 0.75f))
        {
            mainScript.FxController.VoiceAttack(2);
        } 
        else if (current >= (max * 0.50f))
        {
            mainScript.FxController.VoiceAttack(1);
        }
        else
        {
            mainScript.FxController.VoiceAttack(0);
        }

     
    }


}
