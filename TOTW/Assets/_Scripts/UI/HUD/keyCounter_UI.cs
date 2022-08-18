using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyCounter_UI : MonoBehaviour
{
    [SerializeField] private Inventory       playerInventory;    
    [SerializeField] private TextMeshProUGUI itemCounterText;

    private void Update()
    {
        itemCounterText.text = playerInventory.keysQ.ToString();
    }




}
