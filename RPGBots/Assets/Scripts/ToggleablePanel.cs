using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleablePanel : MonoBehaviour
{
    CanvasGroup _canvasGroup;

    public static bool _isVisible() => _visiblePanels.Count > 0;

    static HashSet<ToggleablePanel> _visiblePanels = new HashSet<ToggleablePanel>();

    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide();
    }

    protected void Show()
    {
        _visiblePanels.Add(this);
        _canvasGroup.alpha = 0.8f;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

    }

    public void Hide()
    {
        _visiblePanels.Remove(this);
        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

    }

}