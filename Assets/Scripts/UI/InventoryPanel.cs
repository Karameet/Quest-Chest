using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    public CanvasGroup CanvasGroup => canvasGroup;
    [SerializeField] private Button backButton;
    [SerializeField] private CurrencyBar currencyBar;
    [SerializeField] private UIItem uiItem;
    [SerializeField] private Transform itemContainer;

    [SerializeField] private List<UIItem> uiItemList;
    public CurrencyBar CurrencyBar => currencyBar;

    public event Action OnBackButtonClick;

    public void Init()
    {
        backButton.onClickAnimation(() => OnBackButtonClick?.Invoke(),true);

        uiItemList = new List<UIItem>();
    }

    public void SetItem()
    {
        StartCoroutine(CreateItem());
    }

    private IEnumerator CreateItem()
    {
        var playerItem = GameDataManager.Instance.playerItem;

        foreach (var item in playerItem)
        {
            UIItem uiItem = Instantiate(this.uiItem, itemContainer);
            uiItem.SetSprite(item.AtlasName, item.SpriteName);
            uiItem.gameObject.SetActive(true);
            uiItemList.Add(uiItem);
        }

        yield return null;
    }

    public void ClearItem()
    {
        foreach (UIItem item in uiItemList)
        {
            Destroy(item.gameObject);
        }
        uiItemList.Clear();
    }

    public void Dispose()
    {
        backButton.onClick.RemoveAllListeners();
    }
}
