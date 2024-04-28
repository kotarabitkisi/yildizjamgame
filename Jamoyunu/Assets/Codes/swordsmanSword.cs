using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordsmanSword : MonoBehaviour
{
    public GameObject BloodEffect;
    public EnemyStats stats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<PlayerStat>().Immortal)
            {
                GameObject BEffect = Instantiate(BloodEffect, collision.gameObject.transform.position, transform.rotation);
                Destroy(BEffect, 0.9f);
                collision.gameObject.GetComponent<PlayerStat>().Adrenaline -= stats.damage;
                collision.gameObject.GetComponent<PlayerStat>().LoseSpeed*=1.3f ;
            }
            
        }
    }
}
