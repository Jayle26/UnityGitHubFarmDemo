using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    public Item item;
    public Bag myBag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.haveMeatCount++;
            player.UpdateMeat();
            item.itemNum++;
            Destroy(this.gameObject, 0.5f);
            if (!myBag.itemList.Contains(item))
            {
                //从头开始检索一个空背包的格子出来，放thisItem
                for (int i = 0; i < myBag.itemList.Count; i++)
                {
                    if (myBag.itemList[i] == null)
                    {
                        myBag.itemList[i] = item;
                        break;
                    }
                }
            }
            InventoryManager._instance.UpDateInventory();
        }
    }
}
