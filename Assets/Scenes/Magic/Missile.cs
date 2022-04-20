using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Magic
{
    // Start is called before the first frame update
    
    protected enum State {
        CREATION,
        FLYNG,
        CONTACT
    };
    protected State state = State.CREATION;

    override public void afterCreation()
    {
        state = State.FLYNG;
        rb.velocity = velos * speed;
    }

    override public void onContact(Enemy enemy)
    {
        animator.SetTrigger(contact_hash);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        MyUpdate();
        if (state == State.CREATION) {
            //Debug.Log(Mathf.Cos(transform.eulerAngles.z) + Mathf.Sin(transform.eulerAngles.z));
            transform.position = new Vector3(playerPos.position.x + velos.x,
             playerPos.position.y +velos.y, 0);
        } 
        if ((state == State.FLYNG && rb.velocity.magnitude < 1) || Time.time > expiration)
            animator.SetTrigger(contact_hash);
    }

  
}
