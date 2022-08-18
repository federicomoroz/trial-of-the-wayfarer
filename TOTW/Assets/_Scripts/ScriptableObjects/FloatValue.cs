using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
  public float initialValue;
  public float runtimeValue;

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
