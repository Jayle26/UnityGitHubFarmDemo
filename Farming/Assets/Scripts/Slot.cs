using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;  //slot的所有信息
    public Image slotImage;
    public Text slotNum;
    public GameObject itemInSlot;
    public int slotID;//抽屉编号，用于Bag ItemList的下标对应
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnItemButtonClick()
    {
        InventoryManager._instance.UpDateItemDescription(slotItem.itemDescription);
    }
    public void UpdateSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemNum.ToString();
        //slotID = item.itemID;
    }
}
