using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasGameplay : MonoBehaviour
{
    public static CanvasGameplay instance;

    public Image bar;
    public TextMeshProUGUI hpText;

    public ChangeMode changeMode;

    public Button attackButton;
    public Image cdAttack;

    public TextMeshProUGUI demegeText;
    public TextMeshProUGUI stageText;

    public DeathUI deathUI;

    public GameObject pauseUI;

    private void Awake()
    {
        instance = this;
    }

    bool pause;
    public void Pause()
    {
        if (!pause)
        {
            pause = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pause = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        AudioManager.instance.ButtonClickSFX();
    }

    public void Mainmenu()
    {
        Time.timeScale = 1;
        UIManager.instance.PindahScene("Mainmenu");

        AudioManager.instance.ButtonClickSFX();
    }
}
