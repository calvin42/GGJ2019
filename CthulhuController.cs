using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CthulhuController : MonoBehaviour
{
    public float speed;
    public bool fermate;
    bool started;

    void Start()
    {
        fermate = false;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started){
            started = true;
            gameObject.GetComponent<SoundFXHandler>().triggerSound(0);
        }
        if (!fermate)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal * speed, 0, 0);
            transform.position += movement;
        }// } else{
        
        //if (moveHorizontal > 0){
        //    if (GameObject.Find("Madre") != null){
        //        GameObject.Find("Madre").GetComponent<FamilyController>().move = true;
        //        GameObject.Find("Padre").GetComponent<FamilyController>().move = true;
        //    }
        //} else {
        //    if (GameObject.Find("Padre") != null){
        //        GameObject.Find("Madre").GetComponent<FamilyController>().move = false;
        //        GameObject.Find("Padre").GetComponent<FamilyController>().move = false;
        //    }
        //}
        //transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        
    }

  
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy"){
            other.gameObject.transform.position = new Vector3 (other.gameObject.transform.position.x, other.gameObject.transform.position.y-1, 0);
            transform.Rotate(Vector3.right);
        }
        if (other.gameObject.tag == "btn" && (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipale");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Parents")
        {
            GameObject.Destroy(other.gameObject);
            fermate = false;
        }
        if (other.gameObject.tag == "Spawn"){
            fermate = true;
            // gameObject.GetComponent<SoundFXHandler>().triggerSound(0);
        }
            
    }
}
