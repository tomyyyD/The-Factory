using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class animationPlayer : MonoBehaviour
{
    public PlayableDirector timeline;

    private void Start()
    {
        timeline = gameObject.GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        timeline.Play();
        Destroy(gameObject);
    }

}
