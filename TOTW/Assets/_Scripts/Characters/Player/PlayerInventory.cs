using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
                      private PlayerMain      mainScript;
    [SerializeField]  private Inventory       myInventory;
    [HideInInspector] public  Inventory       MyInventory { get { return myInventory; } set { myInventory = value; } }
    [SerializeField]  private SpriteRenderer  receivedItemSprite;

    void Start()
    {
        mainScript = GetComponent<PlayerMain>();    
    }
  


    public void RaiseItem()
    {
        if(mainScript.StatsManager.CurrentState != PlayerState.interact)
        {
            mainScript.MyAnimator.SetBool("pickItem", true);
            mainScript.StatsManager.ChangeState(PlayerState.interact);
            receivedItemSprite.sprite = MyInventory.currentItem.itemSprite;
        }
        else
        {
            mainScript.MyAnimator.SetBool("pickItem", false);
            mainScript.StatsManager.ChangeState(PlayerState.idle);
            receivedItemSprite.sprite = null;
        }
    }

    public void UseItem()
    {
        print("Use item");
        if (mainScript.StatsManager.CurrentState != PlayerState.interact)
        {
            mainScript.StatsManager.ChangeState(PlayerState.interact);
        }
        else
        {
            mainScript.StatsManager.ChangeState(PlayerState.idle);
        }
    }
}
