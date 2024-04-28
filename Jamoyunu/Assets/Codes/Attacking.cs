using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public AudioSource AttackSource;
    public AudioClip Attacksound, higsound,itempicksound;
    [SerializeField] GameObject bowItem, bow;
    [SerializeField] float handleTime;
    [SerializeField] Vector2 throwvector;
    public bool handling, isAttacking;
    [SerializeField] float throwspeed;
    void Update()
    {
        if (bowItem != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                handling = true;
            }
            else if (Input.GetMouseButtonUp(0)&&handling)
            {
                bowItem.tag = "Projectile";
                handling = false;
                Rigidbody2D bowrb = bowItem.GetComponent<Rigidbody2D>();
                bowrb.constraints = RigidbodyConstraints2D.None;
                bowrb.velocity = bow.transform.right * handleTime * throwspeed;
                bowrb.simulated = true;
                bowItem.transform.parent = null;
                bowItem = null;
                handleTime = 0;
            }
        }
        else if (!isAttacking && Input.GetMouseButton(0))
        {
            AttackSource.PlayOneShot(higsound);
            StartCoroutine(AttackAnim());
        }

        if (handling)
        {
            handleTime += Time.deltaTime;
            handleTime = Mathf.Clamp(handleTime, 0, 1);
            bowItem.transform.localPosition = new Vector3(0.5f - handleTime * 3 / 4, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item"&&bowItem==null)
        {
            AttackSource.PlayOneShot(itempicksound);
            pickItem(collision.gameObject);
        }
    }
    void pickItem(GameObject PickedItem)
    {
        PickedItem.GetComponent<BoxCollider2D>().isTrigger = true;
        PickedItem.GetComponent<Rigidbody2D>().simulated = false;
        PickedItem.transform.parent = bow.transform;
        PickedItem.transform.localPosition = Vector3.zero + bow.transform.right * 0.25f;
        PickedItem.transform.localRotation = Quaternion.identity;
        bowItem = PickedItem;
    }
    public IEnumerator AttackAnim()
    {
        isAttacking = true;
        bow.transform.DOLocalRotate(new Vector3(0, 0, 20), 0.2f);
        yield return new WaitForSecondsRealtime(0.2f);
        bow.transform.DOLocalRotate(new Vector3(0, 0, -120), 0.2f);
        yield return new WaitForSecondsRealtime(0.2f);
        isAttacking = false;
    }
}
