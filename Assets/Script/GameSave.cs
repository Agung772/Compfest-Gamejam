using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave instance;

    public float resolutionValue;
    public float highScore;

    //Anti typo
    string _DefaultData = "DefaultData";
    [HideInInspector]
    public string
        _Resolution = "Resolution",
        _HighScore = "HighScore";
    private void Awake()
    {
        instance = this;
        DefaultData();
        LoadData();
    }

    void DefaultData()
    {
        if (PlayerPrefs.GetFloat(_DefaultData) == 0)
        {
            PlayerPrefs.SetFloat(_DefaultData, 1);

            PlayerPrefs.SetFloat(_Resolution, 22);
        }
    }
    void LoadData()
    {
        resolutionValue = PlayerPrefs.GetFloat(_Resolution);
        highScore = PlayerPrefs.GetFloat(_HighScore);
    }

    public void SaveResolution(float value)
    {
        PlayerPrefs.SetFloat(_Resolution, value);
    }

}
