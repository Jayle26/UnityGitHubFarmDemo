using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    public int attackDamage;

    private void OnTriggerEnter(Collider other)
    {
        Chicken chicken = other.GetComponent<Chicken>();
        if (chicken != null)
        {
            chicken.TakeDamage(attackDamage);
        }
    }
}
