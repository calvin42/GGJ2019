using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private int health;
    public float speed;             //Floating point variable to store the player's movement speed.
    public float jumpIntensity;
    public float shoutForce;
    public int totalJumps;
    public int level;
    public GameObject[] enemyList;
    private Rigidbody2D rb2d; 
    public float maxHeight, minHeight, maxWidth, minWidth;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        rb2d.freezeRotation = true;
        health = 6;
    }
    
    private void Shout(){
        
        Debug.Log(enemyList.Length);
        Debug.Log("EORAPDF:KLX");
        foreach (GameObject enemy in enemyList)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if ( distance <= 10f){
                enemy.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
                enemy.transform.position += new Vector3(shoutForce*1/distance, shoutForce*1/distance, 0);
                
            }
            // 
            // Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation); 
        }
        GameObject.Find("ScreamBar").GetComponent<ScreamBar>().isFilling = true;

    }

    private void Jump(float horizontal, float vertical){
        Vector3 jump;
        if(Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Space)){
            if (totalJumps > 0){
                totalJumps--;
                jump = new Vector3(horizontal, vertical * jumpIntensity, 0);
                transform.position += jump;
            }
        }
        
    }
    void Update()
    {
        // float translation = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        float finalVertical = moveVertical;

        if(moveVertical + transform.position.y > maxHeight || moveVertical + transform.position.y < minHeight){
            finalVertical = 0;
        }
        
        float finalHorizontal = moveHorizontal;
        
        if(moveHorizontal + transform.position.x > maxWidth || moveHorizontal + transform.position.x < minWidth){
            finalHorizontal = 0;
        }
        Vector3 movement = new Vector3 (finalHorizontal*speed, finalVertical*speed, 0);

        transform.position += movement;
        // Vector2 movement = new Vector2 (finalHorizontal, finalVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        // rb2d.AddForce (movement * speed);

        
        if(Input.GetKeyDown(KeyCode.Space)){
            if (level == 1){
                Shout();
            }
            if (level == 2){
                Jump(moveHorizontal, moveVertical);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy"){
            health--;
            // GetComponent<GUIText>().text ="Vita: "+ GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;
        } else if (other.gameObject.tag == "Boss"){
            health -= 2;
        }
        if (health <= 0){
            // GAME OVER
        }
    }

}