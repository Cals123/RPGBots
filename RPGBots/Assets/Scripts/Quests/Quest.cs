using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Quest")]
public class Quest : ScriptableObject
{
    public List<Step> Steps;

    [Tooltip("Designer/programmer notes, not visible to player.")]
    [SerializeField] string _notes;
    [SerializeField] string _displayName;
    [SerializeField] string _description;

    [SerializeField] Sprite _sprite;

    [SerializeField] int _currentStepIndex;

    public event Action Changed;
    public string Description => _description;
    public string DisplayName => _displayName;
    public Sprite Sprite => _sprite;

    public Step CurrentStep => Steps[_currentStepIndex];

    void OnEnable()
    {
        _currentStepIndex = 0;
        foreach (var step in Steps)
            foreach (var objective in step.Objectives)
            {
                if (objective.GameFlag != null)
                    objective.GameFlag.Changed += HandleFlagChanged;
            }
    }

    public void HandleFlagChanged()
    {
        TryProgress();
        Changed?.Invoke();

    }

    internal void TryProgress()
    {
        var currentStep = GetCurrentStep();
        if (currentStep.HasAllObjectivesCompleted())
        {
            _currentStepIndex++;
            Changed?.Invoke();
        }
    }

    Step GetCurrentStep() => Steps[_currentStepIndex];
}

[Serializable]
public class Step
{
    [SerializeField] string _instructions;
    public string Instructions => _instructions;
    public List<Objective> Objectives;

    public bool HasAllObjectivesCompleted() => Objectives.TrueForAll(t => t.IsCompleted);

}
