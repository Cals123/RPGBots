using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System;
using System.Linq;

internal class FlagManager : MonoBehaviour
{
    [SerializeField] List<GameFlag>  _allFlags;

    public static FlagManager Instance { get; private set; }

    void Awake() => Instance = this;

    internal void Set(string flagName, string value)
    {
        var flag = _allFlags.FirstOrDefault(t => t.name.Replace(" ", "") == flagName);
        if (flag == null)
            Debug.LogError($"Flag Not Found {flagName}");
        if (flag is IntGameFlag intGameFlag)
        {
            if (int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
        }
    }
}