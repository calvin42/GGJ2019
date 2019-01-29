using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class PlayerController : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    public float jumpIntensity;
    public float shoutForce;
    public int totalJumps;
    public int level;
    public GameObject[] enemyList;
    public GameObject chthulu;
    private Rigidbody2D rb2d; 
    public float maxHeight, minHeight, maxWidth, minWidth;
    public HealthBar healthBar;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        rb2d.freezeRotation = true;
    }
    void GameOver(){

    }
    private void Shout(){

        if (!GetComponent<AudioSource>().isPlaying) {
            GetComponent<AudioSource>().Play();
        }
        // Debug.Log(enemyList.Length);
        // Debug.Log("EORAPDF:KLX");
        foreach (GameObject enemy in enemyList)
        {
            float distance = Vector3.Distance(enemy.transform.position, transform.position);
            if ( distance <= 10f){
                enemy.GetComponent<EnemyController>().direction = -1;
                //if (enemy.transform.position.x > transform.position.x && enemy.transform.position.y < transform.position.y){ //in basso a destra
                    //enemy.transform.position += new Vector3(shoutForce*1/distance, -1*shoutForce*1/distance, 0);
                    //enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, -1 * shoutForce / distance);
                //} else if (enemy.transform.position.x < transform.position.x && enemy.transform.position.y < transform.position.y){ // in basso a sinistra
                //    //enemy.transform.position += new Vector3(-1*shoutForce*1/distance, -1*shoutForce*1/distance, 0);
                //    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, -1 * shoutForce * 1 / distance);
                //} else if (enemy.transform.position.x < transform.position.x && enemy.transform.position.y > transform.position.y){ // in alto a sinistra
                //    //enemy.transform.position += new Vector3(-1*shoutForce*1/distance, shoutForce*1/distance, 0);
                //    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, -1 * shoutForce * 1 / distance * Time.deltaTime);
                //} else if (enemy.transform.position.x > transform.position.x && enemy.transform.position.y > transform.position.y){ // in alto a destra
                //    //enemy.transform.position += new Vector3(shoutForce*1/distance, shoutForce*1/distance, 0);
                //    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, -1 * shoutForce * 1 / distance * Time.deltaTime);
                //}
                // enemy.transform.Rotate(new Vector3(0, 180, 0), Space.Self);
                // enemy.transform.position += new Vector3(shoutForce*1/distance, shoutForce*1/distance, 0);
                
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

        // if(moveVertical + transform.position.y > maxHeight || moveVertical + transform.position.y < minHeight){
        //     finalVertical = 0;
        // }
        
        float finalHorizontal = moveHorizontal;
        
        // if(moveHorizontal + transform.position.x > maxWidth || moveHorizontal + transform.position.x < minWidth){
        //     finalHorizontal = 0;
        // }
        Vector3 movement = new Vector3 (finalHorizontal*speed, finalVertical*speed, 0);

        if(movement!= new Vector3(0, 0, 0))
        {
            chthulu.GetComponent<Animator>().SetTrigger("I2W");
        }
        else
        {
            chthulu.GetComponent<Animator>().SetTrigger("W2I");
        }

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
        Debug.Log("pqo'irelkdf,td");
        if (other.gameObject.tag == "Enemy"){
            healthBar.decrementHealth(1);
            // GetComponent<GUIText>().text ="Vita: "+ GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;
        } else if (other.gameObject.tag == "Boss"){
            healthBar.decrementHealth(2);
        }
        if (healthBar.getCurrentHealth() <= 0 ){
            if (other.gameObject.tag == "Boss")
                UnityEngine.SceneManagement.SceneManager.LoadScene("Marte"); //TODO cambiare con video
            GameOver();
        }
    }

}