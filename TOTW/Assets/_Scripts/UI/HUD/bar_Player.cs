using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bar_Player : MonoBehaviour
{
    [SerializeField]  private Slider slider;
    [HideInInspector] public  Slider Slider { get { return slider; } set { slider = value; } }

                      private GameObject player;
    [HideInInspector] public  GameObject Player { get { return player; } set { player = value; } }

    protected virtual void Start()
    {
        player = GameObject.Find("Player");        
    }
    public void SetSlider(float current, float max)
    {
        Slider.value = current / max;
    }
}
