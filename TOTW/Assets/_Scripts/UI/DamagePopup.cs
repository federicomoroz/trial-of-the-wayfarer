using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
                     private TextMeshPro text;
                     private Color       textColor;
                     private float       lifeTime = 0.5f;                  
    [SerializeField] private float       moveSpeed = 2f;
    [SerializeField] private float       fadeSpeed = 3f;


    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }



    private void Update()
    {
        LifeTime();

        Movement();
    }


    public void SetValue(float damage)
    {        
        text.SetText(Mathf.Round(damage).ToString());   // Se pasa por parámetro el valor del daño recibido redondeado así lo muestra como entero.
        textColor = text.color;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void LifeTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            textColor.a -= fadeSpeed * Time.deltaTime;
            text.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Movement()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
  

}
