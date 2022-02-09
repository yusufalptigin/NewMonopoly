using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour
{
    // Start is called before the first frame update    

    public GameObject newCube;
    private Rigidbody _cubeRigid;
    private bool isSpawned = false;
    private int height;

    void Start()
    {
        _cubeRigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 5f)
        {
            _cubeRigid.AddForce(0f, 5f, 0f);
            if (!isSpawned)
            {
                Instantiate(newCube, transform.position + new Vector3(0, height, 0), Quaternion.identity);
                isSpawned = true;
            }
            
        }
        else
        {
            _cubeRigid.AddForce(0f, -5f, 0f);
        }
    }
}