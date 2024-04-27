using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject Player;
    public float range,reqrange;
    public GameObject[] spawningObj;
    public bool spawned;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        range = Mathf.Abs(Player.transform.position.x-transform.position.x);
        if (range < reqrange&&!spawned)
        {
            foreach (var obj in spawningObj)
            {
                Instantiate(obj,this.transform.position+Random.Range(-1f,1f)*Vector3.right,Quaternion.identity);
            }
            spawned = true;
        }
    }
}
