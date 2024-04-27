using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    public float Adrenaline;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<CircleCollider2D>().isTrigger = true;
            }
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerStat>().Adrenaline += Adrenaline;
            Destroy(gameObject);
        }
    }
}
