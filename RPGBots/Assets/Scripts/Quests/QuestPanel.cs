using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : ToggleablePanel
{
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _descriptionText;
    [SerializeField] TMP_Text _currentObjectivesText;

    [SerializeField] Image _iconImage;

    [SerializeField] Quest _selectedQuest;

    Step _selectedStep => _selectedQuest.CurrentStep;

    public void SelectQuest(Quest quest)
    {
        _selectedQuest.Changed -= DisplayStepInstructionsAndObjectives;
        _selectedQuest = quest;
        Bind();
        Show();
        _selectedQuest.Changed += DisplayStepInstructionsAndObjectives;
    }

    [ContextMenu("Bind")]
    public void Bind()
    {
        _iconImage.sprite = _selectedQuest.Sprite;
        _nameText.SetText(_selectedQuest.DisplayName);
        _descriptionText.SetText(_selectedQuest.Description);
        DisplayStepInstructionsAndObjectives();
    }

    private void DisplayStepInstructionsAndObjectives()
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (_selectedStep != null)
        {
            stringBuilder.AppendLine(_selectedStep.Instructions);

            foreach (var objective in _selectedStep.Objectives)
            {
                string rgb = objective.IsCompleted ? "green" : "red";
                stringBuilder.AppendLine($"<color={rgb}>{objective}</color>");

            }
            _currentObjectivesText.SetText(stringBuilder.ToString());
        }
    }

}
