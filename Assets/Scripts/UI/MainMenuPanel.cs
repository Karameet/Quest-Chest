using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    public CanvasGroup CanvasGroup => canvasGroup;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button InventoryButton;
    [SerializeField] private CurrencyBar currencyBar;
    public CurrencyBar CurrencyBar => currencyBar;

    public event Action OnShopButtonClick;
    public event Action OnInventoryButtonClick;

    public void Init()
    {
        shopButton.onClickAnimation(()=> OnShopButtonClick?.Invoke(),true);
        InventoryButton.onClickAnimation(() => OnInventoryButtonClick?.Invoke(),true);
    }

    public void Dispose()
    {
        shopButton.onClick.RemoveAllListeners();
        InventoryButton.onClick.RemoveAllListeners();
    }   
}
