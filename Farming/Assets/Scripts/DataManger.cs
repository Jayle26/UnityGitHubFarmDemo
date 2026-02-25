using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger _instance;

    public PlayerStatus playerStatus;
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
        playerStatus = (PlayerStatus)Resources.Load("PlayerStatus");
    }
    void Start()
    {
        
    }
    public int GetCoin()
    {
        return playerStatus.coin;
    }
    public void SetCoin(int coin)
    {
        playerStatus.coin = coin;
        InventoryManager._instance.UpDateInventory();
    }
}
