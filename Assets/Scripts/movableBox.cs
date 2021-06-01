using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movableBox : MonoBehaviour
{
    public GameObject initialParent;
    public GameObject player;
    public GameObject box;

    private bool inCol;
    private Rigidbody rb;
    private Rigidbody playerRb;
    private Rigidbody boxRb;
    private Vector3 offset;
    private FixedJoint joint;
    //private FixedJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        inCol = false;
        joint = GetComponent<FixedJoint>();
        rb = GetComponent<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();
        boxRb = box.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCol && Input.GetKeyDown(KeyCode.LeftShift)){
            //gameObject.transform.parent = player.transform;
            // if (rb.position.x > playerRb.position.x){
            //     offset.x = 1;
            // }else if (rb.position.x < playerRb.position.x){
            //     offset.x = -1;
            // }
            // rb.position = playerRb.position + offset;
            //rb.velocity = playerRb.velocity; 
            joint.connectedBody = playerRb;
            //Debug.Log(rb.velocity);
        }
        //Debug.Log(playerRb.velocity);
        if(inCol && Input.GetKeyUp(KeyCode.LeftShift)){
            joint.connectedBody = boxRb;
            // Debug.Log("pulling stoped");
            //gameObject.transform.parent = initialParent.transform;
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player"){
            inCol = true;
        }
    }
    void OnTriggerExit(Collider col){
        if (col.gameObject.tag == "Player"){
            inCol = false;
        }
    }
}
