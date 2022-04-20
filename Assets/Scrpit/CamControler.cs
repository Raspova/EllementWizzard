using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControler : MonoBehaviour
{
    public Transform player;
    private Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        pos.Set(player.position.x, player.position.y, -10);
        transform.position = pos;
    }
}
