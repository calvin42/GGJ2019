using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    // Transform background;
    // public float xVel, yVel;
    public GameObject cameraSpot;
    public bool doZoomOut;
    private float speed;

    void Start()
    {
        // background  = GameObject.Find("Istituto Volta").Transform;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // while(transform.position.y > -1.54 && transform.position.x < 2.14){
            // transform.position = new Vector3((transform.position.x+xVel + Time.deltaTime, (transform.position.y - yVel * Time.deltaTime, -10);        
        transform.position = Vector2.MoveTowards(transform.position, cameraSpot.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        // if (doZoomOut){
        //     GetComponent<.orthographicSize = 2.0f;
        // }
    }
    
    
}
