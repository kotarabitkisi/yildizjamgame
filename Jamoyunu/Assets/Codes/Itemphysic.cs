using UnityEngine;

public class Itemphysic : MonoBehaviour
{
    public Color color;
    public SpriteRenderer renderer;
    public float colortime;
    public bool died,canpick;
    public float picktime,tim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (collision.gameObject.layer == 3 && gameObject.tag == "Projectile")
            {
                died = true;
            }
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && gameObject.tag == "Projectile")
        {
            died = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (collision.gameObject.tag=="Enemy" && gameObject.tag == "Projectile")
        {
            collision.gameObject.GetComponent<EnemyStats>().die();
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (died)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            colortime += Time.deltaTime;
            renderer.color = Color.Lerp(Color.white, color, colortime);
            if (colortime >= 4)
            {
                Destroy(this.gameObject);
            }
        }
        tim += Time.deltaTime;
        if (tim > picktime)
        {
            canpick = true;
        }
    }
}
