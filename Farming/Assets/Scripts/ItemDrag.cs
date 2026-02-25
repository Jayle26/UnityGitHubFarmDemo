using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDrag : NPC,IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Transform originPosition;  //记录物品从哪个抽屉（Slot）拖出来的
    private int currentItemID;
    public Bag myBag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originPosition = transform.parent;
        currentItemID = originPosition.gameObject.GetComponent<Slot>().slotID;
        transform.position = eventData.position;
        transform.SetParent(transform.parent.parent);
        transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "ItemImage")  //交换
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originPosition);
                //数据交换
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originPosition.position;
                transform.position = eventData.pointerPressRaycast.gameObject.transform.parent.parent.position;
                transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")  //放空抽屉
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                //数据处理
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemList[currentItemID];
                if (currentItemID != eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID)
                {
                    myBag.itemList[currentItemID] = null;
                }


                transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
        }

        //回归原位
        transform.SetParent(originPosition);
        transform.position = originPosition.position;
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.OnMouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.OnMouseExit();
    }
}
