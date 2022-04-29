using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins: MonoBehaviour
{
    
    public GameObject player;
    PlayerCoin playerCoin;
    private TextMeshProUGUI displayCoins;


    private void Awake()
    {
        displayCoins = GetComponent<TextMeshProUGUI>();
       playerCoin =  player.GetComponent<PlayerCoin>();
    }
    

    void Update() 
    {
      //Debug.Log(playerCoin.collectedCoin);
        displayCoins.text = "Coin x " + playerCoin.collectedCoin.ToString();  
    }
}
