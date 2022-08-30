using System;
using UnityEngine;

[CreateAssetMenu(menuName = "IntGameFlag")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int value)
    {
        Value++;
        SendChanged();
    }
}
