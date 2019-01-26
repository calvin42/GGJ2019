using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            Debug.Log("COSEJIRKLR");
            Vector3 modify = new Vector3(other.transform.position.x, 0, 0);
            other.transform.position = modify;
        }
        

    }
}
