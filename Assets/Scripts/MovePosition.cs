using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
public class MovePosition : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform destination;

    void Start()
    {
        XRSimpleInteractable objInteractable = GetComponent<XRSimpleInteractable>();
        objInteractable.selectEntered.AddListener((SelectEnterEventArgs arg) =>
        {
            Debug.Log("Object selected, moving player to corresponding position");
            player.position = destination.position;
            player.rotation = destination.rotation;

        });
    }

    void Update()
    {
        
    }
}
