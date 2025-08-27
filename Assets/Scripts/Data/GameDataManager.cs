using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }

    [SerializeField] private PlayerData playerData;
    public PlayerData PlayerData => playerData;

    public List<ItemData> playerItem => playerData.PlayerItem;

    [SerializeField] private ItemDataConfig itemDataConfig;
    [SerializeField] private ShopDataConfig shopDataConfig;

    public void Init()
    {
        if (Instance == null)
            Instance = this;

        if(!JsonHelper.LoadData(ref playerData, "PlayerData"))
        {
            JsonHelper.SaveData(playerData, "PlayerData");
        }
    }

    public void SavePlayerData()
    {
        JsonHelper.SaveData(playerData, "PlayerData");
    }

    public void LoadPlayerData()
    {
        if (!JsonHelper.LoadData(ref playerData, "PlayerData")) return;
    }

    public void AddItemToPlayerData(ItemData itemData)
    {
        playerData.AddItem(itemData);
    }

    public bool TryGetItemDataById(string itemId, out ItemData itemData)
    {
        if (itemDataConfig.ItemDatas.TryGetValue(itemId, out itemData)) return true;

        return itemDataConfig.ItemDatas.TryGetValue(itemId, out itemData);
    }

    public bool tryGetShopDataById(string itemId, out ShopData shopData)
    {
        if (shopDataConfig.shopDatasConfig.TryGetValue(itemId, out shopData)) return true;

        return (shopDataConfig.shopDatasConfig.TryGetValue(itemId, out shopData));
    }

    public List<ShopData> tryGetShopDataByItemType(ItemType itemType)
    {
        return shopDataConfig.shopDatasConfig.Values.Where(x => x.ItemType == itemType).ToList();
    }
}
