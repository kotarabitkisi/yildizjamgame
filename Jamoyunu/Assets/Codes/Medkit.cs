using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    
    [SerializeField]
    public float Value;
    public float Duration;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            PlayerStat stat = Player.GetComponent<PlayerStat>();
            stat.medkit = true;
            stat.LoseSpeed = Value;
            stat.LoseSpeedTime = Duration;
            Destroy(gameObject);
        }
    }
}