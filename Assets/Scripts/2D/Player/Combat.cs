using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Movement movement;
    Animator animator;
    int score=0;
    bool isAlive = true;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }
    void KillPlayer()
    {
        if (isAlive)
        {
            movement.enabled = false;
            rigidBody.velocity = Vector2.zero;
            //animator.SetBool("isDead", true);
            this.enabled = false;
            isAlive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void FallKillPlayer()
    {
        movement.enabled = false;
        this.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Debug.Log("Triggerd trap");
            ITrap trap = collision.gameObject.GetComponent<ITrap>();
            if (trap.IsActive())
            {
                KillPlayer();
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            Enemy enemyAffected = collision.gameObject.GetComponent<Enemy>();
            Vector2 enemyPos = collision.gameObject.transform.position;
            Vector2 playerPos = transform.position;
            float playerfallSpeed = rigidBody.velocity.y*-1;
            if(enemyPos.y < playerPos.y && playerfallSpeed > 0.2f)
            {
                enemyAffected.TakeDamage(1);
                movement.Bounce();
            }
            else
            {
                KillPlayer();
            }
        }
        if (collision.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            score++;
            Debug.Log("SCORE: " + score);
        }
        if (collision.CompareTag("Void"))
        {
            FallKillPlayer();
        }
    }
}
