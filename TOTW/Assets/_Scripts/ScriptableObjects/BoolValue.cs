using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;
    public bool runtimeValue;

    public void OnAfterDeserialize()
    {
        ResetValue();
    }

    public void OnBeforeSerialize()
    {
        
    }

    public void ResetValue()
    {
        runtimeValue = initialValue;
    }
}
