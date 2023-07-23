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

    private void Awake()
    {
        instance = this;
    }
}
