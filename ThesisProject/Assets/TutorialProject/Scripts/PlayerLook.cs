using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int sensitivity;
    [SerializeField] Transform playerCamera;
    float xRotation, yRotation;
    float mouseX, mouseY;

    [SerializeField] float MaxRotationUp;
    [SerializeField] float MaxRotationDown;

    [SerializeField] bool thirdPerson = false;
    [SerializeField] float offset = 2;

    public int Sensitivity { get { return sensitivity; } set { sensitivity = value;  } }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Vector3 v3 = playerCamera.position;
        //v3.z = -offset;
        //playerCamera.position = v3;

    }

    void Update()
    {
        if (thirdPerson)
        {
            ThirdPersonLookUpdate();
        } else
        {
            FirstPersonLookUpdate();
            //Debug.Log("first person");
        }
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();
        mouseX = input.x;
        mouseY = input.y;
    }

    private void FirstPersonLookUpdate()
    {
        mouseX = mouseX * Time.fixedDeltaTime * sensitivity;
        mouseY = mouseY * Time.fixedDeltaTime * sensitivity;

        xRotation = Mathf.Clamp(xRotation - mouseY, MaxRotationUp, MaxRotationDown);
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);

    }
    private void ThirdPersonLookUpdate()
    {
        mouseX = mouseX * Time.fixedDeltaTime * sensitivity;
        mouseY = mouseY * Time.fixedDeltaTime * sensitivity;

        xRotation = Mathf.Clamp(xRotation - mouseY, MaxRotationUp, MaxRotationDown);
        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //Vector3 v3 = playerCamera.position;
        //v3.z = -offset;
        //playerCamera.position = v3;
        
    }

    private void TogglePerspective()
    {
        
    }
}
