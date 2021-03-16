using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    private BoxCollider bc;
    public static int playerKeys;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerKeys++;
            Destroy(gameObject);
        }
    }
}
