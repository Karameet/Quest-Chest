using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopDataConfig", menuName = "Scriptable Objects/ShopDataConfig")]
public class ShopDataConfig : ScriptableObject
{
    [SerializeField] List<ShopData> shopDatas;

    public Dictionary<string, ShopData> shopDatasConfig => GetInventoryItemConfig();
    private Dictionary<string, ShopData> cachedItemData;

    private Dictionary<string, ShopData> GetInventoryItemConfig()
    {
        if (cachedItemData != null) return cachedItemData;

        cachedItemData = new Dictionary<string, ShopData>();

        foreach (var config in shopDatas)
        {
            cachedItemData[config.Id] = config;
        }
        return cachedItemData;
    }
}

[Serializable]
public class ShopData
{
    public string Id;
    public string ItemID;
    public ItemType ItemType;
    public int CoinPrice;
    public int DiamondPrice;
}