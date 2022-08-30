using System;
using UnityEngine;

//[CreateAssetMenu(menuName = "BoolGameFlag")]
public class GameFlag : ScriptableObject
{
    public virtual event Action Changed;
    protected void SendChanged() => Changed?.Invoke();
}


public class GameFlag<T> : GameFlag
{
    public T Value { get; protected set; }
    private void OnDisable() => Value = default;
    private void OnEnable() => Value = default;
    
}