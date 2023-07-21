using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mode : MonoBehaviour
{
    public Player player;
    public MiniPlayer miniPlayer;

    bool change;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!change)
            {
                change = true;
                player.active = false;
                miniPlayer.active = true;

                miniPlayer.SavePosisi();
            }
            else
            {
                change = false;
                player.active = true;
                miniPlayer.active = false;
            }
        }
    }
}
