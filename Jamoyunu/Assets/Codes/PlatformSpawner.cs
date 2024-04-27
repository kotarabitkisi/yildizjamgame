using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public bool spawned;
    public Vector3 offset;
    public GameObject Player;
    public GameObject[] SpawnObj;
    public float range, reqRange;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        range=Mathf.Abs(Player.transform.position.x-transform.position.x);
        if (range < reqRange&&!spawned)
        {
            
            spawned = true;
            Instantiate(SpawnObj[Random.Range(0,SpawnObj.Length)],this.transform.position+offset,Quaternion.identity);
        }
    }
}
