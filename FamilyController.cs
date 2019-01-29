using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyController : MonoBehaviour
{
    public Transform player;
    private float timeToBeStill;
    private float timeNotMoving;
    private Transform savedPosition;
    public bool move;
    private bool isWalking;
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        move = false;
        timeToBeStill = 80;
    }

    // Update is called once per frame
    void Update(){
        if(player.transform.position.x < 100)
        {
            return;            
        }
        float step = 3 * Time.deltaTime;
        if (timeToBeStill <= 0)
            // GameObject.Destroy(this);
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        if (move){
            float dist = Vector3.Distance(transform.position, player.position);

            transform.position += new Vector3 (dist*0.001f, 0, 0);            
            timeToBeStill = 5;
            savedPosition = player.transform;
        }
        // Debug.Log(timeToBeStill);
        timeToBeStill -= Time.deltaTime;
    }   
    
    
}
