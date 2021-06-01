using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotorTwo : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 input = Vector3.zero;
    private bool isGrounded;
    private float normalForce;

    public float accel;
    public float speed;
    public float groundDistance;
    public float jumpHeight;
    public float friction;

    bool GroundCheck()
    {
        Vector3 rightOffset = transform.up * (transform.localScale.y / 2f) * -1f;
        Vector3 rightPos = transform.position + rightOffset; //This is the position

        Vector3 leftOffset = transform.up * (transform.localScale.y / 2f);
        Vector3 leftPos = transform.position + leftOffset; //This is the position

        bool grounded = false;
        //raycast downward to check for ground from left edge and right edge
        if (Physics.Raycast(rightPos, Vector3.down, groundDistance) || Physics.Raycast(leftPos, Vector3.down, groundDistance)){
            grounded = true;
        }
        
        return grounded;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalForce = 9.8f * rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = GroundCheck();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //adds upward force
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);

            //determines that player is off of the ground
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        

        if(Mathf.Abs(rb.velocity.x) < speed){
            input.x = Input.GetAxis("Horizontal") * accel;
            rb.AddForce(input, ForceMode.VelocityChange);
        }else{
            input.x = Input.GetAxis("Horizontal") * friction;
            rb.AddForce(input, ForceMode.VelocityChange);
        }

    }
}
