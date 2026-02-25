using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : NPC
{
    public Animator _animator;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.CrossFade("Shop_in", 0f);
        }
    }
    public void OnCloseButtonClick()
    {
            _animator.CrossFade("Shop_out", 0f);
    }
    public void OnBuyButtonClick(GameObject obj) //显示OK的UI
    {
        ShopDrugItem[] numDialog = obj.transform.parent.GetComponentsInChildren<ShopDrugItem>();
        foreach (var item in numDialog)
        {
            item.transform.GetChild(8).gameObject.SetActive(false);
        }
        obj.transform.GetChild(8).gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
