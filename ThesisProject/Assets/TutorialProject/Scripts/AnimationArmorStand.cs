using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationArmorStand : MonoBehaviour, IInteractable
{
    Animation animationComponent;
    // Start is called before the first frame update
    void Start()
    {
        animationComponent = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (animationComponent.isPlaying) {
            return;
        }

        animationComponent.Play();
    }
}
