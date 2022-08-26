using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoolGameFlag")]
public class GameFlag : ScriptableObject
{
    public bool Value { get; private set; }
    public static event Action AnyChanged;

    private void OnEnable() => Value = default;

    private void OnDisable() => Value = default;

    public void Set(bool value)
    {
        Value = value;
        AnyChanged?.Invoke();
    }
}
