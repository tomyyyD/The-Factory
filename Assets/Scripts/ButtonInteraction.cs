using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : Interactable
{
    public GameObject platform;
    public Vector3 newPos;
    private Rigidbody rb;

    public override void Interact()
    {
        //Debug.Log("getting velocity");
        rb.velocity = newPos;
    }

    private void Start()
    {
        rb = platform.GetComponent<Rigidbody>();
    }
}
