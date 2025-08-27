using System;

public class StateShop : IState
{
    private UIManager uIManager;
    private ShopPanel ShopPanel;

    private Action OnBackButtonClick; 
    public StateShop(UIManager uIManager, ShopPanel shopPanel)
    {
        this.uIManager = uIManager;
        ShopPanel = shopPanel;

        Init();
    }

    private void Init()
    {
        OnBackButtonClick += () => uIManager.ChangState(uIManager.previousState);
        OnBackButtonClick += () => SoundManager.Instance.PlayerAudioWith(SoundType.UIButton);

    }

    public void Enter()
    {
        ShopPanel.OnBackButtonClick += OnBackButtonClick;
        ShopPanel.CurrencyBar.UpdateCurrencyNumber();
        ShopPanel.gameObject.SetActive(true);
        ShopPanel.CanvasGroup.onCanvasGroupFade(0,1);
        ShopPanel.ChangeCategory(ItemType.Weapon);
    }

    public void Exit()
    {
        ShopPanel.OnBackButtonClick -= OnBackButtonClick;
        ShopPanel.ClearItemShop();
        ShopPanel.CanvasGroup.onCanvasGroupFade(1, 0, onEndFade: () =>
        {
            ShopPanel.gameObject.SetActive(false);
        });
    }

    public void FixedRun()
    {
    }

    public void Run()
    {
    }
}
