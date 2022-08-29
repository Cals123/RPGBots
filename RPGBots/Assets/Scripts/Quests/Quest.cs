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
                if (objective.IntGameFlag != null)
                    objective.IntGameFlag.Changed += HandleFlagChanged;
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

[Serializable]
public class Objective
{
    [SerializeField] ObjectiveType _objectiveType;
    [SerializeField] BoolGameFlag _gameFlag;

    [Header("Int Game Flags")]
    [SerializeField] IntGameFlag _intGameFlag;

    [Tooltip("Required amount for the counted integer game flag.")]
    [SerializeField] int _required = 1;

    public BoolGameFlag GameFlag => _gameFlag;
    public IntGameFlag IntGameFlag => _intGameFlag;

    public bool IsCompleted
    {
        get
        {
            switch (_objectiveType)
            {
                case ObjectiveType.BoolFlag: return _gameFlag.Value;
                case ObjectiveType.CountedIntFlag: return _intGameFlag.Value >= _required;
                default: return false;

            }
        }
    }


    public enum ObjectiveType
    {
        BoolFlag,
        CountedIntFlag,
        Item,
        Kill
    }

    public override string ToString()
    {


        switch (_objectiveType)
        {
            case ObjectiveType.BoolFlag: return _gameFlag.name;
            case ObjectiveType.CountedIntFlag: return $"{_intGameFlag.name} ({_intGameFlag.Value}/{_required})";
            default: return _objectiveType.ToString();

        }

    }
}
