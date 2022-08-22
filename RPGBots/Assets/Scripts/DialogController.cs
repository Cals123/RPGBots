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

    [SerializeField] Button[] _choiceButtons;
    [SerializeField] TMP_Text _storyText;
    [SerializeField] Animator _animator;

    Story _story;

    CanvasGroup _canvasGroup;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ToggleCanvasOff();
    }

    [ContextMenu("Start Dialog")]
    public void StartDialog(TextAsset dialog)
    {
        _story = new Story(dialog.text);
        RefreshView();
        ToggleCanvasOn();
    }


    private void RefreshView()
    {
        StringBuilder storyTextBuilder = new StringBuilder();
        while (_story.canContinue)
        {
            storyTextBuilder.AppendLine(_story.Continue());
            HandleTags();
        }
        _storyText.SetText(storyTextBuilder);

        if (_story.currentChoices.Count == 0)
            ToggleCanvasOff();
        else
            ShowChoiceButtons();
    }

    void ShowChoiceButtons()
    {
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

    void ToggleCanvasOn()
    {
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

    }

    void ToggleCanvasOff()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

    }
    void HandleTags()
    {
        foreach (var tag in _story.currentTags)
        {
            Debug.Log(tag);
            if (tag.StartsWith("E."))
            {
                string eventName = tag.Remove(0, 2);
                GameEvent.RaiseEvent(eventName);
            }
        }

    }
}
