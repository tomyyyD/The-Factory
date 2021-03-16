using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision has happened");

        if (hasCollided == false)
        {
            if (cam1.Priority > cam2.Priority)
            {
                cam1.Priority--;
                cam2.Priority++;
                Debug.Log("switching to cam 2");
            }
            else if (cam2.Priority > cam1.Priority)
            {
                cam1.Priority++;
                cam2.Priority--;
                Debug.Log("switching to cam 1");
            }
            hasCollided = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (hasCollided)
        {
            hasCollided = false;
        }
    }
}
