using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public float Value;
    private GameObject Player;
    void Start()
    {
        source = GetComponent<AudioSource>();
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
            source.PlayOneShot(clip);
            PlayerStat stat = Player.GetComponent<PlayerStat>();
            stat.mushroom = true;
            stat.ImmortalTime = Value;
            stat.Immortal = true;
            Destroy(gameObject);
        }
    }
}
