using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float speed;
    public bool stopMoving;
    public float MaxDist, MinDist;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stopMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving){
            if(Vector3.Distance(transform.position, player.position) < MaxDist)
            {       
                if(Vector3.Distance(transform.position, player.position) >= MinDist){
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                } 
            }
        }

       
    }
   
}
