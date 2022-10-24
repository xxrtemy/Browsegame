using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuestItemsConfig", fileName = "QuestItemsConfig", order = 0)]
public class QuestItemsConfig : ScriptableObject
{
    public int questId;
    public List<int> questItemIdCollection;
}
