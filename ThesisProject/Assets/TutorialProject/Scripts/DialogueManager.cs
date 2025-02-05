using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    bool inDialogue;
    bool isTypingOutLetters;
    string completedString;

    [SerializeField] Queue<SO_Dialogue.Info> dialogueQueue;
    [SerializeField] float textDelay;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;

    private IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isTypingOutLetters = true;

        foreach (char character in info.dialogue.ToCharArray())
        {
            dialogueText.text += character;
            Debug.Log(dialogueText);
            yield return new WaitForSeconds(textDelay);
        }

        isTypingOutLetters = false;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        dialogueQueue = new Queue<SO_Dialogue.Info>();


    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
    }

    public void CompleteText()
    {
        dialogueText.text = completedString;
    }

    public void OnInteract(InputValue input)
    {
        if (inDialogue)
        {
            DequeueDialogue();
        }

    }

    public void QueueDialogue(SO_Dialogue dialogue) //start dialogue
    {
        if (inDialogue)
        {
            return;
        }

        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        dialogueBox.SetActive(true);
        dialogueQueue.Clear();

        foreach (SO_Dialogue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();

    }
    public void DequeueDialogue() //next line
    {
        if (isTypingOutLetters)
        {
            CompleteText();
            StopAllCoroutines();
            isTypingOutLetters = false;
            return;
        }

        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        SO_Dialogue.Info info = dialogueQueue.Dequeue();
        completedString = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));

    }
}
