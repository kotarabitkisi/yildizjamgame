using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLooper : MonoBehaviour
{
    public GameObject[] buffitemandtraps;
    public GameObject platform;
    public bool spawned;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&!spawned)
        {
           GameObject spawnedplatform= Instantiate(gameObject,transform.position+new Vector3(1000,0,0),Quaternion.identity);
            for (int i = 0; i < 18; i++) {
                spawnedplatform.transform.GetChild(i).GetComponent<PlatformSpawner>().spawned = false;
                Instantiate(buffitemandtraps[Random.Range(0,buffitemandtraps.Length)],spawnedplatform.transform.position + Random.Range(-500f, 500f) * Vector3.right+Vector3.up*20,Quaternion.identity); 
            }
            spawned = true;
            
        }
    }
}
