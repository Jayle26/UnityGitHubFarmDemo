using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject miniMap;
    public GameObject maxMap;
    public Camera minimapCamera;
    public GameObject Player;
    private float size;
    private float value;  //转动鼠标中键产生的值
    private float height = 10f;
    // Start is called before the first frame update
    void Start()
    {
        size = minimapCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (miniMap.activeSelf)
            {
                miniMap.SetActive(false);
                maxMap.SetActive(true);
            }
            else
            {
                miniMap.SetActive(true);
                maxMap.SetActive(false);
            }
        }
        if (maxMap.activeSelf)
        {
            value = Input.GetAxis(Tags.scrollwheel);
            if (value < 0)
            {
                size -= 2.0f;
            }
            else if (value > 0)
            {
                size += 2.0f;
            }
            minimapCamera.orthographicSize = Mathf.Clamp(size, 2f, 100f);
        }
        if (Player == null) return; // 防止角色未赋值

        // 跟随角色的X和Z坐标，保持Y轴高度
        Vector3 newPos = new Vector3(Player.transform.position.x,height,Player.transform.position.z);
        minimapCamera.transform.position = newPos;
    }

    public static class Tags
    {
        public static string scrollwheel = "Mouse ScrollWheel";
    }
}
