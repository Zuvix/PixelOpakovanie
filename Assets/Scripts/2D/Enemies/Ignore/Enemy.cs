using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigidBody;
    protected BoxCollider2D boxCollider2d;
    [SerializeField]
    protected int life=1;
    protected virtual void Awake()
    {
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }
    public virtual void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        boxCollider2d.enabled = false;
        Destroy(this.gameObject);
        rigidBody.velocity = Vector2.zero;
        this.enabled = false;
    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Void"))
        {
            Destroy(this.gameObject);
        }
    }
}
