using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    public GameObject meat;  //鸡肉
    private NavMeshAgent agent;
    public float wanderRadius = 10f;      // 随机游走半径
    public float minDistance = 0.5f;     // 到达目标的最小距离
    private float moveSpeed = 1.0f;

    public int hp = 100; // 鸡的血量
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            this.enabled = false;
            return;
        }
        agent.speed = moveSpeed;
        animator = GetComponent<Animator>();    
    }

    void Update()
    {
        if (agent.remainingDistance <= minDistance && !agent.pathPending)
        {
            SetNewDestination();
        }
    }

    public void SetNewDestination()
    {
        // 获取随机方向
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        transform.LookAt(randomDirection);

        // 在导航网格上找到最近的有效位置
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas);

        // 设置新目标
        agent.SetDestination(hit.position);
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        agent.isStopped = true; // 停止移动
        animator.SetTrigger("isDeath");

        Invoke("SpawnMeat", 1f);
        // 1.2秒后销毁对象
        Destroy(gameObject, 1.2f);
        transform.GetComponent<AudioSource>().Play();
    }
    public void  SpawnMeat()  //实例化鸡肉
    {
        //随机实例化 1 - 2 个鸡肉
        int numberOfItems = Random.Range(1, 3);
        float yOffset = 0.15f; // y 轴偏移量
        for (int i = 0; i < numberOfItems; i++)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
            Instantiate(meat, spawnPosition, Quaternion.identity);
        }
    }
}
