using UnityEngine;
using UnityEngine.InputSystem;

public class ShowMenu : MonoBehaviour
{
    [SerializeField] InputActionProperty inputAction;
    [SerializeField] GameObject menu;
    [SerializeField] bool menuToggle = false;

    void Start()
    {
        menu.SetActive(menuToggle);
    }

    void Update()
    {
        if (inputAction.action.WasPressedThisFrame())
        {
            Debug.Log("Secondary button pressed");
            if (menuToggle)
            {
                Debug.Log("Menu closed");
                menuToggle = false;
            }
            else
            {
                Debug.Log("Menu opened");
                menuToggle = true;
            }
            menu.SetActive(menuToggle);
        }
    }
}
