using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] Attacking attackscr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (attackscr.isAttacking && collision.gameObject.tag=="Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().die();
        }
    }
}
