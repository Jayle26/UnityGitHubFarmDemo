using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public void OnMouseEnter()
    {
        CursorManager._instance.SetTalkCursor();
    }
    public void OnMouseExit()
    {
        CursorManager._instance.SetNormalCursor();
    }
}
