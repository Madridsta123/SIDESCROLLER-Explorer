using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperAttack : MonoBehaviour
{
    Animator animator;
    float attackDelay;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("CanAttack", true);
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.damagePlayer();
            attackDelay = Time.time + 1f;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Time.time > attackDelay)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.damagePlayer();
            attackDelay = Time.time + 1f;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") animator.SetBool("CanAttack", false);
    }
}
