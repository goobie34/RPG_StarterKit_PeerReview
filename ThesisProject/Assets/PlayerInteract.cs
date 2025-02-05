using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera playerCamera;
    [SerializeField] float interactionRange = 1.0f;
    [SerializeField] bool debugMode = false;
    IInteractable interactableObject;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
            Debug.Log("CAMERA IS " + playerCamera.name);
        }

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hitObject, interactionRange))
        {
            interactableObject = hitObject.collider.GetComponent<IInteractable>();
        }
        else
        {
            interactableObject = null;
        }

        if (debugMode)
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionRange);
        }
    }

    private void OnInteract(InputValue inputValue)
    {
        if (interactableObject != null)
        {
            interactableObject.Interact();
            Debug.Log("Interacting with with object!");
        } else
        {
            Debug.Log("Player tried to interact with an object");

        }
    }
}

public  interface IInteractable
{
    void Interact();
}
