using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellNPC : NPC
{
    public GameObject sellPanel;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sellPanel.SetActive(true);
        }
    }
    public void OnCloseButtonClick()
    {
            sellPanel.SetActive(false);
    }
    public void OnSellButtonClick(GameObject obj) //显示OK的UI
    {
        SellItem[] numDialog = obj.transform.parent.GetComponentsInChildren<SellItem>();
        foreach (var item in numDialog)
        {
            item.transform.GetChild(8).gameObject.SetActive(false);
        }
        obj.transform.GetChild(8).gameObject.SetActive(true);
    }
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
