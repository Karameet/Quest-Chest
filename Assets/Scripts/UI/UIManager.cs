using UnityEngine;

public class UIManager : StateMachineBase
{
    [SerializeField] private MainMenuPanel mainMenuPanel;
    [SerializeField] private ShopPanel shopPanel;
    [SerializeField] private InventoryPanel inventoryPanel;

    public StateMainMenu stateMenu;
    public StateShop stateShop;
    public StateInventory stateInventory;


    public void Init()
    {
        stateMenu = new StateMainMenu(this, mainMenuPanel);
        stateShop = new StateShop(this,shopPanel);
        stateInventory = new StateInventory(this, inventoryPanel);

        Subscribe();

        ChangState(stateMenu);
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        mainMenuPanel.Init();
        shopPanel.Init();
        inventoryPanel.Init();
    }

    public void UnSubscribe()
    {
        mainMenuPanel.Dispose();
        shopPanel.Dispose();
        inventoryPanel.Dispose();
    }
}
