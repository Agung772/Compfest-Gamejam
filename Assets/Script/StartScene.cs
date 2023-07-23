using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public enum Scene
    {
        mainmenu,
        gameplay
    }
    public Scene scene;

    private void Start()
    {
        //Scene
        if (scene == Scene.mainmenu)
        {
            AudioManager.instance.MainmenuBGM();
        }
        else if (scene == Scene.gameplay)
        {
            AudioManager.instance.GameplayBGM();
        }
        Time.timeScale = 1;
    }
}
