using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public List<Step> _steps;
    [SerializeField] string _name;
    [SerializeField] string _description;
    [Tooltip("Designer/programmer notes, not visible to player.")]
    [SerializeField] string _notes;
}

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
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
}