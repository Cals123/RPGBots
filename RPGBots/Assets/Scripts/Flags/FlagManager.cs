using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System;
using System.Linq;

internal class FlagManager : MonoBehaviour
{
    [SerializeField] List<GameFlag>  _allFlags;

    Dictionary<string, GameFlag> _flagsbyName;

    void Start()
    {
        _flagsbyName = _allFlags.ToDictionary(k => k.name.Replace(" ", ""), v => v);
    }
    public static FlagManager Instance { get; private set; }

    void Awake() => Instance = this;

    public void Set(string flagName, string value)
    {
        if (_flagsbyName.TryGetValue(flagName, out var flag) == false)
            Debug.LogError($"Flag Not Found {flagName}");
        if (flag is IntGameFlag intGameFlag)
        {
            if (int.TryParse(value, out var intGameValue))
                intGameFlag.Set(intGameValue);
        }
        if (flag is BoolGameFlag boolGameFlag)
        {
            if (bool.TryParse(value, out var boolGameValue))
                boolGameFlag.Set(boolGameFlag);
        }
        if (flag is StringGameFlag stringGameFlag)
        {
                stringGameFlag.Set(value);
        }
        if (flag is DecimalGameFlag decimalGameFlag)
        {
            if (decimal.TryParse(value, out var boolGameValue))
                decimalGameFlag.Set(boolGameValue);
        }
    }
}