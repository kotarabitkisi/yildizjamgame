using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    
    [SerializeField]
    public float Value;
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
            stat.mushroom = true;
            stat.ImmortalTime = Value;
            stat.Immortal = true;
            Destroy(gameObject);
        }
    }
}
