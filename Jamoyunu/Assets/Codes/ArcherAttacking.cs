using UnityEngine;

public class ArcherAttacking : MonoBehaviour
{
    public Animator animator;
    public EnemyStats stats;
    public float range;
    public GameObject Player;
    public float distancetoat, distancetosee, handleTime, throwspeed;
    public Rigidbody2D rb;
    public bool handling;
    public GameObject bow, bowItem;
    public float movespeed;
    public float maxspeed;
    public int arrowcount;
    public float carpan;
    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        Player = GameObject.FindGameObjectWithTag("Player");
        float multiple = carpan * (1 + Time.time/100);
        movespeed = multiple*0.5f;
        stats.damage = multiple * 5;

    }
    private void Update()
    {
        range = Mathf.Abs(Player.transform.position.x - transform.position.x);
        if (range < distancetosee)
        {
            rb.velocity = new Vector2((Player.transform.position.x - transform.position.x) * movespeed, rb.velocity.y);
            
            animator.SetBool("Running",true);
        }
        else { animator.SetBool("Running", false); }


        if (range < distancetoat&&!stats.died)
        {
            Vector2 PlayerPos = Player.transform.position;
            float angle = Mathf.Atan2(PlayerPos.y - bow.transform.position.y,PlayerPos.x - bow.transform.position.x) * Mathf.Rad2Deg;
            bow.transform.rotation = Quaternion.Euler(0, 0, angle);
            handling = true;
            if (Player.transform.position.x - transform.position.x < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        if (handling && bow.transform.childCount != 1)
        {

            bowItem = bow.transform.GetChild(1).gameObject;
            bowItem.SetActive(true);
            handleTime += Time.deltaTime;
            bowItem.transform.localPosition = new Vector3(0.5f - handleTime * 3 / 4, 0, 0);
        }
        if (handleTime >= 1)
        {
            handling = false;

            bowItem.tag = "Projectile";
            handling = false;
            Rigidbody2D bowrb = bowItem.GetComponent<Rigidbody2D>();
            bowrb.constraints = RigidbodyConstraints2D.None;
            bowrb.velocity = bow.transform.right * handleTime * throwspeed;
            handleTime = 0;
            bowrb.simulated = true;
            bowItem.transform.parent = null;
            bowItem = null;

        }
    }

}
