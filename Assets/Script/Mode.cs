using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{
    public static Mode instance;

    public bool active = true;

    public Player player;
    public MiniPlayer miniPlayer;

    bool change;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!active) return;

        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (!change)
            {
                change = true;
                player.active = false;
                miniPlayer.active = true;

                miniPlayer.SavePosisi();
                CanvasGameplay.instance.changeMode.image.sprite = CanvasGameplay.instance.changeMode.modeMinirobot;
                AttackMiniPlayer.instance.UpdateUI(true);
            }
            else
            {
                change = false;
                //player.active = true;
                miniPlayer.active = false;

                miniPlayer.back = true;
                CanvasGameplay.instance.changeMode.image.sprite = CanvasGameplay.instance.changeMode.modeRobot;
                AttackMiniPlayer.instance.UpdateUI(false);
            }

            AudioManager.instance.ChangeModeSFX();
        }
    }
}
