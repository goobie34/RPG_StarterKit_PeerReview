using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    bool isPaused = false;
    GameObject playerObject;
    [SerializeField] GameObject pauseMenuObject;
    [SerializeField] GameObject pauseStartMenuObject;
    [SerializeField] GameObject menuList;
    string tagString = "Player";

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(tagString);
        ResetPauseUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPauseGame(InputValue inputvalue)
    {
        if (isPaused)
        {
            UnPauseGame();
        } else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        playerObject.GetComponent<PlayerInput>().enabled = false;
        pauseMenuObject.SetActive(true);
        Debug.Log("pausing game...");
    }

    public void UnPauseGame()
    {
        ResetPauseUI();
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        playerObject.GetComponent<PlayerInput>().enabled = true;
        pauseMenuObject.SetActive(false);
        Debug.Log("unpausing game...");
    }

    private void ResetPauseUI()
    {
        foreach (Transform child in menuList.transform)
        {
            child.gameObject.SetActive(false);
        }

        pauseStartMenuObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
