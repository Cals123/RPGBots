using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    [SerializeField] private QuestPanel _questPanel;
    [SerializeField] List<Quest>_allQuests = new List<Quest>();

    private List<Quest> _activeQuests = new List<Quest>();

    void Awake()
    {
        Instance = this;    
    }

    //private void Start() => GameFlag.AnyChanged += ProgressQuest;
    //private void OnDestroy() => GameFlag.AnyChanged -= ProgressQuest;

    public void AddQuest(Quest quest)
    {
        _activeQuests.Add(quest);
        _questPanel.SelectQuest(quest);
    }

    public void AddQuestByName(string questName)
    {
        var quest = _allQuests.FirstOrDefault(t => t.name == questName);
        if (quest != null)
            AddQuest(quest);
    }

    //[ContextMenu("Progress Quests")]
    //public void ProgressQuest()
    //{
    //    foreach (var quest in _activeQuests)
    //    {
    //        quest.TryProgress();
    //    }
    //}

}
