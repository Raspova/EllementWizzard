using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //[SerializeField] private float jumpingForce;
    
    [SerializeField] private HealthBar healthBar;
    Vector2 mouve;
    
    public UnityEngine.Experimental.Rendering.Universal.Light2D  my_light;

    private void Start()
    {
        base.init();
        healthBar.SetMaxHealth(character_stat.HealthMax);
        healthBar.refillHealth();
        my_light = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

   
    private void  Update()
    {
        updateCha();
        mouve.x = Input.GetAxis("Horizontal");
        mouve.y = Input.GetAxis("Vertical");
        if (mouve.x != 0) {
            animator.SetFloat(horizontal_hash, mouve.x);
            animator.SetFloat("Direction", (mouve.x < 0) ? 2 : 3);        
        }
        if (mouve.y != 0) {
            animator.SetFloat(vertical_hash, mouve.y);
            animator.SetFloat("Direction", (mouve.y > 0) ? 0 : 1);
        }
        //Debug.Log("life" + character_stat.Health);
        animator.SetFloat(speed_hash, mouve.sqrMagnitude);
    }

    override public void death()
    {
       Debug.Log("PLAYER DEAD X(");
       character_stat.Health = character_stat.HealthMax;
       healthBar.refillHealth();
    }

    public void setHozVert(float x, float y)
    {
        if (Mathf.Abs(x) > Mathf.Abs(y)) 
            animator.SetFloat("Direction", (x < 0) ? 2 : 3);        
        else
            animator.SetFloat("Direction", (y > 0) ? 0 : 1);
    }

    public override void takeDamage(float dmg)
    {
        base.takeDamage(dmg);
        healthBar.SetHealth(character_stat.Health);
    }
    private void FixedUpdate()
    {
        //Debug.Log("mouve : " + mouve.x + " " +mouve.y);
        rb.MovePosition(rb.position + mouve * character_stat.speed * Time.fixedDeltaTime);
    }
}
