using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int coin;
    public int Coin => coin;

    [SerializeField] private int diamond;
    public int Diamond => diamond;

    [SerializeField] private List<ItemData> playerItem;

    public List<ItemData> PlayerItem => playerItem;

    public void AddItem(ItemData itemData)
    {
        playerItem.Add(itemData);
    }

    public void DecreaseCoin(int num)
    {
        coin -= num;
    }

    public void DecreaseDiamond(int num)
    {
        diamond -= num;
    }
}
