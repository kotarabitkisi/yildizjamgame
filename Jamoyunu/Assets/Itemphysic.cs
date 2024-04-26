using UnityEngine;

public class Itemphysic : MonoBehaviour
{
    public Color color;
    public SpriteRenderer renderer;
    public float colortime;
    public bool died;
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

    }
    private void Update()
    {
        if (died)
        {
            colortime += Time.deltaTime;
            renderer.color = Color.Lerp(Color.white, color, colortime);
            if (colortime >= 4)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
