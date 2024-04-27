using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float angle;
    [SerializeField] Transform target;
    [SerializeField] GameObject bow;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector3 movevector;
    [SerializeField] float speed, JumpForce;
    [SerializeField] bool canjump;
    [SerializeField] Attacking attscript;
    void Update()
    {
        #region bakmavehareket
        movevector.x = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && canjump)
        {
            Jump();
        }
        rb.velocity = new Vector2(speed * movevector.x, rb.velocity.y);
        if (!attscript.isAttacking)
        {
            Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = Mathf.Atan2(mouse_pos.y - bow.transform.position.y, mouse_pos.x - bow.transform.position.x) * Mathf.Rad2Deg;
            target.transform.rotation = Quaternion.Euler(0,0,angle);
            if (mouse_pos.x - transform.position.x < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        #endregion
    }
    void Jump()
    {
        canjump = false;
        rb.velocity = rb.velocity + Vector2.up * JumpForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            canjump = true;
        }
    }
}