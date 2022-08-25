using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public List<Step> _steps;

    [Tooltip("Designer/programmer notes, not visible to player.")]
    [SerializeField] string _notes;
    [SerializeField] string _displayName;
    [SerializeField] string _description;

    [SerializeField] Sprite _sprite;

    [SerializeField] int _currentStepIndex;

    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite Sprite => _sprite;

    internal void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            // Do whatever we do when a quest progresses.
        }
    }

    Step GetCurrentStep() => _steps[_currentStepIndex];
}

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
    public string Instructions => _instructions;
    public List<Objective> _objectives;

    public bool HasAllObjectivesCompleted() => _objectives.TrueForAll(t => t.IsCompleted);

}

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;

    public bool IsCompleted { get; }

    public enum ObjectiveType
    {
        Flag,
        Item,
        Kill
    }

public override string ToString() => _objectiveType.ToString();
}
