using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLooper : MonoBehaviour
{
    public bool spawned;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&!spawned)
        {
            Instantiate(gameObject,transform.position+new Vector3(1000,0,0),Quaternion.identity);
            spawned = true;
        }
    }
}
