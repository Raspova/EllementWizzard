using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Missile
{
    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("Blend", 1);
    }

    public void unlockRot()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }
   
}
