using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update

    int dialogueIndex = 0;
    int maxIndex;
    [SerializeField] List<SO_Dialogue> dialogueList;
    SO_Dialogue nextDialogue;

    void Start()
    {
        maxIndex = dialogueList.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        nextDialogue = dialogueList[dialogueIndex];
        Debug.Log("female character interact");
        DialogueManager.instance.QueueDialogue(nextDialogue);
        if (dialogueIndex < maxIndex)
        {
            dialogueIndex++;
        }
    }
}
