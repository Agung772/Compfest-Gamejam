using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public static GameSave instance;

    public float resolutionValue;
    public float highStage;

    //Anti typo
    string _DefaultData = "DefaultData";
    [HideInInspector]
    public string
        _Resolution = "Resolution",
        _HighStage = "HighStage";
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
        highStage = PlayerPrefs.GetFloat(_HighStage);
    }

    public void SaveStage(int value)
    {
        if (highStage > value)
        {
            PlayerPrefs.SetFloat(_HighStage, value);

            LoadData();
        }
    }

    public void SaveResolution(float value)
    {
        PlayerPrefs.SetFloat(_Resolution, value);
    }

}
