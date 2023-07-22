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
        stage = 1;
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
}
