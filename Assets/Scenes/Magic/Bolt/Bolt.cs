using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : Missile
{
    // Start is called before the first frame update
   
    public UnityEngine.Experimental.Rendering.Universal.Light2D[]  my_light;
    private ParticleSystem[] particleSystems;

    void Start()
    {   
        animator.SetFloat("Blend", 0);
        my_light = GetComponentsInChildren<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        particleSystems = GetComponentsInChildren<ParticleSystem>();
    }

    public void startTrail()
    {
        particleSystems[0].Play();
    }
    public void stopTrail()
    {
        particleSystems[0].Stop();
        particleSystems[1].Play();
    }
    override public void afterCreation()
    {
        base.afterCreation();
        my_light[0].intensity = 0.8f;
    }

    public override void onContact(Enemy enemy)
    {
        base.onContact(enemy);
        my_light[0].intensity = 0f;
        my_light[1].intensity = 1f;
    }

    public override void MyUpdate()
    {
        if(state == State.CONTACT) {
            my_light[1].intensity+= 0.5f;
        }
    }
  
    // Update is called once per frame
    //void Update()
    //{
    //    
    //}
}
