using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Item thisItem;
    public Bag myBag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTestButtonClick()
    {
        AddItem();
    }
    private void AddItem()
    {
        thisItem.itemNum++;
        if (!myBag.itemList.Contains(thisItem))
        {
            //从头开始检索一个空背包的格子出来，放thisItem
            for (int i = 0; i < myBag.itemList.Count; i++)
            {
                if (myBag.itemList[i] == null)
                {
                    myBag.itemList[i] = thisItem;
                    break;
                }
            }
            //myBag.itemList.Add(thisItem);
            //InventoryManager._instance.CreateNewItem(thisItem);
        }
        InventoryManager._instance.UpDateInventory();
    }
}
