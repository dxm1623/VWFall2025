using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private PlayableAsset timelineAsset;
    [SerializeField] private string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            playableDirector.playableAsset = timelineAsset;
            playableDirector.Play();
            Debug.Log("Player entered the trigger, playing animation.");
            GetComponent<Collider>().enabled = false;
            
        }
    }
}
