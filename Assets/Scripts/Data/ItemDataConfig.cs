using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Rendering.STP;

[CreateAssetMenu(fileName = "ItemDataConfig", menuName = "Scriptable Objects/ItemData")]
public class ItemDataConfig : ScriptableObject
{
    [SerializeField] private List<ItemData> items;

    public Dictionary<string, ItemData> ItemDatas => GetInventoryItemConfig();
    private Dictionary<string, ItemData> cachedItemData;

    private Dictionary<string, ItemData> GetInventoryItemConfig()
    {
        if (cachedItemData != null) return cachedItemData;

        cachedItemData = new Dictionary<string, ItemData>();

        foreach (var config in items)
        {
            cachedItemData[config.ID] = config;
        }

        return cachedItemData;
    }
}


[Serializable]
public class ItemData
{
    public string ID;
    public string Name;
    public ItemType Type;
    public string AtlasName;
    public string SpriteName;
}

public enum ItemType
{
    Weapon,
    Equipment,
    Consume,
    Special,
}