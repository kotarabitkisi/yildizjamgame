using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordsmanSword : MonoBehaviour
{
    public EnemyStats stats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStat>().Adrenaline -= stats.damage;
                collision.gameObject.GetComponent<PlayerStat>().LoseSpeed*=1.2f ;
        }
    }
}
