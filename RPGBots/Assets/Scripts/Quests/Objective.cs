﻿using System;
using UnityEngine;

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;
    [SerializeField] GameFlag _gameFlag;

    [Tooltip("Required amount for the counted integer game flag.")]
    [SerializeField] int _required = 1;

    public GameFlag GameFlag => _gameFlag;

    public bool IsCompleted
    {
        get
        {
            switch (_objectiveType)
            {

                case ObjectiveType.GameFlag:
                    {
                        if (_gameFlag is BoolGameFlag boolGameFlag)
                            return boolGameFlag.Value;
                        if (_gameFlag is IntGameFlag intGameFlag)
                            return intGameFlag.Value >= _required;
                        return false;
                    }
                default: return false;
            }

        }
    }


    public enum ObjectiveType
    {
        GameFlag,
        Item,
        Kill
    }

    public override string ToString()
    {

        switch (_objectiveType)
        {
            case ObjectiveType.GameFlag:
                { 
                if (_gameFlag is BoolGameFlag boolGameFlag)
                    return _gameFlag.name;
                if (_gameFlag is IntGameFlag intGameFlag)
                    return $"{intGameFlag.name} ({intGameFlag.Value}/{_required})";
                return "Invalid/Unknown Objective Type.";
                }
            default: return _objectiveType.ToString();
        }
    }
}


