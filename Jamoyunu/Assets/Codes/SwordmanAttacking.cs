using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SwordmanAttacking : MonoBehaviour
{
    public bool isAttacking;
    public GameObject Sword;
    public GameObject Player;
    public float distancetoat,distancetosee;
    public Rigidbody2D rb;
    public float movespeed,range;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        range=Mathf.Abs(Player.transform.position.x - transform.position.x);
        if ( range< distancetosee)
        {
            rb.velocity = new Vector2((Player.transform.position.x - transform.position.x) * movespeed, rb.velocity.y);
        }
        if(Player.transform.position.x - transform.position.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (range < distancetoat && !isAttacking)
        {
            StartCoroutine(AttackAnim());
        }
    }
    public IEnumerator AttackAnim()
    {
        isAttacking = true;
        Sword.transform.DOLocalRotate(new Vector3(0, 0, -120), 0.2f);
        yield return new WaitForSecondsRealtime(0.2f);
        Sword.transform.DOLocalRotate(new Vector3(0, 0, 20), 0.2f);
        yield return new WaitForSecondsRealtime(0.2f);
        isAttacking = false;
    }
}
