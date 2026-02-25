using UnityEngine;

public enum ItemType { Durg, Quip, Mat }

[CreateAssetMenu(fileName = "New Item", menuName = "GameData/Inventory/New Item")]

public class Item : ScriptableObject
{
    public int itemID;
    public string itemName;
    public Sprite itemImage;
    public ItemType itemType;
    public int itemNum;
    public string itemEffect;
    public int itemSellPrice;
    public int itemBuyPrice;
    [TextArea]
    public string itemDescription;
}
