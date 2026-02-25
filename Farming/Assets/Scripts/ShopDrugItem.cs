using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopDrugItem : MonoBehaviour
{
    public Item item;
    public TMP_InputField input;
    public string str;
    public Text commonText;
    public Bag myBag;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = item.itemImage;
        transform.GetChild(1).GetComponent<Text>().text = item.itemName;
        transform.GetChild(2).GetComponent<Text>().text = item.itemEffect;
        transform.GetChild(3).GetComponent<Text>().text = item.itemBuyPrice + "RMB";
    }

    public void OnOKButtonClick()
    {
        int buyCount = int.Parse(input.GetComponent<TMP_InputField>().text);
        int price = item.itemBuyPrice;
        int total = buyCount * price;
        if (total <=DataManger._instance.GetCoin())
        {
            str = "支付成功！";
            StartCoroutine(DisplayBuyInfo());
            //更新金币
            DataManger._instance.SetCoin(DataManger._instance.GetCoin() - total);
            for (int i = 0; i < buyCount; i++)
            {
                //item.itemNum++;
                //if (!myBag.itemList.Contains(item))
                //{
                //    //从头开始检索一个空背包的格子出来，放thisItem
                //    for (int j = 0; i < myBag.itemList.Count; j++)
                //    {
                //        if (myBag.itemList[j] == null)
                //        {
                //            myBag.itemList[j] = item;
                //            break;
                //        }
                //    }
                //}
                InventoryManager._instance.AddItem(item);
                InventoryManager._instance.UpDateInventory();
            }
        }
        else
        {
            str = "支付失败！";
            StartCoroutine(DisplayBuyInfo());
        }
    }
    IEnumerator DisplayBuyInfo()
    {
        commonText.gameObject.SetActive(true);
        commonText.text = str;
        yield return new WaitForSeconds(1.0f);
        commonText.gameObject.SetActive(false);
        commonText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
