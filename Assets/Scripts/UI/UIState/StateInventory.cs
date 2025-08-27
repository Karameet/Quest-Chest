using System;

public class StateInventory : IState
{
    private UIManager uIManager;
    private InventoryPanel inventoryPanel;

    private Action OnBackButtonClick;

    public StateInventory(UIManager uIManager, InventoryPanel shopPanel)
    {
        this.uIManager = uIManager;
        inventoryPanel = shopPanel;

        Init();
    }

    private void Init()
    {
        OnBackButtonClick += () => uIManager.ChangState(uIManager.previousState);
        OnBackButtonClick += () => SoundManager.Instance.PlayerAudioWith(SoundType.UIButton);
    }

    public void Enter()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.CanvasGroup.onCanvasGroupFade(0, 1);
        inventoryPanel.CurrencyBar.UpdateCurrencyNumber();
        inventoryPanel.SetItem();
        inventoryPanel.OnBackButtonClick += OnBackButtonClick;
    }

    public void Exit()
    {
        inventoryPanel.ClearItem();
        inventoryPanel.OnBackButtonClick -= OnBackButtonClick;
        inventoryPanel.CanvasGroup.onCanvasGroupFade(1, 0, onEndFade: () =>
        {
            inventoryPanel.gameObject.SetActive(false);
        });
    }

    public void FixedRun()
    {
    }

    public void Run()
    {
    }
}
