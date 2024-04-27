using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private float speed,range;
    private GameObject Player;
    void Start()
    {
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
            //Player.GetComponent<PlayerStat>().isdead = true;
        }
    }
}
