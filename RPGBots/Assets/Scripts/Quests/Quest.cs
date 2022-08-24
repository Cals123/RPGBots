using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public List<Step> _steps;
    [SerializeField] string _displayName;
    [SerializeField] string _description;
    [Tooltip("Designer/programmer notes, not visible to player.")]
    [SerializeField] string _notes;
    [SerializeField] Sprite _sprite;

    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite Sprite => _sprite;
}

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
    public string Instructions => _instructions;
    public List<Objective> _objectives;

}

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;
    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill
    }

public override string ToString() => _objectiveType.ToString();
}
