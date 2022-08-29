using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlagTriggerArea : MonoBehaviour
{
    [SerializeField] BoolGameFlag _gameFlag;

    public void OnTriggerEnter(Collider other)
    {
        _gameFlag.Set(true);

    }
}
