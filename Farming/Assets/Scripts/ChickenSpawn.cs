using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenSpawn : MonoBehaviour
{
    public GameObject chicken; // 要实例化的预制体
    public int numberOfInstances = 10;     // 实例化的数量

    public float planeWidth = 4f;         // 平面宽度
    public float planeLength = 4f;        // 平面长度
    private float waitTime = 3.0f;

    private void Start()
    {
        StartCoroutine(InstanceChicken());
    }

    private IEnumerator InstanceChicken()
    {
        for (int i = 0; i < numberOfInstances; i++)
        {
            // 生成随机位置
            Vector3 randomPos = GetRandomPositionOnPlane();

            GameObject newInstance = Instantiate(chicken, randomPos, Quaternion.identity);

            // 如果预制体有NavMeshAgent组件，确保它被启用
            NavMeshAgent agent = newInstance.GetComponent<NavMeshAgent>();
            yield return new WaitForSeconds(waitTime);
        }

    }

    Vector3 GetRandomPositionOnPlane()
    {
        // 在平面上生成随机X和Z坐标
        float randomX = Random.Range(-planeWidth / 2, planeWidth / 2);
        float randomZ = Random.Range(-planeLength / 2, planeLength / 2);

        // 返回完整的3D位置
        return new Vector3(randomX, 0, randomZ);
    }
}
