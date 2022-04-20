using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallinglight : Bombing
{
    // Start is called before the first frame update
   
    public UnityEngine.Experimental.Rendering.Universal.Light2D[]  my_light;


    void Start()
    {   
        baseStart();
        my_light = GetComponentsInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
    }

    override public void afterCreation()
    {
        base.afterCreation();
    
    }

    public override void disableDammage()
    {
        base.disableDammage();
        my_light[0].enabled = false;

    }
    public override void onContact(Enemy enemy)
    {
        base.onContact(enemy);
    }

    public override void MyUpdate()
    {
        if (my_light[0].enabled)
            my_light[0].intensity+=0.005f;
    }
   
    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
}
