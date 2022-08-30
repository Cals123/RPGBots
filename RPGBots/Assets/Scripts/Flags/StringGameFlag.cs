using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StringGameFlag")]
public class StringGameFlag : GameFlag<string>
{
    public void SetString(string str)
    {
        Value = str;
        SendChanged();
    }
}
