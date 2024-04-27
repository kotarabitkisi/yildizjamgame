using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
   
    [SerializeField] 
    public GameObject Item;
    public Vector3 Loc;

    void Start()
    {
        Instantiate(Item, Loc, quaternion.identity);
    }

    void Update()
    {
    }
}
