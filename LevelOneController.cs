using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneController : MonoBehaviour
{
    public GameObject respawnEnemy;
    private GameObject[] respawns;
    void Start()
    {

        respawns = GameObject.FindGameObjectsWithTag("Spawn");

        foreach (GameObject respawn in respawns)
        {
            Instantiate(respawnEnemy, respawn.transform.position, respawn.transform.rotation);
            
        }
        GameObject.Find("Player").GetComponent<PlayerController>().enemyList = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
