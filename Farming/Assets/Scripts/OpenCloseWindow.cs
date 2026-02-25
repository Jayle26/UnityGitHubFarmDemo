using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseWindow : MonoBehaviour
{
    public GameObject mybag;
    public GameObject shop;
    public Animator _animator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnOpenCloseButtonClick(mybag);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            OnOpenCloseButtonClick(shop);
        }
    }
    public void OnOpenCloseButtonClick(GameObject obj)
    {
        bool isOpen = obj.activeSelf;
        isOpen = !isOpen;
        obj.SetActive(isOpen);
        if(obj.name=="ShopPanel")
        {
            _animator.CrossFade("Shop_in", 0f);
        }
    }
}
