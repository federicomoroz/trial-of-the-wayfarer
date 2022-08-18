using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar_Player : bar_Player
{

    protected override void Start()
    {
        base.Start();
        SetSliderValue();
    }
    public void SetSliderValue()
    {
        
        if (Player != null)
        {
            float current = Player.GetComponent<PlayerMain>().StatsManager.PlayerHp.runtimeValue;          
            float max     = Player.GetComponent<PlayerMain>().StatsManager.PlayerHp.initialValue;            
            SetSlider(current, max);
        }   
    }



}
