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
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerStat>().Adrenaline += Adrenaline;
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
