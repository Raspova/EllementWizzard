using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public struct stat_t {
        public float Health;
        public float HealthMax;
        public float Attak;
        public float Attak_speed;
        public float speed;
    };
    protected Animator animator;
    protected SpriteRenderer _renderer;
    protected Rigidbody2D rb;
    protected int moving_hash = Animator.StringToHash("moving");
    protected int horizontal_hash = Animator.StringToHash("Horiz");
    protected int vertical_hash = Animator.StringToHash("Vertical");
    protected int speed_hash = Animator.StringToHash("speed");
    protected int attack_hash = Animator.StringToHash("attack");
    protected int death_hash = Animator.StringToHash("death");
 
    [SerializeField] float speed;
    [SerializeField] int Health;
    [SerializeField] int Attak;
    [SerializeField] float Attak_speed;
    public stat_t character_stat;
    public Vector3 originalPos;

    void Start()
    {
        init();
    }
    //public Vector3 originalPos;
    public void init()
    {
        character_stat.Health = Health;
        character_stat.HealthMax = Health;
        character_stat.Attak = Attak;
        character_stat.Attak_speed = Attak_speed;
        character_stat.speed = speed;
        animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position;
    }
    // Update is called once per frame
    public void desativate()
    {
    }   
        
    public virtual void death()
    {   
        gameObject.SetActive(false);
        transform.position = originalPos;
        character_stat.Health = Health;
    }

    bool red_effet_bool = false;
    float red_effet_buff;
    virtual public void takeForce(Vector2 direction, float force)
    {
        Debug.Log("Force " + direction * force);
        rb.AddForce(direction * force);
    }

    virtual public void takeDamage(float dmg)
    {
        _renderer.color = Color.red;
        character_stat.Health -= dmg;
        red_effet_buff = Time.time + 0.1f;
        red_effet_bool = true;
    }

    private void OnDisable() 
    {
    }
    


    protected void updateCha()
    {
        if (character_stat.Health <= 0)
            animator.SetBool(death_hash, true);
        if (red_effet_bool && Time.time > red_effet_buff)
            _renderer.color = Color.white;
    }
}
