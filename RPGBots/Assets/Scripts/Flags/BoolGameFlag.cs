using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoolGameFlag")]
public class BoolGameFlag : ScriptableObject
{
    public bool Value { get; private set; }

    public event Action Changed;
    private void OnEnable() => Value = default;

    private void OnDisable() => Value = default;

    public void Set(bool value)
    {
        Value = value;
        Changed?.Invoke();
    }
}
