using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactible
{
    [SerializeField] private GameObject   chatBox;
    [SerializeField] private Text         chatText;
    [SerializeField] protected string     chat; 


    protected override void Activate()
    {
        base.Activate();
        if (chatBox.activeInHierarchy)
        {
            DeActivate();
        }
        else
        {
            chatBox.SetActive(true);
            chatText.text = chat;
        }
    }

    protected override void DeActivate()
    {
        chatText.text = "";
        chatBox.SetActive(false);
        playerOutRange?.Raise();
    }
}
