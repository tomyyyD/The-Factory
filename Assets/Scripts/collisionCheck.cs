using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class collisionCheck : MonoBehaviour
{

    private Animator animator;
    public PlayableDirector timeline;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "movable" && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("isPushing", true);
        }
        else if (collision.gameObject.tag == "death")
        {
            animator.SetBool("isDead", true);
            timeline.Play();
            StartCoroutine(Wait());
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "movable")
        {
            animator.SetBool("isPushing", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Finish")
        //{
        //    EndScene.NextSceneTwo();
        //}
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        EndScene.ResetScene();
    }
}
