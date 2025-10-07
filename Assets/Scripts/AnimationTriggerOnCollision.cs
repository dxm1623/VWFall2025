using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.Timeline;

// trigger a cutscene when a certain object collides with a target object

public class AnimationTriggerOnCollision : MonoBehaviour
{
    public PlayableDirector playableDirector; // Reference to the PlayableDirector component
    public TimelineAsset timelineAsset; // Reference to the Timeline asset
    public Collider targetObject; // The target object to check collision with

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        // Check if the colliding object is the targetObject
        if (other == targetObject)
        {
            // first check if any of the objects involved is currently grabbed by the user via XR Grab Interactable
            // if so, immediately release it as if letting go of the object
            var grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null && grabInteractable.isSelected)
            {
                grabInteractable.interactionManager.SelectExit(grabInteractable.firstInteractorSelecting, grabInteractable);
                Debug.Log("Released grabbed object: " + other.gameObject.name);
            }

            // Play the timeline when the trigger is activated
            playableDirector.Play(timelineAsset);
        }
    }

}