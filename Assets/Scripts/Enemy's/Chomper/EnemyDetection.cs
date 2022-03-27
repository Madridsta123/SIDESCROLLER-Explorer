using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    ChomperMovement movement;
    Rigidbody2D rb;
    private void Start()
    {
        movement = GetComponent<ChomperMovement>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            movement.SetCanPatrol(false);
            if(collision.gameObject.transform.position.x>transform.position.x)
            {
                if (!movement.GetFacingRight())
                {
                    movement.Flip();
                }
                rb.velocity = new Vector2(movement.GetSpeed()*3, 0);
            }
            else if (collision.gameObject.transform.position.x < transform.position.x)
            {
                if (movement.GetFacingRight())
                {
                    movement.Flip();
                }
                rb.velocity = new Vector2(-movement.GetSpeed()*3, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            movement.SetCanPatrol(true);
        }
    }
}
