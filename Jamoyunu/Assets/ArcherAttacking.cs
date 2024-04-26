using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class ArcherAttacking : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Player;
    public float distancetoat, distancetosee,handleTime,throwspeed;
    public Rigidbody2D rb;
    public bool handling;
    public GameObject bow,bowItem;
    private void Update()
    {
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < distancetosee)
        {
            rb.velocity = new Vector2(Player.transform.position.x - transform.position.x, 0);
        }
        if (Player.transform.position.x - transform.position.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        print(Player.transform.position.x - transform.position.x);
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < distancetoat && !handling)
        {
            Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mouse_pos.y - bow.transform.position.y, mouse_pos.x - bow.transform.position.x) * Mathf.Rad2Deg;
            bow.transform.localRotation = Quaternion.Euler(0, 0, angle);
            if (Input.GetMouseButtonUp(0))
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
        if (handling)
        {

        }
    }
}
