using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public int stage;
    public int maxHPEnemy = 100;
    public int demegeEnemy = 20;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpStage();

        SetDemegeEnemy();
    }

    public void UpStage()
    {
        stage++;
        CanvasGameplay.instance.stageText.text = "Tingkat : " + stage;
    }

    bool useDeathUI;
    public void PlayerDeath()
    {
        if (!useDeathUI)
        {
            useDeathUI = true;
            CanvasGameplay.instance.deathUI.gameObject.SetActive(true);
            CanvasGameplay.instance.deathUI.Set(stage);
        }

    }

    public void UpgDemegePlayer()
    {

    }
    public void UpgDemegeEnemy()
    {

    }
    public void SetDemegeEnemy()
    {
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].Set(maxHPEnemy, demegeEnemy);
        }
    }
}
