using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Bag", menuName = "GameData/Inventory/My Bag")]

public class Bag : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
