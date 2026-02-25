using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowCamer : MonoBehaviour
{
    public  Transform player;
    private Vector3 offset;
    public float distance;
    public float scrollSpeed = 1f;
    private bool isRotate = false;
    public float xAngle;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
        transform.LookAt(player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;


        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //鼠标的镜头拉近拉远
            distance = offset.magnitude;

            distance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

            distance = Mathf.Clamp(distance, 4.0f, 30.0f);

            offset = distance * offset.normalized;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }


        if (isRotate)
        {
            //右键的选择(左右)
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X"));

            Vector3 prePosition = transform.position;
            Quaternion preRotation = transform.rotation;

            //右键的选择(上下)

            transform.RotateAround(player.position, transform.right, Input.GetAxis("Mouse Y"));
            xAngle = transform.eulerAngles.x;
            if (xAngle < 12f || xAngle > 70)
            {
                transform.position = prePosition;
                transform.rotation = preRotation;
            }

            offset = transform.position - player.position;

        }
    }
}
