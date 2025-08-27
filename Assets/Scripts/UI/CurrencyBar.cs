using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyBar : MonoBehaviour
{
    [SerializeField] private Image coinIcon;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private Button coinIncreaseButton;

    [SerializeField] private Image diamondIcon;
    [SerializeField] private TMP_Text diamondText;
    [SerializeField] private Button diamondIncreaseButton;

    public void UpdateCurrencyNumber()
    {
        PlayerData playerData = GameDataManager.Instance.PlayerData;

        SetCurrencyNumber(playerData.Coin, playerData.Diamond);
    }
    public void SetCurrencyNumber(int coin, int diamond)
    {
        coinText.text = coin.ToString();
        diamondText.text = diamond.ToString();
    }

}
