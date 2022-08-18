using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField] TextAsset _dialog;
    [SerializeField] Button[] _choiceButtons;
    [SerializeField] TMP_Text _storyText;

    Story _story;

    [ContextMenu("Start Dialog")]
    void StartDialog()
    {
        _story = new Story(_dialog.text);
        RefreshView();
    }

    private void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();
        while(_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());
        }
        _storyText.SetText(storyTextBuilder);

        for (int i = 0; i < _choiceButtons.Length; i++)
        {
            var Button = _choiceButtons[i];
            Button.gameObject.SetActive(i < _story.currentChoices.Count);

            Button.onClick.RemoveAllListeners();

            if (i < _story.currentChoices.Count)
            {
                var choice = _story.currentChoices[i];
                Button.GetComponentInChildren<TMP_Text>().SetText(choice.text);
                Button.onClick.AddListener(() =>
                {
                    _story.ChooseChoiceIndex(choice.index);
                    RefreshView();

                });
            }
        }
    }
}
