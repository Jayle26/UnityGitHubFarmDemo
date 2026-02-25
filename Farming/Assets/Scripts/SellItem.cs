using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellItem : MonoBehaviour
{
    public Item item;
    public TMP_InputField input;
    public string str;
    public Text commonText;
    public Bag myBag; // 引用背包

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public void OnOKButtonClick()
    {
        int sellCount = int.Parse(input.GetComponent<TMP_InputField>().text);
        int price = item.itemSellPrice;
        int total = sellCount * price;
        if (sellCount <= item.itemNum)
        {
            str = "出售成功！";
            StartCoroutine(DisplaySellInfo());
            //更新金币
            DataManger._instance.SetCoin(DataManger._instance.GetCoin() + total);
            //更新单个物品数量
            UpdateUI();
            for (int i = 0; i < sellCount; i++)
            {
                InventoryManager._instance.SubItem(item);
            }
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
        else
        {
            str = "出售数量超过拥有数量！";
            StartCoroutine(DisplaySellInfo());
        }
        InventoryManager._instance.UpDateInventory();
    }

    IEnumerator DisplaySellInfo()
    {
        commonText.gameObject.SetActive(true);
        commonText.text = str;
        yield return new WaitForSeconds(1.0f);
        commonText.gameObject.SetActive(false);
        commonText.text = "";
    }
    public void UpdateUI()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = item.itemImage;
        transform.GetChild(1).GetComponent<Text>().text = item.itemName;
        transform.GetChild(2).GetComponent<Text>().text = item.itemNum.ToString();
        transform.GetChild(3).GetComponent<Text>().text = item.itemSellPrice + "RMB";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
}