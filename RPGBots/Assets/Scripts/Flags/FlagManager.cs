using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using System;
using System.Linq;
using UnityEditor;


internal class FlagManager : MonoBehaviour
{
    [SerializeField] GameFlag[] _allFlags;

    private string[] _guids;

    Dictionary<string, GameFlag> _flagsbyName;

    void OnValidate()
    {
        _allFlags = GetAllInstances<GameFlag>();
    }

    public static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);  //FindAssets uses tags check documentation for more info
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }
        return a;
    }
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