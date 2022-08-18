using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageHazard : MonoBehaviour
{
    [SerializeField] private int damagePower = 10;    
    [HideInInspector] public int DamagePower { get { return damagePower; } set { damagePower = value; } }
    
}
