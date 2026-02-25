using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Camera minimapCamera;
    public float size;
    private void Start()
    {
        size = minimapCamera.orthographicSize;
    }
    public void AddCamera()
    {
        size += 1.0f;
        minimapCamera.orthographicSize = Mathf.Clamp(size, 5f, 60f);
    }
    public void SubCamera()
    {
        size -= 1.0f;
        minimapCamera.orthographicSize = Mathf.Clamp(size, 5f, 60f);
    }
}
