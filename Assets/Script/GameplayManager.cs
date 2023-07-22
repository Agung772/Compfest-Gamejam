using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    public int stage;
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
        CanvasGameplay.instance.stageText.text = "Stage : " + stage;
    }

    public void PlayerDeath()
    {

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
            enemys[i].demege = demegeEnemy;
        }
    }
}
