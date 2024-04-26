using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] Attacking attackscr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackscr.isAttacking &&collision.gameObject.CompareTag("Enemy"))
        {
            
        }
    }
}
