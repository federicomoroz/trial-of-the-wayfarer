using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
                 private  PlayerMain  mainScript;
[Header("Signal")]
[SerializeField] private  Signal      HpChangeSignal, GotHurtSignal, DeathSignal; 


    void Start()
    {
        mainScript = GetComponent<PlayerMain>();
        UpdateHpBar();


    }
    #region HP Methods

    public void FullHp()
    {        
        mainScript.StatsManager.PlayerHp.runtimeValue = mainScript.StatsManager.PlayerHp.initialValue;
        UpdateHpBar();
    }

    public void TakeHp(int damage)
    {

        mainScript.StatsManager.PlayerHp.runtimeValue -= damage;
        UpdateHpBar();
        GotHurtSignal?.Raise();
        mainScript.FxController.VoiceHurt();
        mainScript.PopupSpawner.GetComponent<popupSpawner>().makePopup(damage);
        print($"Player has been damaged and lost {damage}hp.");
        if (mainScript.StatsManager.PlayerHp.runtimeValue <= 0)
        {
            
            print("Player's died.");
            mainScript.StatsManager.PlayerHp.runtimeValue = 0;
            OnDeath();
        }

    }

    public void AddHp(float heal)
    {
        //mainScript.StatsManager.PlayerHpCurrent += heal;
        mainScript.StatsManager.PlayerHp.runtimeValue += heal;
        mainScript.FxController.HealFx();
        mainScript.PopupSpawner.GetComponent<popupSpawner>().makePopup(heal);
        print($"Player's been healed by {heal}hp.");
        if (mainScript.StatsManager.PlayerHp.runtimeValue > mainScript.StatsManager.PlayerHp.initialValue)
        {
            FullHp();
        }
        UpdateHpBar();
    }

    private void UpdateHpBar()
    {
        HpChangeSignal?.Raise();
    }
    #endregion

    private void OnDeath()
    {
        StartCoroutine(DeathCo());
    }

    private IEnumerator DeathCo()
    {
        mainScript.MovementManager.enabled = false;        
        mainScript.MyAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);        
        DeathSignal?.Raise();
    }



}
