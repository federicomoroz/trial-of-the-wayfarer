using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Switch : Sign
{
    [SerializeField] private BoolValue storedValue;

    protected override void Activate()
    {
        base.Activate();
        if(storedValue.runtimeValue == false)
        {
            storedValue.runtimeValue = true;
        }
    }
}
