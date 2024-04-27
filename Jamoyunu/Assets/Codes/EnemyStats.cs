using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    
    public GameObject Item;
    public float damage;
    public void die()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerStat>().Adrenaline += 10;
      GameObject fallenitem = Instantiate(Item,this.gameObject.transform.position,Quaternion.identity);
        fallenitem.tag = "Item";
        Destroy(this.gameObject);
    }

}
