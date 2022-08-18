using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar_Player : bar_Player
{
   
    [SerializeField]  private Gradient gradient;
    [SerializeField]  private Image    fill;

    public void SetSliderValue()
    {  
        if (Player != null)
        {
            float current            = Player.GetComponent<PlayerStats>().PlayerStamina.runtimeValue;
            float max                = Player.GetComponent<PlayerStats>().PlayerStamina.initialValue;
            SetSlider(current, max);
        }
    }

    private void Update()
    {
        if (Slider.value < Slider.maxValue)
        {
            UpdateFillColor();
        }            
    }


    // El gradiente tiene un punto de cambio de color hardcodeado en 33% desde el inspector. Debería parametrizarse y elegir como punto de cambio de color el valor de stamina mínimo para hacer un ataque.
    private void UpdateFillColor()
    {
        fill.color = gradient.Evaluate(Slider.normalizedValue);
    }


}
