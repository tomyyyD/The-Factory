using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{
    private Vector3 newVel;
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        newVel = rb.velocity;
        newVel.z = -newVel.z*2;
        if (collision.gameObject.tag == "platformTurn"){
            //Debug.Log("collided with plat turn");
            
            rb.velocity = new Vector3(0, 0, 5);
        }
        if (collision.gameObject.CompareTag("platformStop")){
            rb.velocity = Vector3.zero;
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
}
