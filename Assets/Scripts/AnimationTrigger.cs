using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// triggers a selected animation when the player touches the trigger

using UnityEngine;
using UnityEngine.Playables;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector; // Reference to the PlayableDirector component
    [SerializeField] private PlayableAsset timelineAsset; // Reference to the timeline asset to play
    // public, tag of whatever object(s) that have to touch the trigger to play the animation
    [SerializeField] private string targetTag = "Player"; // Tag of the player object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            playableDirector.playableAsset = timelineAsset; // Set the timeline asset
            playableDirector.Play(); // Play the timeline sequence
            Debug.Log("Player entered the trigger, playing animation.");
            // disable the collider to prevent retriggering
            GetComponent<Collider>().enabled = false;
        }
    }
}
