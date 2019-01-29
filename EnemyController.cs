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
    public int direction;

    public bool allontanandosi = false;
    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        stopMoving = false;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving){
            if(Vector3.Distance(transform.position, player.position) < MaxDist)
            {       
                if(Vector3.Distance(transform.position, player.position) >= MinDist){
                    transform.position = Vector2.MoveTowards(transform.position, direction * player.position, speed * Time.deltaTime);
                } 
            }
        }
        if (direction == -1 && ! allontanandosi) {
            StartCoroutine(PassaPaura());
            allontanandosi = true;
        }
    }

    IEnumerator PassaPaura()
    {
        Debug.Log("PassaPaura");
        yield return new WaitForSeconds(0.5f);
        direction = 1;
        allontanandosi = false;
    }
   
}
