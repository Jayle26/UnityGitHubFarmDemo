using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveWindow : MonoBehaviour,IDragHandler
{
    private RectTransform currentRec;

    public void OnDrag(PointerEventData eventData)
    {
        currentRec.anchoredPosition += eventData.delta;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentRec = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
