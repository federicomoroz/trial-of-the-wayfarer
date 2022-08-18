using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public List<Item> items         = new List<Item>();
    public Item       currentItem;
    public int        keysQ;

    public void AddItem(Item itemToAdd)
    {
        
        if (itemToAdd.isKey)
        {
            keysQ++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }


    public void OnAfterDeserialize()
    {
        ResetValue();
    }

    public void OnBeforeSerialize()
    {

    }

    public void ResetValue()
    {
        keysQ = 0;
    }

}
