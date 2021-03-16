using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScenes : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            EndScene.NextScene();
        }
    }
}
