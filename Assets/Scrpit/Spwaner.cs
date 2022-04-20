using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Unit;
    [SerializeField] private int BashSize = 50;
    private GameObject[] unitStack;
    
    //private float timer = 0f;
    [SerializeField] private int nbofUnitToSpawn = 1;
    [SerializeField] private Transform player_transform;
    
    void Start()
    {
        unitStack = new GameObject[BashSize];

        for (int i = 0; i < BashSize; i++) {
            unitStack[i] = Instantiate(Unit, transform.position, Quaternion.Euler(0,0,0));
            unitStack[i].SetActive(false);
            unitStack[i].GetComponent<Enemy>().player_transform = player_transform;
        }
    }

    public void spwan()
    { 
        int buffenabled = 0;
        
        for (int stackI = 0; buffenabled < nbofUnitToSpawn; stackI++) {
            if (stackI == BashSize) {
                stackI = 0;
                return;
            }
            if (!unitStack[stackI].activeSelf) {
                buffenabled++;
                unitStack[stackI].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    
   
    void Update()
    {
        /*if (Time.time > timer){
            timer = Time.time + delay;
            for (;buffenabled < nbofUnitToSpawn; stackI++) {
                if (stackI == BashSize) {
                    stackI = 0;
                    return;
                }
                if (!unitStack[stackI].activeSelf) {
                    buffenabled++;
                    unitStack[stackI].SetActive(true);
                }
            }
            buffenabled = 0;
        } */       
    }
}
