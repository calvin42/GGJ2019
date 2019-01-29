using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroLevelOne : MonoBehaviour
{

    public float speed;
    bool collide = false;
    public GameObject bullySpot;
    Animator anim;
    bool stopMoving;
    void Start()
    {
        // mainCamera = Camera.main;
        // mainCamera.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        // if(Vector3.Distance(transform.position, bullySpot.transform.position) ){
        if(!stopMoving)
            transform.position = Vector2.MoveTowards(transform.position, bullySpot.transform.position, speed * Time.deltaTime);
        if (collide)
            GetComponent<Animator>().SetTrigger("W2I");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("IRQEJAKF<r");
        collide = true;
        stopMoving = true;
        // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // foreach (GameObject enemy in enemies){
            // enemy.GetComponent<EnemyController>().stopMoving = true;
        // }
        
    }
}
