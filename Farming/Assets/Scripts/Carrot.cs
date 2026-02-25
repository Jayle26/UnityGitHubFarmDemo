using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Item item;
    public Bag myBag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseEnter()
    {
        CursorManager._instance.SetPickCursor();
    }
    public void OnMouseExit()
    {
        CursorManager._instance.SetNormalCursor();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
