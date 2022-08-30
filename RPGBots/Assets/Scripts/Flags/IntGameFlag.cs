using System;
using UnityEngine;

[CreateAssetMenu(menuName = "IntGameFlag")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Value += value;
        SendChanged();
    }

    internal void Set(int intGameValue)
    {
        Value = intGameValue;
        SendChanged();

    }
}
