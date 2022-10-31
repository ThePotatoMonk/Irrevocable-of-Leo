using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    int coinAmount;

    private void OnEnable()
    {
        Coin.OnCoinCollected += IncreaseCoins;

    }

    private void OnDisable()
    {
        Coin.OnCoinCollected -= IncreaseCoins;
    }


    // Increase coins
    public void IncreaseCoins()
    {

        coinAmount++;
        coinText.text = $"{coinAmount}";
    }
}
