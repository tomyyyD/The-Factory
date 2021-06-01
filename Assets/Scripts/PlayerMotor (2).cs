using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float speed;
    public float groundDistance;
    public float jumpHeight;

    private Rigidbody rb;
    private Vector3 input = Vector3.zero;
    private bool isGrounded;

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
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if player is on the ground
        isGrounded = GroundCheck();

        //sets input to the button the player is pressing
        input.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //adds upward force
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);

            //determines that player is off of the ground
            isGrounded = false;
        }
    }

    //Physics stuff
    void FixedUpdate()
    {
        //moves the player at the given speed based on key input
        rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);
    }
}
