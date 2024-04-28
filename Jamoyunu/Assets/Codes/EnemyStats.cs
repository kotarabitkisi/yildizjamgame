using DG.Tweening;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public PlayerStat Player;
    public bool died;
    public AudioSource Itemsound;
    public AudioClip Enemydeathsound, Enemydeathsound2;
    public GameObject Item;
    public float damage;
    public Color color;
    public SpriteRenderer renderer;
    public float colortime;
    private void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>();
    }
    public void die()
    {
        Player.score += 5;
        Player.KillCounter++;
        damage = 0;
        died = true;
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (Random.Range(0, 2) == 0)
        {
            Itemsound.PlayOneShot(Enemydeathsound);
        }
        else { Itemsound.PlayOneShot(Enemydeathsound2); }
        if (PlayerObj.transform.position.x > transform.position.x)
        {
            transform.DORotate(new Vector3(0, 180, -90), 0.2f);
            transform.DOMoveY(transform.position.y - 0.5f, 0.2f);
        }
        else
        {
            transform.DORotate(new Vector3(0, 0, -90), 0.2f);
            transform.DOMoveY(transform.position.y - 0.5f, 0.2f);
        }
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        PlayerObj.GetComponent<PlayerStat>().Adrenaline += 10;
        GameObject fallenitem = Instantiate(Item, this.gameObject.transform.position, Quaternion.identity);
        fallenitem.tag = "Item";
        Destroy(this.gameObject, 3);
    }
    private void Update()
    {
        if (died)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            colortime += Time.deltaTime;
            renderer.color = Color.Lerp(Color.white, color, colortime);
            if (colortime >= 4)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
