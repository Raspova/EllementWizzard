using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Bolt;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject FallingLight;
    private GameObject activateObj;
    private Magic magic;
    [SerializeField] Player p;
    private Magic bulletInstance;
    
    private void Start() 
    {
        changeMagic(Bolt);
    }

    void changeMagic(GameObject obj)
    {
        activateObj = obj;
        magic = activateObj.GetComponent<Magic>();
    }
    // BULLET STAT
   
    // Update is called once per frame
    private Vector3 shootDirection;
    private Vector2 shootNorm;
    private Vector3 mpos;
    [SerializeField] Transform playerPos;
    private float cooldownBuffer = 0f;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
            changeMagic(Bolt);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            changeMagic(Arrow);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            changeMagic(FallingLight);   
           
       
        if (Input.GetMouseButton(0)
        && Time.time > cooldownBuffer) {
            cooldownBuffer = Time.time + magic.bullet_cooldown;
            //Debug.Log(playerPos.position);
            mpos = Input.mousePosition;
            mpos.z = 0;
            mpos = Camera.main.ScreenToWorldPoint(mpos);
            shootDirection = mpos - playerPos.position;
            shootNorm.Set(shootDirection.x , shootDirection.y );
            shootNorm.Normalize();
            
            bulletInstance = Instantiate(activateObj, playerPos.position + new Vector3(shootNorm.x, shootNorm.y, 0),
            Quaternion.Euler(0,0,Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg )).GetComponent<Magic>();// as;
            bulletInstance.velos = shootNorm;
            bulletInstance.playerPos = playerPos;
            p.setHozVert(shootNorm.x, shootNorm.y);
        }
        //transform.LookAt(Input.mousePosition);
        //transform.
    }
}
