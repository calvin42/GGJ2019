﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    public int initHealth;
    private int currentHealth;
    //DEBUG
    public GameObject heartSprite;

    //NO DEBUG
    public GameObject halfHeartSpriteLeft;
    public GameObject halfHeartSpriteRight;

    public GameObject healthBarContainer;
    void Start()
    {
        currentHealth = initHealth * 2;
        bool spawnLeft = true;
        GameObject spriteToSpawn = null;
        for(int i = 0; i < initHealth * 2; i++){
            if(spawnLeft){
                spriteToSpawn = halfHeartSpriteLeft;
            }
            else{
                spriteToSpawn = halfHeartSpriteRight;
            }
            spawnLeft = !spawnLeft;
            GameObject go = GameObject.Instantiate(heartSprite);
            go.transform.parent = healthBarContainer.transform;
            go.transform.position = new Vector2(go.transform.localScale.x * i,healthBarContainer.transform.position.y);
            go.name = (i+1).ToString();
            //Debug.Log(go.name+healthBarContainer.transform.chil)
        }

        //Invoke("incrementHealth",3);
        //Invoke("incrementHealth",3);

    }

    // Update is called once per frame
    void decrementHealth(int amount){
        //int amount = 3;
        if(currentHealth - amount <= 0)
            Debug.Log("Son morto");
        else{
        //return 1==1 ? 0:1;

            for(int i = currentHealth; i > currentHealth - amount;i--){
                GameObject.Destroy(healthBarContainer.transform.Find(i.ToString()).gameObject);
            }
            currentHealth = currentHealth-amount;
        }
    }
    void incrementHealth(int amount){

        
        if(currentHealth <= 0){
            Debug.Log("Morto");
            return;
        }

        bool leftSide = currentHealth % 2 == 0 ? false:true;

        for(int i = currentHealth; i < currentHealth+amount; i++){
            
            GameObject spriteToInstantiate = null;
            if(leftSide){
                //crea spriteSinistra
                spriteToInstantiate = halfHeartSpriteLeft;
            }
            else{
                //crea spriteDestra
                spriteToInstantiate = halfHeartSpriteRight;
            }
            leftSide = !leftSide;
            GameObject go = GameObject.Instantiate(spriteToInstantiate);
            go.transform.parent = healthBarContainer.transform;
            go.transform.position = new Vector2(go.transform.localScale.x * i,healthBarContainer.transform.position.y);
            go.name = (i+1).ToString();

        }

        currentHealth = currentHealth + amount;

    }
}
