using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody characterRB;
    [SerializeField] float walkingSpeed;
    [SerializeField] float sprintSpeed;
    Animator playerAnimator;

    Vector3 movementInput;
    Vector3 movementDirectionVector;
    Vector3 combinedMovementVector;

    bool isSprinting;

    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        ApplyMovement();
    }

    private void OnMovement(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();
        movementInput = new Vector3(input.x, 0, input.y);
        playerAnimator.SetBool("isMoving", true);
    }

    private void OnMovementStop(InputValue inputValue)
    {
        movementInput = Vector3.zero;
        playerAnimator.SetBool("isMoving", false);
    }

    private void OnSprint(InputValue inputValue)
    {
        isSprinting = true;
        Debug.Log("SPRINT");
    }
    private void OnSprintStop(InputValue inputValue)
    {
        isSprinting = false;
        Debug.Log("SPRINT STOP");
    }

    private void ApplyMovement()
    {
        if (movementInput != null)
        {
            movementDirectionVector = movementInput.x * transform.right + movementInput.z * transform.forward;
            movementDirectionVector.y = 0;


            if (isSprinting)
            {
                combinedMovementVector = movementDirectionVector * Time.fixedDeltaTime * sprintSpeed;
            }
            else
            {
                combinedMovementVector = movementDirectionVector * Time.fixedDeltaTime * walkingSpeed;
            }

            Vector3 tempVelocity = characterRB.velocity;
            tempVelocity.x = combinedMovementVector.x;
            tempVelocity.z = combinedMovementVector.z;
            characterRB.velocity = tempVelocity;
        }
    }
}
