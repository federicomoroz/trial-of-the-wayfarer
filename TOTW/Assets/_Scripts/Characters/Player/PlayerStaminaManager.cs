using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaManager : MonoBehaviour
{
                     private PlayerMain mainScript;
    [SerializeField] private int        staminaFillSpeed = 33;
    [Header("Signal")]
    [SerializeField] public  Signal     StaminaChange;

    void Start()
    {
        mainScript = GetComponent<PlayerMain>();
        FullStamina();
    }

    void Update()
    {
        if (mainScript.StatsManager.PlayerStamina.runtimeValue < mainScript.StatsManager.PlayerStamina.initialValue)
        {
            AddStamina();
        }
    }

    public void FullStamina()
    {
        mainScript.StatsManager.PlayerStamina.runtimeValue = mainScript.StatsManager.PlayerStamina.initialValue;
        UpdateStaminaBar();
    }

    public void TakeStamina(float stamina)
    {
        mainScript.StatsManager.PlayerStamina.runtimeValue -= stamina;
        print($"Player has spent {stamina}% of his stamina.");
        if (mainScript.StatsManager.PlayerStamina.runtimeValue < 0)
        {
            mainScript.StatsManager.PlayerStamina.runtimeValue = 0;
        }
        UpdateStaminaBar();
    }
   
    public void AddStamina()
    {
        mainScript.StatsManager.PlayerStamina.runtimeValue += staminaFillSpeed * Time.deltaTime;
        if (mainScript.StatsManager.PlayerStamina.runtimeValue > mainScript.StatsManager.PlayerStamina.initialValue)
        {
            mainScript.StatsManager.PlayerStamina.runtimeValue = mainScript.StatsManager.PlayerStamina.initialValue;
        }
        UpdateStaminaBar();
    }


    private void UpdateStaminaBar()
    {
        StaminaChange.Raise();        
    }

}
