﻿using UnityEngine;

public class ToggleablePanel : MonoBehaviour
{
    CanvasGroup _canvasGroup;

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    protected void Show()
    {
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

    }

    public void Hide()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

    }

}