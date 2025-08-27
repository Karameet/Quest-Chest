using System;
using UnityEngine;

public class StateMainMenu : IState
{
    MainMenuPanel mainMenuPanel;
    UIManager uIManager;

    private Action OnShopButtonClick;
    private Action OnInventoryButtonClick;
    public StateMainMenu(UIManager uIManager, MainMenuPanel mainMenuPanel)
    {
        this.uIManager = uIManager; 
        this.mainMenuPanel = mainMenuPanel;

        init();
    }

    private void init()
    {
        OnShopButtonClick += () => uIManager.ChangState(uIManager.stateShop);
        OnShopButtonClick += () => SoundManager.Instance.PlayerAudioWith(SoundType.UIButton);

        OnInventoryButtonClick += () => uIManager.ChangState(uIManager.stateInventory);
        OnInventoryButtonClick += () => SoundManager.Instance.PlayerAudioWith(SoundType.UIButton);
    }

    public void Enter()
    {
        mainMenuPanel.gameObject.SetActive(true);
        mainMenuPanel.CanvasGroup.onCanvasGroupFade(0, 1);
        mainMenuPanel.CurrencyBar.UpdateCurrencyNumber();
        mainMenuPanel.OnShopButtonClick += OnShopButtonClick;
        mainMenuPanel.OnInventoryButtonClick += OnInventoryButtonClick;
    }

    public void Exit()
    {
        mainMenuPanel.OnShopButtonClick -= OnShopButtonClick;
        mainMenuPanel.OnInventoryButtonClick -= OnInventoryButtonClick;

        mainMenuPanel.CanvasGroup.onCanvasGroupFade(1, 0, onEndFade: () => 
        {   
            mainMenuPanel.gameObject.SetActive(false);
        });
    }

    public void FixedRun()
    {
    }

    public void Run()
    {
    }
}
