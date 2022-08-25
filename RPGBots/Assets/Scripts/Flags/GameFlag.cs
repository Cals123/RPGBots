using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BoolGameFlag")]
public class GameFlag : ScriptableObject
{
    public bool Value;

    private void OnEnable() => Value = default;
    
}
