using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwingAnimation : MonoBehaviour
{

    [SerializeField] PlayerMovement playerMovement;
    Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAttack(InputValue input)
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            Debug.Log("RETURNING EARLY; PLAYER WAS RUNNING");

            return;
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        {
            Debug.Log("RETURNING EARLY; PLAYER WAS SWINGING");
            return;
        }

        playerAnimator.SetTrigger("swing");
    }
}
