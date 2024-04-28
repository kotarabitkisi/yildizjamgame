using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fire : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public float Value;
    public float Duration;
    private GameObject Player;
    public Color transparentcolor;
    public SpriteRenderer crenderer;
    public float speed;
    void Start()
    {
        source= GetComponent<AudioSource>();    
        crenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        crenderer.color = Color.Lerp(Color.white,transparentcolor,Mathf.Sin(0.5f*(1+Time.time*speed)));
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
            if (!stat.Immortal)
            {
stat.defaultlosespeed = stat.LoseSpeed;
            stat.fire = true;
            stat.LoseSpeed *= Value;
            stat.firetimer = Duration;
            }
            
        }
    }
}
