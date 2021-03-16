using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Interactable
{
    public GameObject platform;
    public Vector3 newPos;
    private Rigidbody rb;
    public GameObject keyHole;
    public bool opened;
    public GameObject guideText;

    public override void Interact()
    {
        if (keyScript.playerKeys > 0)
        {
            opened = true;
            Destroy(keyHole);
            rb.velocity = newPos;
            keyScript.playerKeys--;
            Destroy(gameObject);
            //guideText.SetActive(false);
        }
        else
        {
            guideText.SetActive(true);
            StartCoroutine(guideTextTimer());
            //Debug.Log("Player needs a key for this door");
        }
        //Debug.Log("getting velocity");

    }
    
    private void Start()
    {
        rb = platform.GetComponent<Rigidbody>();
    }

    IEnumerator guideTextTimer()
    {
        yield return new WaitForSeconds(3);
        guideText.SetActive(false);
    }
}
