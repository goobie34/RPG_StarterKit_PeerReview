using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour, IInteractable
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("I AM A TRAINING DUMMY AND I WAS JUST INTERACTED WITH");
        GetComponent<Animator>().enabled = true;
    }
}
