using UnityEngine.Events;
using System;
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] GameEvent _gameEvent;
    [SerializeField] UnityEvent _unityEvent;

    void Awake() => _gameEvent.Register(this);
    private void OnDisable() => _gameEvent.DeRegister(this);

    public void RaiseEvent() => _unityEvent.Invoke();
}