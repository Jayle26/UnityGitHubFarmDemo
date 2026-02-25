using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public Transform handPosition;
    public GameObject weapon;
    private GameObject currentWeapon;  //存储当前实例化的武器
    private bool haveWeapon = false;

    public float attackRange = 4f; // 攻击范围
    public int attackDamage = 100; // 攻击伤害

    public GameObject fence;
    private Vector3 fenceRotationAxis = Vector3.up;
    private Vector3 targetRotation1 = new Vector3(0, 180, 0); // 目标角度1
    private Vector3 targetRotation2 = new Vector3(0, 90, 0); // 目标角度2
    private bool isOpen = false;

    public float haveMeatCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InstanceWeapon();
        Attack();
        RotateFenceOnKeyPress();
    }
    public void InstanceWeapon()
    {
        //实例化武器
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (haveWeapon)
            {
                Destroy(currentWeapon);
                haveWeapon = false;
            }
            else
            {
                currentWeapon = Instantiate(weapon, handPosition.position, Quaternion.Euler(0f, -90f, -45f));
                currentWeapon.transform.parent = handPosition;
                haveWeapon = true;
                // 添加碰撞检测脚本
                WeaponCollider weaponCollider = currentWeapon.AddComponent<WeaponCollider>();
                weaponCollider.attackDamage = attackDamage;
            }
        }
        
    }
    public void Attack()
    {
        //攻击动画
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (haveWeapon)
            {
                animator.SetTrigger("isAttack");
                // 检测攻击范围内的鸡
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);
                foreach (Collider collider in hitColliders)
                {
                    Chicken chicken = collider.GetComponent<Chicken>();
                    if (chicken != null)
                    {
                        chicken.TakeDamage(attackDamage);
                    }
                }
            }
        }
    }
    public void RotateFenceOnKeyPress()  //开关门
    {
        if (Input.GetKeyDown(KeyCode.F) && fence != null)
        {
            if (isOpen)
            {
                // 绕自定义轴的Y轴旋转90度
                fence.transform.rotation = Quaternion.Euler(targetRotation1);
                fence.transform.position = new Vector3(2.18f, 0f, -5.5f);
                isOpen = false;
            }
            else
            {
                fence.transform.rotation = Quaternion.Euler(targetRotation2);
                fence.transform.position = new Vector3(3.3f, 0f, -6.8f);
                isOpen = true;
            }
        }
    }
    public void UpdateMeat()  //鸡肉
    {

    }
}
