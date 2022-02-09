using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetect : MonoBehaviour
{
    // Start is called before the first frame update

    private Collider _cubeCollider;


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.transform.parent.name + ", "  + collision.gameObject.name);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("");
        _cubeCollider.isTrigger = false;
    }
    */
    void Start()
    {
        /*
        _cubeCollider = GetComponent<Collider>();
        _cubeCollider.isTrigger = true;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
