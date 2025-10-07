using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class portal : MonoBehaviour
{
    [SerializeField] Transform goToPosition;
    [SerializeField] Animator countdown;
    Transform capture;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        // col.gameObject.transform.position = goToPosition.position;
        // but with a coroutine, you can add a delay before the teleport

        // let's play it safe and only teleport the player, in this case XR Origin (XR Rig)
        if (col.gameObject.name == "XR Origin (XR Rig)")
        {
            Debug.Log("Player detected, teleporting in 3 seconds");
            capture = col.gameObject.transform;
            StartCoroutine("Teleport", 3.0f);
        }

    }

    // start with an IEnumerator
    // coroutines work with yield statements, instead of return statements
    // IEnumerator are functions that can be paused and resumed over multiple frames
    IEnumerator Teleport(float interval)
    {
        // play the countdown animation
        countdown.Play("countdown");
        yield return new WaitForSeconds(interval);
        // then do the teleport
        capture.position = goToPosition.position;
        capture.rotation = goToPosition.rotation;
    }
}
