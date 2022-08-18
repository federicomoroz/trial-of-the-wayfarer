using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DoorType
{
    key,
    foe,
    button,
}

public class LockedDoor : Interactible
{
    [Header("Signal")]
    [SerializeField] private Signal        interact;
    [SerializeField] private BoxCollider2D physicsCollider;
    [SerializeField] private Inventory     playerInventory;

    [SerializeField] private GameObject    chatBox;
    [SerializeField] private Text          chatText;
    [SerializeField] private string        textClosed;

    [Header("Door parameters")]
    [SerializeField] private DoorType      currentType;
    [SerializeField] private int           keysRequired = 1;
    [SerializeField] private bool          isOpen;
    [SerializeField] private BoolValue     storedValue;

    [SerializeField] private AudioClip     openSound;
                     private AudioSource   myAudio;
                     private Animator      myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAudio    = GetComponent<AudioSource>();
        InitializeDoor();

    }

    private void Update()
    {
        if (!isOpen)
        {

            if (Input.GetButtonDown("Interact") && inRange)
            {
                if(currentType == DoorType.key)
                {
                    if (CheckKeys() >= keysRequired)
                    {                   
                        UseKeys();                    
                        Open();
                    }
                    else
                    {
                        interact?.Raise();
                        ShowText(textClosed);
                        print("You don't have enough keys.");
                    }
                }
            }
        }
    }

    private void InitializeDoor()
    {
        isOpen = storedValue.runtimeValue; 
        
        if (isOpen)
        {
            Open();
            myAnimator.SetBool("isOpen", true);
        }
        else
        {
            myAnimator.SetBool("isOpen", false);
        }
    }

    public void Open()
    {
        print("Open");
        if (!isOpen) 
        { 
            isOpen = true;
            storedValue.runtimeValue = isOpen;
        }
        playerOutRange?.Raise();
        myAudio.PlayOneShot(openSound);
        physicsCollider.enabled = false;
        myAnimator.SetBool("isOpen", true);
        isActive = false;
    }
    
    private int CheckKeys()
    {
        int keysGot = 0;
        keysGot     = playerInventory.keysQ;
        print($"You've got {keysGot} keys.");
        return keysGot;
    }

    private void UseKeys()
    {
        playerInventory.keysQ -= keysRequired;
        print($"{keysRequired} keys removed from inventory");
    }

    protected override void DeActivate()
    {
        chatText.text = "";
        chatBox.SetActive(false);
        playerOutRange?.Raise();
    }

    private void ShowText(string text)
    {
        if (chatBox.activeInHierarchy)
        {
            DeActivate();
        }
        else
        {
            chatBox.SetActive(true);
            chatText.text = text;
        }
    }



}
