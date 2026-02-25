using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    public bool isOver = false;
    public RectTransform tooltip;
    public Text tooltipText;
    public Image tooltipImage;
    public Text descriptionText;
    private int currentItemID;
    public Bag myBag;
    public GameObject chicken;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {

        tooltip = GameObject.Find("Canvas/Bag/DescribeBG/tooltip").GetComponent<RectTransform>();
        tooltipImage = GameObject.Find("Canvas/Bag/DescribeBG/tooltip/ItemImage").GetComponent<Image>();
        tooltipText = GameObject.Find("Canvas/Bag/DescribeBG/tooltip/tooltipText").GetComponent<Text>();
        descriptionText = GameObject.Find("Canvas/Bag/DescribeBG/tooltip/DescriptionText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (item.itemNum == 0)
        {
            // 从背包中移除该物品
            for (int i = 0; i < myBag.itemList.Count; i++)
            {
                if (myBag.itemList[i] == item)
                {
                    myBag.itemList[i] = null;
                    break;
                }
            }
        }
    }
    public void OnButtonClick()
    {
        currentItemID = transform.parent.GetComponent<Slot>().slotID;
        isOver = true;
        if (isOver)
        {
            //更新数据
            tooltipText.text = "物品名称:" + myBag.itemList[currentItemID].itemName +
                "\n效果:" + myBag.itemList[currentItemID].itemEffect +
                "\n出售价:" + myBag.itemList[currentItemID].itemSellPrice +
                "\n购买价:" + myBag.itemList[currentItemID].itemBuyPrice;
            descriptionText.text = "描述信息:" + myBag.itemList[currentItemID].itemDescription;
            //显示
            tooltip.gameObject.SetActive(true);
            tooltipImage.sprite = myBag.itemList[currentItemID].itemImage;
        }
        else
        {
            tooltip.gameObject.SetActive(false);
        }
    }
    public void OnUseButtonClick()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);
        Instantiate(chicken, spawnPosition, Quaternion.identity);
        item.itemNum--;
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
