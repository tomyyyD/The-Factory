using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMotor : MonoBehaviour
{
    public float speed = 5f;
    public float height;
    private Vector3 moveVector = Vector3.zero;
    public Vector3 buttonCheck = Vector3.forward;

    //private CharacterController controller;
    private Animator animator;
    private Rigidbody rb;
    private CapsuleCollider cc;

    //private float verticalVelocity;
    //private float gravity = 14.0f;
    public float jumpForce = 10f;
    public float smoothing = 0.1f;
    public float crouchFactor = 3f;

    private bool ground;
    private bool crouching;
    private bool isPushing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cc = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        //Debug.Log(ground);
        if (ground)
        {
            animator.SetBool("isJumping", false);
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && ground)
        {
            //Debug.Log("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            ground = false;
        }

        ground = Physics.Raycast(transform.position, Vector3.down, height);
        //Debug.Log(ground);
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("pressing 'f' key");
            CheckInteraction();
        }

    }
    private void FixedUpdate()
    {
        if (animator.GetBool("isDead"))
        {
            return;
        }
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        float yVel = rb.velocity.y;
        if (movement.x != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), smoothing);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            //Debug.Log(cc.height);
            animator.SetBool("isCrouching", true);
            cc.height = 1.5f;
            cc.center = new Vector3(0f, -0.5f, 0.1f);
            if (Input.GetKey(KeyCode.D))
            {
                moveVector.x = speed/3;
                
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveVector.x = -speed/3;
                //animator.SetBool("isCrouching", true);
            }
            else
            {
                //animator.SetBool("isCrouching", false);
                moveVector.x = 0;
            }
        }
        else
        {
            cc.height = 2.96f;
            cc.center = new Vector3(0f, -0.21f, 0.1f);
            animator.SetBool("isCrouching", false);
            if (Input.GetKey(KeyCode.D))
            {
                moveVector.x = speed;
                animator.SetBool("isRunning", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveVector.x = -speed;
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
                moveVector.x = 0;
            }

        }

        //moveVector = moveVector.normalized;
        moveVector.y = yVel;
        rb.velocity = moveVector;

    }

    private void CheckInteraction()
    {
        //Debug.Log("running CheckInteraction");
        //RaycastHit[] hits = Physics.RaycastAll(transform.position, Vector3.forward, 100f);
        RaycastHit hit;
        Ray ray = new Ray(transform.position, buttonCheck);

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider);
            //Debug.Log("raycast returned something");
            if (hit.transform.GetComponent<Interactable>())
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
