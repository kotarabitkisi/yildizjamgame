using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private float speed,range, carpan;
    private GameObject Player;
    void Start()
    {
        float multiple = carpan * (1 + Time.time / 100);
        speed = multiple * 0.5f;
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(Mathf.Abs(Player.transform.position.x- transform.position.x) > range)
        {

        }
        transform.Translate(speed*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerStat>().Adrenaline = 0;
            Player.GetComponent<PlayerStat>().die();
        }
    }
}
