using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainmenuUI : MonoBehaviour
{
    public GameObject settingUI;
    [SerializeField]
    TMP_Dropdown resolutionsDD;
    [SerializeField]
    Toggle fullscreenToggle;
    Resolution[] resolutions;
    private void Start()
    {
        //Screen
        resolutions = Screen.resolutions;
        resolutionsDD.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (i > 9)
            {
                string resuliton = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(resuliton);
            }


        }
        resolutionsDD.AddOptions(options);
        resolutionsDD.value = (int)GameSave.instance.resolutionValue;
        resolutionsDD.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetFullscreen(bool value)
    {
        Screen.fullScreen = value;

        AudioManager.instance.ButtonClickSFX();
    }
    public void SetResolution(int value)
    {
        Resolution resolution = resolutions[value + 10];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        print(resolution);
        GameSave.instance.SaveResolution(value);

        AudioManager.instance.ButtonClickSFX();
    }

    public void SetSettingUI(bool value)
    {
        if (!value)
        {
            settingUI.GetComponent<Animator>().SetBool("Start", false);
        }
        else
        {
            settingUI.GetComponent<Animator>().SetBool("Start", true);
        }

        AudioManager.instance.ButtonClickSFX();
    }

    public void SetAudio()
    {
        AudioManager.instance.SetAudio();
    }

    public void Gameplay()
    {
        UIManager.instance.PindahScene("Gameplay");
    }
}
