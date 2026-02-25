using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager _instance;
    private void Awake()
    {
        _instance = this;
    }
    private Texture2D cursor_normal;
    private Texture2D cursor_talk;
    private Texture2D cursor_pick;
    private Vector2 hotspot = Vector2.zero;
    private CursorMode cursorMode = CursorMode.Auto;
    // Start is called before the first frame update
    void Start()
    {
        cursor_normal = Resources.Load<Texture2D>(Tags.normal);
        cursor_talk = Resources.Load<Texture2D>(Tags.talk);
        cursor_pick = Resources.Load<Texture2D>(Tags.pick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetNormalCursor()
    {
        Cursor.SetCursor(cursor_normal, hotspot, cursorMode);
    }
    public void SetTalkCursor()
    {
        Cursor.SetCursor(cursor_talk, hotspot, cursorMode);
    }
    public void SetPickCursor()
    {
        Cursor.SetCursor(cursor_pick, hotspot, cursorMode);
    }
}
