using DG.Tweening;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class SwordmanAttacking : MonoBehaviour
{
    public Animator animator;
    public EnemyStats stats;
    public bool isAttacking;
    public GameObject Sword;
    public GameObject Player;
    public float distancetoat,distancetosee;
    public Rigidbody2D rb;
    public float movespeed,range,carpan;

    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        Player = GameObject.FindGameObjectWithTag("Player");
        float multiple = carpan * (1 + Time.time/100);
        movespeed = multiple * 0.5f;
        stats.damage = multiple * 5;
        
    }
    private void Update()
    {
        range = Mathf.Abs(Player.transform.position.x - transform.position.x);
        if (range < distancetosee)
        {
            rb.velocity = new Vector2((Player.transform.position.x - transform.position.x) * movespeed, rb.velocity.y);
            animator.SetBool("Walking", true);
        }
        else { animator.SetBool("Walking", false); }

        if (Player.transform.position.x - transform.position.x < 0 && !stats.died)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(!stats.died)
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
