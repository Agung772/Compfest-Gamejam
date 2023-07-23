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
    public int demegeLaser = 5;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpStage();

        SetDemegeEnemy();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasGameplay.instance.Pause();
        }
    }
    public void UpStage()
    {
        stage++;
        CanvasGameplay.instance.stageText.text = "Tingkat : " + stage;

        maxHPEnemy += 50;
        demegeEnemy += 10;
        demegeLaser += 5;
        SetDemegeEnemy();
    }

    bool useDeathUI;
    public void PlayerDeath()
    {
        if (!useDeathUI)
        {
            useDeathUI = true;
            CanvasGameplay.instance.deathUI.gameObject.SetActive(true);
            CanvasGameplay.instance.deathUI.Set(stage);

            Enemy[] enemys = FindObjectsOfType<Enemy>();
            for (int i = 0; i < enemys.Length; i++)
            {
                enemys[i].active = false;
            }

            DemegeLaser[] lasers = FindObjectsOfType<DemegeLaser>();
            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].transform.parent.GetChild(0).GetComponent<ParticleSystem>().Stop();
                Destroy(lasers[i].gameObject);
            }
        }

    }
    public void UpgMaxPlayer()
    {
        if (Player.instance.hp > 50)
        {
            Player.instance.hp -= 50;
            UIManager.instance.SpawnNotif("Berhasil tingkatkan kapasitas HP dan mengurangi HP");
            Player.instance.maxHp += 50;
            Player.instance.UpdateUI();
        }
        else
        {
            UIManager.instance.SpawnNotif("HP kamu tidak cukup untuk tingkatkan kapasitas HP");
        }

        AudioManager.instance.ButtonClickSFX();

    }
    public void UpgDemegePlayer()
    {
        if (Player.instance.hp > 50)
        {
            Player.instance.hp -= 50;
            UIManager.instance.SpawnNotif("Berhasil tingkatkan demege dan mengurangi HP");
            AttackMiniPlayer.instance.demege += 10;
            CanvasGameplay.instance.demegeText.text = AttackMiniPlayer.instance.demege.ToString();
            Player.instance.UpdateUI();
        }
        else
        {
            UIManager.instance.SpawnNotif("HP kamu tidak cukup untuk tingkatkan kapasitas HP");
        }

        AudioManager.instance.ButtonClickSFX();

    }
    public void SetDemegeEnemy()
    {
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].Set(maxHPEnemy, demegeEnemy);
        }

        DemegeLaser[] lasers = FindObjectsOfType<DemegeLaser>();
        for (int i = 0; i < lasers.Length; i++)
        {
            lasers[i].demege = demegeLaser;
        }
    }
}
