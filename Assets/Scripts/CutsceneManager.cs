using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class CutsceneManager : MonoBehaviour
{
    [Header("Player References")]
    [Tooltip("The XR Origin that will be controlled.")]
    public XROrigin xrOrigin;
    [Tooltip("All locomotion providers to be disabled during a cutscene.")]
    public MonoBehaviour[] locomotionProvidersToDisable;

    [Header("Rig Reference")]
    [Tooltip("The static rig located at the scene origin (0,0,0)")]
    public Transform cutsceneRig;

    private PlayableDirector currentDirector;

    // Call this method from a Timeline Signal to start a cutscene
    public void StartCutscene(PlayableDirector director)
    {
        if (xrOrigin == null || cutsceneRig == null || director == null)
        {
            Debug.LogError("Required references are missing on the CutsceneManager.");
            return;
        }

        // Keep track of the current director to know when the cutscene ends
        currentDirector = director;
        currentDirector.stopped += OnCutsceneStopped;

        // Disable player locomotion
        SetPlayerLocomotionEnabled(false);

        // Teleport the XR Origin to the static CutsceneRig
        xrOrigin.MoveCameraToWorldLocation(cutsceneRig.position);
        xrOrigin.MatchOriginUp(cutsceneRig.up);
        xrOrigin.RotateAroundCameraUsingOriginUp(cutsceneRig.rotation.eulerAngles.y);
    }

    private void OnCutsceneStopped(PlayableDirector director)
    {
        // Re-enable player locomotion
        SetPlayerLocomotionEnabled(true);
        currentDirector.stopped -= OnCutsceneStopped;
    }

    private void SetPlayerLocomotionEnabled(bool isEnabled)
    {
        foreach (var provider in locomotionProvidersToDisable)
        {
            provider.enabled = isEnabled;
        }
    }
}
