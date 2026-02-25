using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager _instance;
    public Text coinText;
    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpDateInventory();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Slot slot;
    public Transform slotGrid;
    public Text DescriptionText;
    public Bag myBag;
    public List<Slot> slots = new List<Slot>();

    public void AddItem(Item thisItem)
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
        }
        InventoryManager._instance.UpDateInventory();
    }
    public void SubItem(Item thisItem)
    {
        thisItem.itemNum--;
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
        }
        InventoryManager._instance.UpDateInventory();
    }

    public void UpDateInventory()
    {
        //删除
        for (int i = 0; i < slotGrid.childCount; i++)
        {
            Destroy(slotGrid.GetChild(i).gameObject);
        }
        slots.Clear();
        for (int i = 0; i < myBag.itemList.Count; i++)
        {
            slots.Add(Instantiate(slot));
            slots[i].transform.SetParent(slotGrid);
            //根据mybag，更新每一个slot （mybag里第i个数据-----第i个背包slot对应）
            slots[i].slotID = i;
            slots[i].UpdateSlot(myBag.itemList[i]);
        }
        //更新金币
        coinText.text = DataManger._instance.GetCoin().ToString();
    }
    public void UpDateItemDescription(string description)
    {
        DescriptionText.text = description;
    }
}
