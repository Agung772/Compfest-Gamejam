using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainmenuUI : MonoBehaviour
{
    public static MainmenuUI instance;

    public bool uiActive;

    public GameObject settingUI;
    [SerializeField]
    TMP_Dropdown resolutionsDD;
    [SerializeField]
    Toggle fullscreenToggle;
    Resolution[] resolutions;

    public TextMeshProUGUI highStage;
    private void Awake()
    {
        instance = this;
    }
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

        highStage.text = "Tingkat tertinggi : " + GameSave.instance.highStage;
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
            uiActive = false;
            settingUI.GetComponent<Animator>().SetBool("Start", false);
        }
        else
        {
            uiActive = true;
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

    public GameObject panduanUI;
    bool panduan;
    bool cdPanduan;
    public void Panduan()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            if (!panduan && !cdPanduan)
            {
                uiActive = true;

                panduan = true;
                cdPanduan = true;
                panduanUI.SetActive(true);
                panduanUI.GetComponent<Animator>().SetTrigger("Start");
                yield return new WaitForSeconds(1.1f);
                cdPanduan = false;

            }
            else if (panduan && !cdPanduan)
            {
                uiActive = false;

                panduan = false;
                cdPanduan = true;

                AudioManager.instance.ButtonClickSFX();
                panduanUI.GetComponent<Animator>().SetTrigger("Exit");
                yield return new WaitForSeconds(1);
                panduanUI.SetActive(false);

                yield return new WaitForSeconds(0.1f);
                cdPanduan = false;
            }

        }
    }

    public void Quit()
    {
        UIManager.instance.Quit();
    }
}
