using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.Universal; 

public class Daynight : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  UnityEngine.Experimental.Rendering.Universal.Light2D  global_light;
    [SerializeField] Player player; // NEED TO CHANGE FOR MULTI
    [SerializeField] private float delay = 1f;
    private float startingTime;
    private Spwaner[] spwaners;
    void Start()
    {
        startingTime = Time.time;
        spwaners = GetComponentsInChildren<Spwaner>();
        Debug.Log( spwaners.Length);
    }

    // Update is called once per frame
    float time = 0;
    float timer = 0;
    void Update()
    {
        time = Time.time - startingTime;
        global_light.intensity = ((Mathf.Sin(time / 64) + 1 ) / 2) + 0.1f;
        if (global_light.intensity < 0.6f) { // NightSTATER - > SEASON
            player.my_light.enabled = true;
        } else {
            //Debug.Log("merd");
            if (Time.time > timer){
                timer = Time.time + delay;
               // Debug.Log("pppp");
                foreach (Spwaner sp in spwaners) {
                
                    sp.spwan();
                }
            }
            player.my_light.enabled = false;
        }

    }
}
