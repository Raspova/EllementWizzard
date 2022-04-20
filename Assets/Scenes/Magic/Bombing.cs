using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : Magic
{
    // Start is called before the first frame update
    [Range(0,7.5f)][SerializeField] float Yoffset = 1f;

    protected void baseStart()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        pos.z = 0;
        Sprite x = GetComponent<SpriteRenderer>().sprite;
        pos.y += Yoffset;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    override public void onContact(Enemy enemy)
    {
        base.onContact(enemy);
        Vector3 buffDirect = transform.position - enemy.gameObject.transform.position;
        Vector2 direc = new Vector2(buffDirect.x, buffDirect.y);
        enemy.takeForce(direc, 30000);
    }

    // Update is called once per frame
    
}
