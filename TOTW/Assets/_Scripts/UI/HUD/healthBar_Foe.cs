using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar_Foe : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [HideInInspector] public Slider Slider { get { return slider; } set { slider = value; } }
    [SerializeField] private float lifeTime = 2f;
    private float lifeTimeCurrent;

    private void Update()
    {
        if (lifeTimeCurrent < lifeTime)
        {
            lifeTimeCurrent += Time.deltaTime;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ShowHpBar()
    {
        lifeTimeCurrent = 0;
        SetSliderValue();
    }
    public void SetSliderValue()
    {  
            float current = GetComponentInParent<FoeStats>().HpCurrent;
            float max = GetComponentInParent<FoeStats>().HpMax.initialValue;
            SetSlider(current, max);     
    }

    private void SetSlider(float current, float max)
    {
        Slider.value = current / max;
    }
}
