using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private CurrencyBar currencyBar; 
    public CurrencyBar CurrencyBar => currencyBar;

    [SerializeField] private CanvasGroup canvasGroup; 
    public CanvasGroup CanvasGroup => canvasGroup;  
    [SerializeField] private Button backButton;
    [SerializeField] private ShopItem shopItem;
    [SerializeField] private Transform ItemContainer;

    [Space(5)]
    [SerializeField] private Toggle weaponCategoryToggle;
    [SerializeField] private Toggle equipmentCategoryToggle;
    [SerializeField] private Toggle consumeCategoryToggle;
    [SerializeField] private Toggle specialCategoryToggle;

    [Space(5)]
    [SerializeField] private ItemType currentType = ItemType.Weapon;

    public event Action OnBackButtonClick;

    [SerializeField] private List<ShopItem> currentItemList;
    public void Init()
    {
        backButton.onClickAnimation(() => OnBackButtonClick?.Invoke(),true);

        currentItemList = new List<ShopItem>();

        weaponCategoryToggle.OnClickAnimation(onClick:()=> ChangeCategory(ItemType.Weapon));
        equipmentCategoryToggle.OnClickAnimation(onClick:()=> ChangeCategory(ItemType.Equipment));
        consumeCategoryToggle.OnClickAnimation(onClick:()=> ChangeCategory(ItemType.Consume));
        specialCategoryToggle.OnClickAnimation(onClick:()=> ChangeCategory(ItemType.Special));
    }

    private bool isCreateShopItem = false;

    public void ChangeCategory(ItemType itemType)
    {
        SoundManager.Instance.PlayerAudioWith(SoundType.UIButton);
        if (currentType == itemType && currentItemList.Count > 0)
            return;

        if (isCreateShopItem)
            return;
            
        if (GameDataManager.Instance == null)
            return;

        if(currentItemList != null || currentItemList.Count > 0)
            ClearItemShop();

        currentType = itemType;
        SelectToggle(itemType);

        isCreateShopItem = true;

        StartCoroutine(CreateItemShop(itemType));     
    }

    private IEnumerator CreateItemShop(ItemType itemType)
    {
        var itemDatas = GameDataManager.Instance.tryGetShopDataByItemType(itemType);

        foreach (var itemData in itemDatas)
        {
            var item = Instantiate(shopItem, ItemContainer);
            item.Init(itemData);
            item.gameObject.SetActive(true);
            item.OnUpdateCurrency += CurrencyBar.UpdateCurrencyNumber;
            currentItemList.Add(item);
        }

        yield return null;

        isCreateShopItem = false;
    }

    public void ClearItemShop()
    {
        foreach (var item in currentItemList)
        {
            Destroy(item.gameObject);
        }

        currentItemList.Clear();
    }

    private void SelectToggle(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Weapon: weaponCategoryToggle.SetIsOnWithoutNotify(true); break;
            case ItemType.Equipment: equipmentCategoryToggle.SetIsOnWithoutNotify(true); break;
            case ItemType.Consume: consumeCategoryToggle.SetIsOnWithoutNotify(true); break;
            case ItemType.Special: specialCategoryToggle.SetIsOnWithoutNotify(true); break;
        }
            
    }

    public void Dispose()
    {
        backButton.onClick.RemoveAllListeners();
    }
}
