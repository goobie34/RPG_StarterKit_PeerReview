using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject playerObject;
    string tagString = "Player";
    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    [SerializeField] TextMeshProUGUI sensitivityValueTxt;
    int currentResIndex;


    Resolution[] resolutions;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag(tagString);
        PopulateResDropDown();

        mouseSensitivitySlider.value = playerObject.GetComponent<PlayerLook>().Sensitivity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSensitivity()
    {
        float newSensitivity = mouseSensitivitySlider.value;
        sensitivityValueTxt.text = ((int)newSensitivity).ToString();
        playerObject.GetComponent<PlayerLook>().Sensitivity = (int)newSensitivity;
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void PopulateResDropDown()
    {
        int currentResIndex = 0;
        bool foundCurrentRes = false;
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;

        int i = 0;
        foreach (Resolution res in resolutions)
        {
            options.Add(res.width.ToString() + "x" + res.height.ToString());

            if (res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height)
            {
                currentResIndex = i;
                foundCurrentRes = true;
            }

            Debug.Log(res.width.ToString() + "x" + res.height.ToString());
            i++;
        }

        if (foundCurrentRes)
        {
            Debug.Log("Current Resolution is: " + options[currentResIndex].ToString());

        } else
        {
            Debug.Log("Current resolution was not found.");
        }

        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.SetValueWithoutNotify(currentResIndex);
    }
    
    public void ChangeResolution(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, Screen.fullScreen);
    }
}
