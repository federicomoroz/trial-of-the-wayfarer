using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactible
{
                     private Animator   myAnimator;
    [SerializeField] private Collider2D myTrigger;

    [Header("Contents")]
    [SerializeField] private Item       content;
    [SerializeField] private Inventory  playerInventory;

    [Header("Dialog")]
    [SerializeField] private GameObject chatBox;
    [SerializeField] private Text chatText;

    [Header("Status")]
                     private bool       isOpen;
    [SerializeField] private BoolValue  storedOpen;

    [Header("Signal")]
    [SerializeField] private Signal     raiseItem;


    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        InitializeChest();
    }

    private void InitializeChest()
    {
        isOpen = storedOpen.runtimeValue;
        if (isOpen)
        {
            myAnimator.SetBool("Open", true);
        }
        else
        {
            myAnimator.SetBool("Open", false);
        }
    }

    protected override void Activate()
    {
        base.Activate();
        if (isOpen == false)
        {
            OpenChest();
            
        }
        else
        {
            ChestAlreadyOpen();
        }
    }

    protected override void DeActivate()
    {
        chatText.text = "";
        chatBox.SetActive(false);
        playerOutRange?.Raise();
    }

    public void OpenChest()
    {
        StartCoroutine(OpenChestCo());        
    }

    private IEnumerator OpenChestCo()
    {
        playerInventory.AddItem(content);
        playerInventory.currentItem = content;
        raiseItem?.Raise();
        myAnimator.SetBool("Open", true);
        isOpen = true;
        storedOpen.runtimeValue = isOpen;
        print($"{content} has been added to Inventory");
        yield return new WaitForSeconds(1.5f);
        if (isActive)
        {
            DisplayText();
        }
    }

    public void ChestAlreadyOpen()
    {

        chatBox.SetActive(false);
        playerInventory.currentItem = null;
        raiseItem?.Raise();
        isActive = false;
    }

    private void DisplayText()
    {
        chatBox.SetActive(true);
        chatText.text = content.itemDescription;
    }

}
