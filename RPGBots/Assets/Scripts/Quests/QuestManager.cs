using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }
    private List<Quest> _activeQuests = new List<Quest>();
    [SerializeField] private QuestPanel _questPanel;

    void Awake()
    {
        Instance = this;    
    }

    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
    }
}
