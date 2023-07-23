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

        }
        else if (scene == Scene.gameplay)
        {

        }
        Time.timeScale = 1;
    }
}
