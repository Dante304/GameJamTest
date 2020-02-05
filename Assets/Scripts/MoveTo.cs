﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public bool turnOfMove { get; set; }


    private void Start()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Player1").transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !turnOfMove)
        {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            gameObject.transform.position = pz;
        }
    }
}
