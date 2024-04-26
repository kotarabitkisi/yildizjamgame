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
    private void Update()
    {
        if(Mathf.Abs(Player.transform.position.x - transform.position.x) < distancetosee)
        {
            rb.velocity = new Vector2(Player.transform.position.x - transform.position.x,0);
        }
        if(Player.transform.position.x - transform.position.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        print(Player.transform.position.x - transform.position.x);
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < distancetoat && !isAttacking)
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
