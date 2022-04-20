using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    // STAT
    [SerializeField] public float damage = 20f;
    [SerializeField] public float expiration = 2.1f;
    [SerializeField] public float speed = 30;
    [SerializeField] public float bullet_cooldown = 0.3f;
    //
    virtual public void disableDammage() {boxCollider.enabled = false;}
    virtual public void enableDammage() {boxCollider.enabled = true;}
    //
    protected BoxCollider2D boxCollider;
    public Transform playerPos;
    protected Rigidbody2D rb;
    protected Animator animator;
    //protected SpriteRenderer spriteRenderer;
    protected int contact_hash = Animator.StringToHash("contact");

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        expiration += Time.time;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    /*public void setRot(float rot)
    {
        rb.rotation = rot;
    }*/
    
    public Vector2 velos;
    virtual public void onContact(Enemy enemyTouched) {}
    virtual public void afterCreation(){}
    virtual public void MyUpdate(){}

    private void Update() {
        MyUpdate();
    }
    
    //public virtual void magicChanged(){}
    Enemy enemyBuff;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag  == "Enemy") {
            enemyBuff = other.gameObject.GetComponent<Enemy>();
            enemyBuff.takeDamage(damage);
            onContact(enemyBuff);
        }
           
    }
}
