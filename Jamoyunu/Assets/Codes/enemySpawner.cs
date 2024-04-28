using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Items;
    [SerializeField] GameObject[] Traps;
    public GameObject Player;
    public float range,reqrange;
    public GameObject[] spawningObj;
    public bool spawned;
    public float carpan;
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
                Instantiate(obj,this.transform.position,Quaternion.identity);
                float ihtimal=Random.Range(0f,100f);
                switch (ihtimal)
                {
                    case 0:
                        Instantiate(Items[Items.Length], transform.position + Random.Range(-25f, 25f) * Vector3.right + 5 * Vector3.up, Quaternion.identity);
                        break;
                    case <30 :
                        Instantiate(Items[Random.Range(0, Items.Length - 1)], transform.position + Random.Range(-25f, 25f) * Vector3.right + 5 * Vector3.up, Quaternion.identity);
                        break;
                    case <80 :
                        Instantiate(Traps[Random.Range(0, Traps.Length)], transform.position + Random.Range(-25f, 25f) * Vector3.right + 5 * Vector3.up, Quaternion.identity);
                        break;
                }
                
            }
            spawned = true;
        }
    }
}
