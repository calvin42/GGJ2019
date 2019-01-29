using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenController : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        // Debug.Log(dist);
        if(Vector3.Distance(transform.position, player.position) < 60)
            transform.position += new Vector3 (dist*0.0001f, 0, 0);
            // transform.position = Vector2.MoveTowards(transform.position, player.position, 3f * Time.deltaTime);

    }
    
}
