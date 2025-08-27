using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private Image itemSprite;
    [SerializeField] private TMP_Text PriceText;
    [SerializeField] private Image currencyIcon;
    [SerializeField] private Button BuyButton;

    public event Action OnUpdateCurrency;

    [SerializeField] private ShopData shopData;

    public void Init(ShopData shopData)
    {
        if(!GameDataManager.Instance.TryGetItemDataById(shopData.ItemID,out var itemData)) return;

        this.shopData = shopData;

        itemNameText.text = itemData.Name;

        itemSprite.SetImageFromAtlas(itemData.AtlasName, itemData.SpriteName);

        BuyButton.onClickAnimation(PurchaseItem);

        if(shopData.CoinPrice > 0)
        {
            currencyIcon.SetImageFromAtlas("ItemIcon", "currency_coin");
            PriceText.text = shopData.CoinPrice.ToString();
        }
        else if(shopData.DiamondPrice > 0)
        {
            currencyIcon.SetImageFromAtlas("ItemIcon", "currency_diamond");
            PriceText.text = shopData.DiamondPrice.ToString();
        }
    }

    private void PurchaseItem()
    {
        var buying = PurchaseSystem.BuyItem(shopData);

        if (buying.Item1)
        {
            GameManager.Instance.SandNotification(buying.Item2);
            OnUpdateCurrency?.Invoke();
        }
        else
        {
            GameManager.Instance.SandNotification(buying.Item2);
        }
    }
}
