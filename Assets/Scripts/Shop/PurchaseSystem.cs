
using UnityEngine;

public static class PurchaseSystem 
{
    public static (bool,string) BuyItem(ShopData shopData)
    {
        PlayerData player = GameDataManager.Instance.PlayerData;

        if (player.Coin < shopData.CoinPrice)
        {
            Debug.Log("Coin not enough");
            return (false, "Coin not enough");
        }

        if(player.Diamond < shopData.DiamondPrice)
        {
            Debug.Log("Diamond not enough");
            return (false, "Diamond not enough");
        }

        if (!GameDataManager.Instance.TryGetItemDataById(shopData.ItemID, out var itemData))
        {
            Debug.Log("Item Not found");
            return (false, "Item Not found");
        }

        player.DecreaseCoin(shopData.CoinPrice);
        player.DecreaseDiamond(shopData.DiamondPrice);
        player.AddItem(itemData);

        GameDataManager.Instance.SavePlayerData();

        return (true, $"success to Buy Item {itemData.Name}");
    }
}
