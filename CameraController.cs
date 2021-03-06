﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //offset = transform.position - player.transform.position;
        offset = new Vector3(7, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position + offset;
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
