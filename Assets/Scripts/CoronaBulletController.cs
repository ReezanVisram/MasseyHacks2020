﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -5 * Time.deltaTime, 0);

        if (transform.position.y < -20) {
            Destroy(gameObject);
        }
    }
}
