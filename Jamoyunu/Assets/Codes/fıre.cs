using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    
    [SerializeField]
    public float Value;
    public float Duration;
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
            PlayerStat stat = Player.GetComponent<PlayerStat>();
            stat.defaultlosespeed = stat.LoseSpeed;
            stat.fire = true;
            stat.LoseSpeed *= Value;
            stat.firetimer = Duration;
        }
    }
}
