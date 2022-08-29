using System;
using UnityEngine;

[CreateAssetMenu(menuName = "IntGameFlag")]
public class IntGameFlag : ScriptableObject
{
    public int Value { get; private set; }

    public event Action Changed;
    private void OnEnable() => Value = default;

    private void OnDisable() => Value = default;

    public void Modify(int value)
    {
        Value++;
        Changed?.Invoke();
    }
}
