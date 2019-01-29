using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    // Start is called before the first frame update
    int checkPoint = 0;
    public GameObject respawnEnemy;
    private Transform city;
    bool triggered;
    float waitAudio;

    void Start()
    {
        triggered = false;  
        // city = GameObject.Find("cityBackground").transform;
        waitAudio = 93f;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered){
            foreach(Transform child in GameObject.Find("Servi").transform){
                GameObject.Destroy(child.gameObject);
            }
            foreach(Transform child in GameObject.Find("Citizen").transform){
                GameObject.Destroy(child.gameObject);
            }
            // GameObject.Destroy(city.gameObject);
            // GameObject.Destroy(this);
            Transform respawn = GameObject.Find("Spawn").transform;
            // Instantiate(respawnEnemy, respawn.position, respawn.rotation);
            GameObject.Find("Cthulhu").gameObject.GetComponent<CthulhuController>().fermate = true;
            gameObject.GetComponent<SoundFXHandler>().triggerSound(0);
            triggered = false;

        }
        // if(triggered)
        //     waitAudio -= Time.deltaTime;
        // if (waitAudio < 0){
        //     
            
        // }
                
    }
  /// <summary>
  /// Sent when a collider on another object stops touching this
  /// object's collider (2D physics only).
  /// </summary>
  /// <param name="other">The Collision2D data associated with this collision.</param>
  void OnTriggerEnter2D(Collider2D other)
  {
    //   Debug.Log("irejlkf,.");
        triggered = true;
  }
}
